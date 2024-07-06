using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Server {

    public partial class Server : Form {
        private TcpListener server;
        private Thread serverListen;
        private Thread clientListen;
        private int globalConnection = 0;
        private string globalRoomCode;
        private string idQuestion;
        private string idAnswer;
        private List<string> roomCode = new List<string>();
        private Dictionary<string, (TcpClient, bool)> onlinePlayers = new Dictionary<string, (TcpClient, bool)>();
        private Dictionary<string, int> isTrue = new Dictionary<string, int>();
        private Dictionary<string, string> ans = new Dictionary<string, string>();
        private Dictionary<string, List<List<string>>> playerAnswers = new Dictionary<string, List<List<string>>>();
        private Dictionary<string, List<string>> answerDescrpt = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> Answers = new Dictionary<string, List<string>>();
        private Dictionary<string, SemaphoreSlim> sem = new Dictionary<string, SemaphoreSlim>();
        private Dictionary<string, Dictionary<string, List<int>>> QuestionsR1 = new Dictionary<string, Dictionary<string, List<int>>>();
        private Dictionary<string, List<List<string>>> QuestionsR2 = new Dictionary<string, List<List<string>>>();
        private Dictionary<string, int> numConnection = new Dictionary<string, int>();
        private Dictionary<string, List<TcpClient>> rooms = new Dictionary<string, List<TcpClient>>();
        private Dictionary<string, Dictionary<string, List<int>>> users = new Dictionary<string, Dictionary<string, List<int>>>();
        private Dictionary<string, List<string>> packets = new Dictionary<string, List<string>>();

        public Server() {
            InitializeComponent();
            server = new TcpListener(IPAddress.Any, 12345);
            server.Start();
            rtbShow.Text = "Server is running on port 12345\r\nWaiting for connection...\r\n";
        }

        private void Server_Load(object sender, EventArgs e) {
            serverListen = new Thread(() => {
                while (true) {
                    TcpClient client = server.AcceptTcpClient();
                    appendText("New client connected from " + client.Client.RemoteEndPoint + "\r\n");
                    clientListen = new Thread(() => Listen(client));
                    clientListen.IsBackground = true;
                    clientListen.Start();
                }
            });
            serverListen.IsBackground = true;
            serverListen.Start();
        }

        private void Listen(TcpClient client) {
            while (client.Connected) {
                if (client.Available > 0) {
                    string message = "";
                    while (client.Available > 0) {
                        NetworkStream stream = client.GetStream();
                        byte[] buffer = new byte[1024];
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    }
                    appendText(client.Client.RemoteEndPoint + ": " + message + "\r\n");
                    AnalyzeMessage(message, client);
                }
            }
        }

        private async void AnalyzeMessage(string message, TcpClient client) {
            string[] Payload = message.Split(':');
            switch (Payload[0]) {
                case "ONLINE":
                    if (!onlinePlayers.ContainsKey(Payload[1])) {
                        onlinePlayers[Payload[1]] = (client, true);
                    }
                    break;
                case "OFFLINE":
                    onlinePlayers.Remove(Payload[1]);
                    break;
                case "INVITE":
                    string[] data = Payload[1].Split('-');
                    if (!onlinePlayers.ContainsKey(data[1])) {
                        SendData("REP_INVITE:0", client);
                    } else {
                        if (!onlinePlayers[data[1]].Item2) {
                            SendData("REP_INVITE:1", client);
                        } else {
                            SendData($"INVITE:{data[0]}-{data[2]}", onlinePlayers[data[1]].Item1);
                        }
                    }
                    break;
                case "REP_INVITE":
                    data = Payload[1].Split('-');
                    if (data[0] == "0") {
                        SendData("REP_INVITE:2", onlinePlayers[data[1]].Item1);
                    } else {
                        SendData("REP_INVITE:3", onlinePlayers[data[1]].Item1);
                    }
                    break;
                case "CONNECT":
                    data = Payload[1].Split('-');
                    onlinePlayers[data[1]] = (client, false);
                    if (!numConnection.ContainsKey(data[0]))
                        numConnection[data[0]] = 0;
                    numConnection[data[0]]++;
                    if (!users.ContainsKey(data[0]))
                        users[data[0]] = new Dictionary<string, List<int>>();
                    List<int> l = new List<int> { numConnection[data[0]], 0, 1 };
                    users[data[0]].Add(data[1], l);
                    if (!rooms.ContainsKey(data[0]))
                        rooms[data[0]] = new List<TcpClient>();
                    rooms[data[0]].Add(client);
                    if (!packets.ContainsKey(data[0]))
                        packets[data[0]] = new List<string>();
                    if (!sem.ContainsKey(data[0]))
                        sem[data[0]] = new SemaphoreSlim(1, 4);
                    string cmd = "INFO_CON:" + data[0] + "-" + numConnection[data[0]] + "-" + data[1] + "-" + users[data[0]][data[1]][0];
                    SendData(cmd, client);
                    HistorySync(packets, data[0], client);
                    packets[data[0]].Add(cmd);
                    Broadcast(cmd, data[0], client);
                    break;
                case "DISCONNECT":
                    data = Payload[1].Split('-');
                    packets[data[0]].Clear();
                    rooms[data[0]].Remove(client);
                    onlinePlayers[data[1]] = (client, true);
                    int temp = --numConnection[data[0]];
                    List<string> keys = users[data[0]].Keys.ToList();
                    bool af = false;
                    List<string> infos = new List<string>();
                    for (int i = 0; i < keys.Count; i++) {
                        if (keys[i] == data[1]) {
                            af = true;
                            users[data[0]].Remove(data[1]);
                            keys.Remove(keys[i]);
                            i--;
                            continue;
                        }
                        if (af)
                            users[data[0]][keys[i]][0]--;
                        string str = data[0] + "-" + numConnection[data[0]] + "-" + keys[i] + "-" + users[data[0]][keys[i]][0];
                        infos.Add(str);
                        packets[data[0]].Add("INFO_CON:" + str);
                    }
                    if (temp == 0) {
                        DeleteRoom(data[0]);
                    } else {
                        cmd = "INFO_DISCON:" + JsonConvert.SerializeObject(infos);
                        Broadcast(cmd, data[0], client);
                    }
                    break;
                case "START":
                    packets[Payload[1]].Clear();
                    if (!QuestionsR1.ContainsKey(Payload[1])) {
                        QuestionsR1[Payload[1]] = new Dictionary<string, List<int>>();
                    }
                    if (!Answers.ContainsKey(Payload[1])) {
                        Answers[Payload[1]] = new List<string>();
                    }
                    if (!answerDescrpt.ContainsKey(Payload[1])) {
                        answerDescrpt[Payload[1]] = new List<string>();
                    }
                    if (!playerAnswers.ContainsKey(Payload[1])) {
                        playerAnswers[Payload[1]] = new List<List<string>>();
                    }
                    if (!isTrue.ContainsKey(Payload[1])) {
                        isTrue[Payload[1]] = 0;
                    }
                    if (!ans.ContainsKey(Payload[1])) {
                        ans[Payload[1]] = "";
                    }
                    Broadcast("START:" + Payload[1], Payload[1], client);
                    break;
                case "CONNECT_MATCH":
                    Broadcast("SYNC:", Payload[1], client);
                    break;
                case "FIND":
                    data = Payload[1].Split('-');
                    await sem[data[0]].WaitAsync();
                    try {
                        if (globalConnection == 0) {
                            globalRoomCode = data[0];
                            globalConnection = 1;
                        } else if (globalConnection > 4) {
                            globalConnection = 0;
                        } else {
                            if (data[0] != globalRoomCode) {
                                DeleteRoom(data[0]);
                                numConnection[globalRoomCode] = globalConnection;
                                l = new List<int> { numConnection[globalRoomCode], 0, 1 };
                                users[globalRoomCode].Add(data[1], l);
                                rooms[globalRoomCode].Add(client);
                                if (globalConnection == 4) {
                                    packets[globalRoomCode].Clear();
                                    if (!QuestionsR1.ContainsKey(globalRoomCode)) {
                                        QuestionsR1[globalRoomCode] = new Dictionary<string, List<int>>();
                                    }
                                    if (!Answers.ContainsKey(globalRoomCode)) {
                                        Answers[globalRoomCode] = new List<string>();
                                    }
                                    if (!answerDescrpt.ContainsKey(globalRoomCode)) {
                                        answerDescrpt[globalRoomCode] = new List<string>();
                                    }
                                    if (!playerAnswers.ContainsKey(globalRoomCode)) {
                                        playerAnswers[globalRoomCode] = new List<List<string>>();
                                    }
                                    if (!isTrue.ContainsKey(globalRoomCode)) {
                                        isTrue[globalRoomCode] = 0;
                                    }
                                    if (ans.ContainsKey(globalRoomCode)) {
                                        ans[globalRoomCode] = "";
                                    }
                                    SendData("START:" + globalRoomCode, client);
                                    Broadcast("START:" + globalRoomCode, globalRoomCode, client);
                                }
                            }
                        }
                        globalConnection++;
                    } finally {
                        sem[data[0]].Release();
                        if (data[0] != globalRoomCode) {
                            sem.Remove(data[0]);
                        }
                    }
                    break;
                case "INFO_START":
                    //await sem[Payload[1]].WaitAsync();
                    try {
                        var k = users[Payload[1]].Keys.ToList();
                        cmd = $"INFO_START:{k[0]}-{k[1]}-{k[2]}-{k[3]}";
                        SendData(cmd, client);
                    } finally {
                        //   sem[Payload[1]].Release();
                    }
                    break;
                case "GET_QA_R1":
                    //await sem[Payload[1]].WaitAsync();
                    try {
                        if (!roomCode.Contains(Payload[1])) {
                            roomCode.Add(Payload[1]);
                            await GetImageQuestionRound1();
                            await GetImageAnswerRound1(Payload[1]);
                            await GetMemberQuestionRound1(Payload[1]);
                            List<string> answ = answerDescrpt[Payload[1]];
                            string json = $"IMAGE_QA:{answ[1]}*{answ[3]}";
                            SendData(json, client);
                            Broadcast(json, Payload[1], client);
                            json = "QA:" + JsonConvert.SerializeObject(QuestionsR1[Payload[1]]);
                            SendData(json, client);
                            Broadcast(json, Payload[1], client);
                            Thread.Sleep(3000);
                            cmd = "TURN:" + GetPlayerByTurn(Payload[1], 1);
                            SendData(cmd, client);
                            Broadcast(cmd, Payload[1], client);
                        }
                    } finally {
                        //    sem[Payload[1]].Release();
                    }
                    break;
                case "QUEST_R1":
                    data = Payload[1].Split('-');
                    Broadcast($"QUEST_R1:{data[1]}", data[0], client);
                    break;
                case "QUEST_R1_FN":
                    data = Payload[1].Split('-');
                    SendData($"QUEST_R1_FN:{data[1]}", client);
                    break;
                case "ANSWER_R1":
                    //await sem[Payload[1].Substring(0, 5)].WaitAsync();
                    try {
                        data = Payload[1].Split('-');
                        var answer = Answers[data[0]];
                        int b = 0;
                        ans[data[0]] = answer[int.Parse(data[4])];
                        if (data[2].ToUpper() == ans[data[0]].ToUpper()) {
                            users[data[0]][data[1]][1] += 10;
                            isTrue[data[0]] = 1;
                            b = 1;
                        } else {
                            b = 0;
                            if (isTrue[data[0]] != 1) {
                                isTrue[data[0]] = 0;
                            }
                        }
                        List<string> tmp = new List<string> {
                            data[1],
                            data[2],
                            data[3],
                            users[data[0]][data[1]][1].ToString(),
                            b.ToString(),
                        };
                        playerAnswers[data[0]].Add(tmp);
                    } finally {
                        //   sem[Payload[1].Substring(0, 5)].Release();
                    }
                    break;
                case "ANSWER_R2":
                    //await sem[Payload[1].Substring(0, 5)].WaitAsync();
                    try {
                        data = Payload[1].Split('-');
                        var answer = Answers[data[0]];
                        int b = 0;
                        ans[data[0]] = answer[int.Parse(data[4])];
                        string[] answs = ans[data[0]].Split('^');
                        foreach (string s in answs) {
                            if (data[2].ToUpper() == s.ToUpper()) {
                                isTrue[data[0]]++;
                                b = 1;
                                if (isTrue[data[0]] == 1)
                                    users[data[0]][data[1]][1] += 40;
                                else if (isTrue[data[0]] == 2)
                                    users[data[0]][data[1]][1] += 30;
                                else if (isTrue[data[0]] == 3)
                                    users[data[0]][data[1]][1] += 20;
                                else
                                    users[data[0]][data[1]][1] += 10;
                                break;
                            } else {
                                b = 0;
                            }
                        }
                        List<string> tmp = new List<string> {
                            data[1],
                            data[2],
                            data[3],
                            users[data[0]][data[1]][1].ToString(),
                            b.ToString(),
                        };
                        playerAnswers[data[0]].Add(tmp);
                    } finally {
                        //   sem[Payload[1].Substring(0, 5)].Release();
                    }
                    break;
                case "GET_ANSWER":
                    cmd = $"PLAYER_ANS:{isTrue[Payload[1]]}-{ans[Payload[1]]}-" + JsonConvert.SerializeObject(playerAnswers[Payload[1]]);
                    SendData(cmd, client);
                    break;
                case "GET_POINT":
                    isTrue[Payload[1]] = 0;
                    playerAnswers[Payload[1]].Clear();
                    var pls = users[Payload[1]];
                    var pk = pls.Keys.ToList();
                    cmd = $"POINT:{pls[pk[0]][1]}-{pls[pk[1]][1]}-{pls[pk[2]][1]}-{pls[pk[3]][1]}";
                    SendData(cmd, client);
                    Broadcast(cmd, Payload[1], client);
                    break;
                case "GET_POINT_FN":
                    isTrue[Payload[1]] = 0;
                    playerAnswers[Payload[1]].Clear();
                    pls = users[Payload[1]];
                    pk = pls.Keys.ToList();
                    cmd = $"POINT:{pls[pk[0]][1]}-{pls[pk[1]][1]}-{pls[pk[2]][1]}-{pls[pk[3]][1]}";
                    SendData(cmd, client);
                    break;
                case "GET_TURN":
                    data = Payload[1].Split('-');
                    cmd = "TURN:" + GetPlayerByTurn(data[0], int.Parse(data[1]) + 1);
                    SendData(cmd, client);
                    Broadcast(cmd, data[0], client);
                    break;
                case "GET_TURN_FN":
                    data = Payload[1].Split('-');
                    cmd = "TURN:" + GetPlayerByTurn(data[0], int.Parse(data[1]) + 1);
                    SendData(cmd, client);
                    break;
                case "BELL":
                    data = Payload[1].Split('-');
                    Broadcast($"BELL:{data[1]}", data[0], client);
                    break;
                case "ANS_BELL":
                    data = Payload[1].Split('-');
                    Broadcast($"ANS_BELL:{data[1]}-{data[2]}", data[0], client);
                    List<string> ansD = answerDescrpt[data[0]];
                    if (data[2].ToUpper() != ansD[0].ToUpper()) {
                        users[data[0]][data[1]][2] = 0;
                        SendData($"REP_BELL:0-", client);
                        Broadcast($"REP_BELL_OTHER:0-{data[1]}", data[0], client);
                    } else {
                        int score = 0;
                        if (data[3] == "1") {
                            score = 50;
                        } else if (data[3] == "2") {
                            score = 40;
                        } else if (data[3] == "3") {
                            score = 30;
                        } else if (data[3] == "4") {
                            score = 20;
                        } else {
                            score = 10;
                        }
                        users[data[0]][data[1]][1] += score;
                        SendData($"REP_BELL:1-{score}-{ansD[0]}-{ansD[2]}", client);
                        Broadcast($"REP_BELL_OTHER:1-{data[1]}-{score}-{ansD[0]}-{ansD[2]}", data[0], client);
                        Thread.Sleep(1000);
                        var u = users[data[0]][data[1]];
                        cmd = $"POINT_CNV:{u[0]}-{u[1]}";
                        SendData(cmd, client);
                        Broadcast(cmd, data[0], client);
                    }
                    break;
                case "ANSWER_R1_FN":
                    ansD = answerDescrpt[Payload[1]];
                    SendData($"ANSWER_R1_FN:{ansD[0]}-{ansD[2]}", client);
                    break;
                case "ROUND2":
                    //await sem[Payload[1]].WaitAsync();
                    try {
                        if (!QuestionsR2.ContainsKey(Payload[1])) {
                            QuestionsR2[Payload[1]] = new List<List<string>>();
                            Answers[Payload[1]].Clear();
                            await GetQuestionsRound2(Payload[1], "https://olympiawebservice.azurewebsites.net/api/Question/NormalRound2", 3);
                            await GetQuestionsRound2(Payload[1], "https://olympiawebservice.azurewebsites.net/api/Question/MainQuestionsByRound?round=2", 1);
                            var q = QuestionsR2[Payload[1]];
                            SendData($"QUEST_R2:0^{q[0][0]}^{q[0][1]}^{q[0][2]}", client);
                            Broadcast($"QUEST_R2:0^{q[0][0]}^{q[0][1]}^{q[0][2]}", Payload[1], client);
                        }
                    } finally {
                        //   sem[Payload[1]].Release();
                    }
                    break;
                case "QUEST_R2":
                    data = Payload[1].Split('-');
                    var qt = QuestionsR2[data[0]];
                    int t = int.Parse(data[1]);
                    SendData($"QUEST_R2:{t}^{qt[t][0]}^{qt[t][1]}^{qt[t][2]}", client);
                    break;
                case "WINNER":
                    data = Payload[1].Split('-');
                    pls = users[data[0]];
                    var sortPlayer = pls.OrderByDescending(p => p.Value[1]).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    pk = sortPlayer.Keys.ToList();
                    SendData($"WINNER:{pk[0]}-{pls[pk[0]][1]}-{pls[data[1]][1]}", client);
                    break;
                case "END":
                    data = Payload[1].Split('-');
                    onlinePlayers[data[1]] = (client, true);
                    DeleteRoom(data[0]);
                    if (isTrue.ContainsKey(data[0]))
                        isTrue.Remove(data[0]);
                    if (ans.ContainsKey(data[0]))
                        ans.Remove(data[0]);
                    if (playerAnswers.ContainsKey(data[0]))
                        playerAnswers.Remove(data[0]);
                    if (answerDescrpt.ContainsKey(data[0]))
                        answerDescrpt.Remove(data[0]);
                    if (Answers.ContainsKey(data[0]))
                        Answers.Remove(data[0]);
                    if (QuestionsR1.ContainsKey(data[0]))
                        QuestionsR1.Remove(data[0]);
                    if (QuestionsR2.ContainsKey(data[0]))
                        QuestionsR2.Remove(data[0]);
                    if (roomCode.Contains(data[0]))
                        roomCode.Remove(data[0]);
                    if (sem.ContainsKey(data[0]))
                        sem.Remove(data[0]);
                    break;
            }
        }

        private string GetPlayerByTurn(string roomCode, int turn) {
            if (turn > 4)
                turn = 1;
            foreach (var p in users[roomCode]) {
                if (p.Value[0] == turn) {
                    if (p.Value[2] == 0)
                        return GetPlayerByTurn(roomCode, turn + 1);
                    else
                        return p.Key + "-" + turn;
                }
            }
            return null;
        }

        private async void DeleteRoom(string roomCode) {
            if (packets.ContainsKey(roomCode))
                packets.Remove(roomCode);
            if (users.ContainsKey(roomCode))
                users.Remove(roomCode);
            if (rooms.ContainsKey(roomCode))
                rooms.Remove(roomCode);
            if (numConnection.ContainsKey(roomCode))
                numConnection.Remove(roomCode);
            using (HttpClient httpClient = new HttpClient()) {
                try {
                    string url = "https://olympiawebservice.azurewebsites.net/api/Room?idRoom=" + roomCode;
                    await httpClient.DeleteAsync(url);
                } catch (Exception ex) {

                }
            }
        }

        private async Task GetImageQuestionRound1() {
            using (HttpClient httpClient = new HttpClient()) {
                try {
                    var response = await httpClient.GetAsync("https://olympiawebservice.azurewebsites.net/api/Question/MainQuestionsByRound?round=1");
                    if (response.IsSuccessStatusCode) {
                        var res = await response.Content.ReadAsStringAsync();
                        JArray questions = JArray.Parse(res);
                        Random random = new Random();
                        int idx = random.Next(0, questions.Count);
                        idQuestion = questions[idx]["idQuestion"].ToString();
                        idAnswer = questions[idx]["idAnswer"].ToString();
                    }
                } catch (Exception) { }
            }
        }

        private async Task GetQuestionsRound2(string roomCode, string url, int num) {
            using (HttpClient httpClient = new HttpClient()) {
                try {
                    var response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode) {
                        var res = await response.Content.ReadAsStringAsync();
                        JArray questions = JArray.Parse(res);
                        Random random = new Random();
                        for (int i = 0; i < num; i++) {
                            int idx = random.Next(0, questions.Count);
                            JToken quest = questions[idx];
                            List<string> l = new List<string> {
                                quest["quest"].ToString(),
                                quest["media"].ToString(),
                                quest["time"].ToString()
                            };
                            string idQ = quest["idQuestion"].ToString();
                            QuestionsR2[roomCode].Add(l);
                            try {
                                response = await httpClient.GetAsync($"https://olympiawebservice.azurewebsites.net/api/Question/Answer/{idQ}");
                                if (response.IsSuccessStatusCode) {
                                    res = await response.Content.ReadAsStringAsync();
                                    JObject resAns = JObject.Parse(res);
                                    Answers[roomCode].Add(resAns["answ"].ToString());
                                }
                            } catch (Exception) { }
                            questions.RemoveAt(idx);
                        }
                    }
                } catch (Exception) { }
            }
        }

        private async Task GetMemberQuestionRound1(string roomCode) {
            using (HttpClient httpClient = new HttpClient()) {
                try {
                    var response = await httpClient.GetAsync($"https://olympiawebservice.azurewebsites.net/api/Question/MemberQuestions/{idQuestion}");
                    if (response.IsSuccessStatusCode) {
                        var res = await response.Content.ReadAsStringAsync();
                        JArray questions = JArray.Parse(res);
                        Random random = new Random();
                        foreach (var question in questions) {
                            string idQuest = question["idQuestion"].ToString();
                            string quest = question["quest"].ToString();
                            if (!QuestionsR1[roomCode].ContainsKey(quest)) {
                                try {
                                    response = await httpClient.GetAsync($"https://olympiawebservice.azurewebsites.net/api/Question/Answer/{idQuest}");
                                    if (response.IsSuccessStatusCode) {
                                        res = await response.Content.ReadAsStringAsync();
                                        JObject resAns = JObject.Parse(res);
                                        Answers[roomCode].Add(resAns["answ"].ToString());
                                        List<int> tmp = new List<int> {
                                            (int)resAns["numChars"],
                                            random.Next(-1,1)
                                        };
                                        QuestionsR1[roomCode].Add(quest, tmp);
                                    }
                                } catch (Exception) { }
                            }
                        }
                    }
                } catch (Exception) { }
            }
        }

        private async Task GetImageAnswerRound1(string roomCode) {
            using (HttpClient httpClient = new HttpClient()) {
                try {
                    var response = await httpClient.GetAsync($"https://olympiawebservice.azurewebsites.net/api/Answer/{idAnswer}");
                    if (response.IsSuccessStatusCode) {
                        var res = await response.Content.ReadAsStringAsync();
                        JObject resAns = JObject.Parse(res);
                        answerDescrpt[roomCode] = new List<string> {
                            resAns["answ"].ToString(),
                            resAns["picture"].ToString(),
                            resAns["note"].ToString(),
                            resAns["numChars"].ToString()
                        };
                    }
                } catch (Exception) { }
            }
        }

        private void SendData(string message, TcpClient client) {
            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
            Thread.Sleep(100);
        }

        private void Broadcast(string message, string roomCode, TcpClient sender) {
            for (int i = 0; i < rooms[roomCode].Count; i++) {
                TcpClient client = rooms[roomCode][i];
                if (!client.Connected || client == null) {
                    rooms[roomCode].Remove(client);
                } else if (client != sender) {
                    SendData(message, client);
                }
                Thread.Sleep(100);
            }
        }

        private void appendText(string text) {
            if (InvokeRequired) {
                Invoke(new Action<string>(appendText), text);
                return;
            }
            rtbShow.AppendText(text);
        }

        private void HistorySync(Dictionary<string, List<string>> data, string roomCode, TcpClient client) {
            if (data[roomCode].Count > 0) {
                foreach (string mess in data[roomCode]) {
                    SendData(mess, client);
                }
                Thread.Sleep(100);
            }
        }

        private void Server_Closing(object sender, FormClosingEventArgs e) {
            server.Stop();
            if (serverListen.IsAlive)
                serverListen.Abort();
        }
    }
}
