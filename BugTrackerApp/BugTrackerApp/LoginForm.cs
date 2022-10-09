using System.Data.SqlClient;
using System.Diagnostics;

namespace BugTrackerApp
{
    public partial class LoginForm : Form
    {
        private string emailInput, passwordInput;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
            new RegisterForm().Show();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            emailInput = emailTextBox.Text;
            passwordInput = passwordTextBox.Text;

            ValidateLogin();
        }


        private void ValidateLogin()
        {

            if (emailInput != "" && passwordInput != "")
            {
                string connectionString = Constants.connectionString;
                SqlConnection connection = new SqlConnection(connectionString);

                try
                {
                    SqlDataReader dataReader = null;
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT Password, FirstName, LastName, Company, AdminYN FROM Client WHERE Email =\'" + emailInput + "\' ", connection);
                    dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        //Debug.WriteLine(dataReader.GetValue(4));
                        Constants.userPassword = dataReader[0].ToString();
                        Constants.userFirstName = (string)dataReader.GetValue(1);
                        Constants.userLastName = (string)dataReader.GetValue(2);
                        Constants.userCompany = (string)dataReader.GetValue(3);
                        Constants.userAdmin = (bool)dataReader.GetValue(4);
                        //Constants.userAccountCreated = (DateTime)dataReader.GetValue(5);
                        //Debug.WriteLine(Constants.userAccountCreated);
                    }
                    if (Constants.userPassword == "" || Constants.userPassword == null)
                    {
                        MessageBox.Show("You do not have an account with us, please register below.");
                        return;
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

                if (passwordInput == Constants.userPassword)
                {
                    logIn(Constants.userAdmin);
                }
                else
                {
                    MessageBox.Show("Password was incorrect");
                }
            }
            else
            {
                MessageBox.Show("Please fill in the fields. ");
            }
        }

        private void logIn(bool adminBool)
        {
            //this.Hide();
            this.Dispose();
            if (Constants.userAdmin)
            {
                new AdminPage().Show();
            }
            else
            {
                //this.Hide();
                new UserPage().Show();
                //this.Close();
            }
        }
    }
}
