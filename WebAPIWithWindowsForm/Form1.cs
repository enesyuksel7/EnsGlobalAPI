using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Json;
using System.Net.Http;
using Entities.Dtos.UserDtos;

namespace WebAPIWithWindowsForm
{
    public partial class Form1 : Form
    {
        #region Defines

        private string apiURL = "http://localhost:22421/api/";
        private int selectedID = 0;
        HttpClient httpClient = new HttpClient();
        UserAddDto userAddDto = new UserAddDto();

        #endregion Defines

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await DataGirdViewFill();
        }

        #region Methods
        private async Task DataGirdViewFill()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var kayitlar = await httpClient.GetFromJsonAsync<List<UserDetailDto>>(apiURL + "Users/GetList");
                dataGridView1.DataSource = kayitlar;
                richTextBox1.Text = kayitlar.ToString();
            }
        }

        void ClearForm()
        {
            txtFirstName.Text = txtLastName.Text = txtUserName.Text = txtPassword.Text = txtEmail.Text = String.Empty;
            txtPhoneNumber.Text = txtCardLimit.Text = "";
            comboBox1.SelectedValue = 0;
            dateTimePicker1.Value = DateTime.Now;
        }

        private async void btnGetAll_Click(object sender, EventArgs e)
        {
            await DataGirdViewFill();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            //var responce = await RestHelper.Get(txtID.Text);
            //richTextBox1.Text = responce;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                UserAddDto userAddDto = new UserAddDto()
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text,
                    Gender = comboBox1.Text == "Erkek" ? true : false,
                    DateOfBirth = dateTimePicker1.Value,
                    Email = txtEmail.Text,
                    PhoneNumber = Convert.ToInt32(txtPhoneNumber.Text),
                    CardLimit = float.Parse(txtCardLimit.Text)
                };
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(apiURL + "Users/Add", userAddDto);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Ekleme işlemi başarılı!");
                    await DataGirdViewFill();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Ekleme işlemi başarısız!");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            selectedID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            using (httpClient)
            {
                var sutunlar = await httpClient.GetFromJsonAsync<UserDto>
            }
        }
    }
}