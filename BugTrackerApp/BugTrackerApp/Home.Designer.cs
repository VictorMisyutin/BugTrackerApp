namespace BugTrackerApp
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.goToLogin = new System.Windows.Forms.Button();
            this.goToRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(315, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Bug Tracker";
            // 
            // goToLogin
            // 
            this.goToLogin.Location = new System.Drawing.Point(336, 94);
            this.goToLogin.Name = "goToLogin";
            this.goToLogin.Size = new System.Drawing.Size(102, 30);
            this.goToLogin.TabIndex = 1;
            this.goToLogin.Text = "Login";
            this.goToLogin.UseVisualStyleBackColor = true;
            this.goToLogin.Click += new System.EventHandler(this.goToLogin_Click);
            // 
            // goToRegister
            // 
            this.goToRegister.Location = new System.Drawing.Point(336, 145);
            this.goToRegister.Name = "goToRegister";
            this.goToRegister.Size = new System.Drawing.Size(102, 30);
            this.goToRegister.TabIndex = 2;
            this.goToRegister.Text = "Register";
            this.goToRegister.UseVisualStyleBackColor = true;
            this.goToRegister.Click += new System.EventHandler(this.goToRegister_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.goToRegister);
            this.Controls.Add(this.goToLogin);
            this.Controls.Add(this.label1);
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button goToLogin;
        private Button goToRegister;
    }
}