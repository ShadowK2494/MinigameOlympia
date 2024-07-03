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
        }

        //Hàm lấy các câu trả lời của người chơi từ textBox
        public string[] GetPlayerAnswers()
        {
            string[] playerAnswers = new string[4];
            for(int i=0;i<4;i++)
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
}
