using MinigameOlympia.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.CodeDom;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net.Sockets;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Reflection.Emit;


namespace MinigameOlympia
{
    public partial class Vong1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public Player player;

        public Vong1()
        {
            InitializeComponent();
            this.Load += Vong1_Load;
        }
        private void Vong1_Load(object sender, EventArgs e)
        {
            //
        }
        //Hàm đếm thời gian
        public void CountdownTimer()
        {
            int secondsRemaining = 10;
            progressBar_time.Minimum = 0;
            progressBar_time.Maximum = 10;

            while (secondsRemaining > 0)
            {
                progressBar_time.Value = secondsRemaining;
                secondsRemaining--;
                System.Threading.Thread.Sleep(1000); // Chờ 1 giây
            }
            label_timerNoti.Visible = true;
            //Hết thời gian sẽ tự động gửi câu trả lời có trong textBox
            GetPlayerAnswers();
            UpdatePlayerScoreUI();
        }

        //Hàm lấy các câu trả lời của người chơi từ textBox
        public string[] GetPlayerAnswers()
        {
            string[] playerAnswers = new string[4];
            for (int i = 0; i < 4; i++)
            {
                int index = i;
                textBox_answer.Name = $"textBox_answer_{index}";
                playerAnswers[i] = textBox_answer.Text;
            }
            return playerAnswers;
        }

        public static async Task<Question> GetRandomSubQuestion_Async()
        {
            using (var httpClient = new HttpClient())
            {
                var url = "https://olympiawebservice.azurewebsites.net/api/Question?round=1";
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var questions = JsonConvert.DeserializeObject<List<Question>>(await response.Content.ReadAsStringAsync());
                var subQuestions = questions.Where(q => !q.IsMain).ToList();
                if (subQuestions.Count > 0)
                {
                    var randomIndex = new Random().Next(0, subQuestions.Count);
                    return subQuestions[randomIndex];
                }
                else
                {
                    return null;
                }
            }
        }

        public static async Task<Question> GetRandomMainQuestion_Async()
        {
            using (var httpClient = new HttpClient())
            {
                var url = "https://olympiawebservice.azurewebsites.net/api/Question?round=1";
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var questions = JsonConvert.DeserializeObject<List<Question>>(await response.Content.ReadAsStringAsync());
                var mainQuestions = questions.Where(q => q.IsMain).ToList();
                if (mainQuestions.Count > 0)
                {
                    var randomIndex = new Random().Next(0, mainQuestions.Count);
                    return mainQuestions[randomIndex];
                }
                else
                {
                    return null;
                }
            }
        }
        public List<Player> GetPlayerScores()
        {
            List<Player> players = new List<Player>();
            players.Add(new Player
            {
                Username = groupBox_user1.Text,
                Score = int.Parse(label_score1.Text),
               
            });

            players.Add(new Player
            {
                Username = groupBox_user2.Text,
                Score = int.Parse(label_score2.Text),
                
            });

            players.Add(new Player
            {
                Username = groupBox_user3.Text,
                Score = int.Parse(label_score3.Text),
               
            });

            players.Add(new Player
            {
                Username = groupBox_user4.Text,
                Score = int.Parse(label_score4.Text),
               
            });

            return players;
        }

        private byte[] GetAvatarBytes(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public async Task<Question> GetQuestion(string questName)
        {
            using (var httpClient = new HttpClient())
            {
                var url = $"https://olympiawebservice.azurewebsites.net/api/Question?quest={questName}";
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Question>(responseBody);
                }
                return null;
            }

        }
        /*private async Task<Player> getPlayer(string username)
        {
            Player pTemp = new Player();
            HttpClient httpClient = new HttpClient();
            try
            {
                string url = "https://olympiawebservice.azurewebsites.net/api/Player/username?lookup=" + username;
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    pTemp = JsonConvert.DeserializeObject<Player>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return pTemp;
        }*/
        private async void UpdatePlayerScoreUI()
        {
            using (var httpClient = new HttpClient())
            {
                string qs = panel1.Name;
                var question = await GetQuestion(qs);
                var correctAnswer = question.Answer.Answ;
                List<Player> a = new List<Player>();
                string[] answerFromPlayer = GetPlayerAnswers();
                for (int i = 0; i < 4; i++)
                {
                    if (answerFromPlayer[i] == correctAnswer)
                    {
                        a[i].Score += 10;
                    }
                }
                label_score1.Text = a[0].Score.ToString();
                label_score2.Text = a[1].Score.ToString();
                label_score3.Text = a[2].Score.ToString();
                label_score4.Text = a[3].Score.ToString();
            }

            //Not completed, fix later
            //public static async Task<Question> GetGroupQuestion_Async(string IDQuestion)
            //{
            //    using (var httpClient = new HttpClient())
            //    {
            //        var url = "https://olympiawebservice.azurewebsites.net/api/GroupQuestion";
            //        var response = await httpClient.GetAsync(url);
            //        response.EnsureSuccessStatusCode();
            //        var questions = JsonConvert.DeserializeObject<List<Question>>(await response.Content.ReadAsStringAsync());
            //        var groupQuestions = questions.Where(q => q.IsMain).ToList();
            //        if (groupQuestions.Count > 0)
            //        {
            //            var randomIndex = new Random().Next(0, groupQuestions.Count);
            //            return groupQuestions[randomIndex];
            //        }
            //        else
            //        {
            //            return null;
            //        }
            //    }
            //}
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }


       /* private async void button2_Click_1(object sender, EventArgs e)
        {
            string key = textBox1.Text.ToString();
            using (var httpClient = new HttpClient())
            {
                try
                {

                    string link = questionPicture.ImageLocation;
                    var url = $"https://olympiawebservice.azurewebsites.net/api/Answer?picture={link}";
                    var response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var answer = JsonConvert.DeserializeObject<Answer>(responseBody);

                        if (key == answer.Answ)
                        {

                            if (InvokeRequired)
                            {
                                Invoke(new Action(() => {
                                    player.Score += 20;
                                    OpenVong2();
                                }));
                            }
                            else
                            {
                                player.Score += 20;
                                OpenVong2();
                            }
                        }
                        else
                        {
                            // Xử lý trường hợp trả lời sai nếu cần
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ, có thể hiển thị thông báo lỗi cho người dùng
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
                }
            }
        }*/
       /* private void OpenVong2()
        {
            Vong2 vong2 = new Vong2();
            vong2.Text = "Vòng thi tăng tốc - " + player.Username;
            this.Visible = false;
            vong2.Show();
        }*/
/*
        private void button1_Click_1(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox1.Visible = true;
            button2.Visible = true;
        }*/
    }
}
