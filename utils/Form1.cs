using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace utils
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var baseAddress = ConfigurationManager.AppSettings["baseUrl"];
            using (var httpClient = new HttpClient ())
            {
                httpClient.DefaultRequestHeaders.Add("authorization", "Bearer nhb2ym7u7xrgwejwdb4k");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                using (var content = new StringContent("{  \"login\": \"andrey.anfilets@mail.ru\",  \"password\": \"765312\"}", System.Text.Encoding.Default))
                {
                    using (var response = await httpClient.PostAsync("http://api.yclients.com/api/v1/auth", content))
                    {
                        CrmAuth p = await response.Content.ReadAsAsync<CrmAuth>();

                        //string responseData = await response.Content.ReadAsStringAsync();
                        //richTextBox1.AppendText(responseData);
                        //JObject json = JObject.Parse(responseData);
                        //JsonSerializer serializer = new JsonSerializer();
                        /// CrmAuth p = (CrmAuth)serializer.Deserialize(new JTokenReader(json), typeof(CrmAuth));
                        pictureBox1.LoadAsync(p.avatar);
                        richTextBox1.AppendText(Environment.NewLine + "user token " + p.user_token);
                        
                    }
                }
            }
        }

        public String GetUserToken()
        {
            String token = String.Empty;

            return token;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CrmApi api = new CrmApi();
            IEnumerable<EMR.DAL.Models.CrmPerson> lst = api.GetPersons();
            foreach (var p in lst)
            {
                richTextBox1.AppendText(p.name + " " + p.phone + Environment.NewLine);
            }
        }
    }
}
