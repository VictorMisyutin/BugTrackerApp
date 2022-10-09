using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BugTrackerApp
{
    public partial class ProjectsPage : Form
    {
        public static ProjectsPage instance;
        //public TableLayoutPanel table1;
        public ProjectsPage()
        {
            InitializeComponent();
            instance = this;
            loadProjects();
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            new UserPage().Show();
            this.Dispose();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void newProjectButton_Click(object sender, EventArgs e)
        {
            //addProject("asd","asdsada",DateTime.Today);
            new CreateProjectForm().Show();
        }

        public ProjectsPage returnPage()
        {
            return new ProjectsPage();
        }

        private void loadProjects()
        {
            //get amount of rows in projects table
            string connectionString = Constants.connectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            int rows=0;
            try
            {
                SqlDataReader dataReader = null;
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) as count_rows\r\nFROM Projects;", connection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    rows = (int)dataReader.GetValue(0); ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            //add all or first 10 rows
            string tempName = "", tempDescription = "";
            DateTime tempDate = DateTime.Today;

            for (int i = 1; i <= rows ; i++)
            {
                try
                {
                    SqlDataReader dataReader = null;
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT ProjectName, Description, CreatedDate FROM Projects WHERE ID =\'" + i + "\' ;", connection);
                    dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Debug.WriteLine("reading Data");
                        tempName = (string)dataReader.GetValue(0);
                        tempDescription = (string)dataReader.GetValue(1);
                        tempDate = (DateTime)dataReader.GetValue(2);
                        /*
                        Debug.WriteLine("name" + tempName);
                        Debug.WriteLine("desc" + tempDescription);
                        Debug.WriteLine("date" + tempDate);
                        */
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                addProject(tempName,tempDescription,tempDate, false);
            }
        }

        public void addProject(string name, string description, DateTime dateCreated, bool addToDatabase)
        {
            Debug.WriteLine(projectsTable.RowCount);
            //get style of last row
            RowStyle temp = projectsTable.RowStyles[projectsTable.RowCount - 1];
            //add row
            projectsTable.RowCount++;
            //copy style of temp to new row
            projectsTable.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));

            //create new labels
            Guna2HtmlLabel ProjectNameLabel = new Guna2HtmlLabel();
            ProjectNameLabel.Size = new System.Drawing.Size(136, 27);
            ProjectNameLabel.Text = name;
            ProjectNameLabel.TextAlignment = ContentAlignment.MiddleLeft;
            ProjectNameLabel.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);


            Guna2HtmlLabel ProjectDescriptionLabel = new Guna2HtmlLabel();
            ProjectDescriptionLabel.Size = new System.Drawing.Size(116, 27);
            ProjectDescriptionLabel.Text = description;
            ProjectDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            Guna2HtmlLabel ProjectCreatedLabel = new Guna2HtmlLabel();
            ProjectCreatedLabel.Size = new System.Drawing.Size(116, 27);
            ProjectCreatedLabel.Text = dateCreated.ToString();
            ProjectCreatedLabel.TextAlignment = ContentAlignment.MiddleCenter;
            ProjectCreatedLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);

            //add labels
            projectsTable.Controls.Add(ProjectNameLabel, 2, projectsTable.RowCount - 1);
            projectsTable.Controls.Add(ProjectDescriptionLabel, 1, projectsTable.RowCount - 1);
            projectsTable.Controls.Add(ProjectCreatedLabel, 0, projectsTable.RowCount - 1);

            // if new project then add to database, else, don't
            if (addToDatabase == true)
            {
                addProjectToDatabase(ProjectNameLabel.Text, ProjectDescriptionLabel.Text, dateCreated);
            }
        }

        public void addProjectToDatabase(string name, string description, DateTime dateCreated)
        {

            // add to database
            string connectionString = Constants.connectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Projects(ProjectName,Description,CreatedDate)values(\'"
                + name + "\' , \'" + description + "\',\'" + dateCreated + "\')", connection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();

        }
    }
}
