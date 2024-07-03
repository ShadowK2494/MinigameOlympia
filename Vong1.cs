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


namespace MinigameOlympia
{
    public partial class Vong1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public Vong1()
        {
            InitializeComponent();
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


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
