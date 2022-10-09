using System.Data.SqlClient;
using System.Diagnostics;

namespace BugTrackerApp
{
    public partial class RegisterForm : Form
    {
        private string firstName = "", lastName = "", email = "", company = "", password = "", confirmPassword = "";

        private int Admin = 0;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        //private char admin = '';
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            firstName = firstNameBox.Text;
            lastName = lastNameBox.Text;
            email = emailBox.Text;
            company = companyBox.Text;
            password = passwordBox1.Text;
            confirmPassword = passwordBox2.Text;
            if (checkBox1.Checked)
            {
                Admin = 1;
            }
            if (firstName != "" && lastName != "" && email != "" && company != "" 
                && password != "" && confirmPassword != "" && password.Equals(confirmPassword))
            {
                
                // check if passwords match

                // check if email is already used

                Register();
            }
            else
            {
                MessageBox.Show("Please fill out all fields");
            }
        }

        private void Register()
        {
            string connectionString = Constants.connectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                //DateTime temp = @DateTime.Now;
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Client(LastName,FirstName,Company,Password,Email,AdminYN,CreatedDate)values(\'"
                + lastName + "\' , \'" + firstName + "\',\'" + company + "\',\'" + password + "\',\'" + email + "\'," + Admin +", \'" +DateTime.Today + "\')", connection);
                
                sqlCommand.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
            this.Dispose();
            new LoginForm().Show();
        }
    }
}