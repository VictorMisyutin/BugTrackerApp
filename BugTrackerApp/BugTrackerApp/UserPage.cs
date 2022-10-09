using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BugTrackerApp
{
    public partial class UserPage : Form
    {
        public UserPage()
        {
            InitializeComponent();
            UserFirstNameLabel.Text = (Constants.userFirstName + ", Welcome to Bug Tracker");
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void projectsButton_Click(object sender, EventArgs e)
        {
            ProjectsPage projectPage = new ProjectsPage();
            projectPage.Show();
            this.Dispose();
        }
    }
}
