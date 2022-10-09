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
    public partial class CreateProjectForm : Form
    {
        //public ProjectsPage projectPage;
        public CreateProjectForm()
        {
            InitializeComponent();
        }

        private void CreateBTN_Click(object sender, EventArgs e)
        {
            ProjectsPage.instance.addProject(nameBox.Text, DescriptionBox.Text, DateTime.Today, true);
        }

    }
}
