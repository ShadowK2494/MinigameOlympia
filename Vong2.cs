using MinigameOlympia.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigameOlympia
{
    public partial class Vong2 : Form
    {
        private Player player;
        public Vong2()
        {
            InitializeComponent();
        }

        private void Vong2_Load(object sender, EventArgs e)
        {

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
                var url = "https://olympiawebservice.azurewebsites.net/api/Question?round=2";
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
                var url = "https://olympiawebservice.azurewebsites.net/api/Question?round=2";
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
                Avatar = GetAvatarBytes(ptbAvatar1.Image)
            });

            players.Add(new Player
            {
                Username = groupBox_user2.Text,
                Score = int.Parse(label_score2.Text),
                Avatar = GetAvatarBytes(ptbAvatar2.Image)
            });

            players.Add(new Player
            {
                Username = groupBox_user3.Text,
                Score = int.Parse(label_score3.Text),
                Avatar = GetAvatarBytes(ptbAvatar3.Image)
            });

            players.Add(new Player
            {
                Username = groupBox_user4.Text,
                Score = int.Parse(label_score4.Text),
                Avatar = GetAvatarBytes(ptbAvatar4.Image)
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



    }
}
