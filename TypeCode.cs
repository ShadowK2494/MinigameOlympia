﻿using MinigameOlympia.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigameOlympia {
    public partial class TypeCode : Form {
        public Player player;
        public Image image;
        public string roomCode = "";
        public List<List<Player>> friendList;
        public TypeCode() {
            InitializeComponent();
        }

        private async void btnEnter_Click(object sender, EventArgs e) {
            HttpClient client = new HttpClient();
            try {
                string url = "http://localhost:2804/api/room/" + tbRoomCode.Text;
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode) {
                    var res = await response.Content.ReadAsStringAsync();
                    JObject keyValuePairs = JObject.Parse(res);
                    JToken roomRes = keyValuePairs["isFull"];
                    if (roomRes.Value<bool>()) {
                        MessageBox.Show("Phòng " + tbRoomCode.Text + " đã đủ người!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } else {
                        roomCode = tbRoomCode.Text;
                        PhongCho pc = new PhongCho();
                        pc.player = player;
                        pc.image = image;
                        pc.roomCode = roomCode;
                        pc.friendList = friendList;
                        pc.isAdmin = false;
                        pc.Show();
                        Close();
                        foreach (Form form in Application.OpenForms) {
                            if (form.Name == "GiaoDienChinh") {
                                form.Visible = false;
                                break;
                            }
                        }
                    }
                } else {
                    MessageBox.Show("Không tìm thấy phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch (Exception ex) {
            
            }
        }
    }
}
