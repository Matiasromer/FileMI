using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nemiro.OAuth;
using Nemiro.OAuth.LoginForms;

namespace FileMI
{
    public partial class Form1 : Form
    {
        private HttpAuthorization Authorization = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Properties.Settings.Default.AccessToken))
            {
                this.GetAccessToken();
            }
            else
            {
                this.GetFiles();
            }
        }
        
        private void GetAccessToken()
        {
            var login = new DropboxLogin("m45bsokx6gse20d", "zs3feykgwil7z26", "https://oauthproxy.nemiro.net/", false, false);
            
            login.Owner = this;
            login.ShowDialog();

            if (login.IsSuccessfully)
            {
                Properties.Settings.Default.AccessToken = login.AccessTokenValue;
                Properties.Settings.Default.Save();

                this.Authorization = new HttpAuthorization(AuthorizationType.Bearer, Properties.Settings.Default.AccessToken);
            }
            else
            {
                MessageBox.Show("Error...");
            }
        }

        private void GetFiles()
        {
            throw new NotImplementedException();
        }
    }
}
