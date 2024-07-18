namespace CollecgeStudent
{
    partial class LoginForm
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
            textBox_IdentityNum = new TextBox();
            button_login = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBox_IdentityNum
            // 
            textBox_IdentityNum.Font = new Font("Segoe UI", 16F);
            textBox_IdentityNum.Location = new Point(200, 193);
            textBox_IdentityNum.Name = "textBox_IdentityNum";
            textBox_IdentityNum.Size = new Size(272, 43);
            textBox_IdentityNum.TabIndex = 0;
            textBox_IdentityNum.TextChanged += textBox_IdentityNum_TextChanged;
            // 
            // button_login
            // 
            button_login.Location = new Point(266, 304);
            button_login.Name = "button_login";
            button_login.Size = new Size(125, 42);
            button_login.TabIndex = 1;
            button_login.Text = "כניסה";
            button_login.UseVisualStyleBackColor = true;
            button_login.Click += button_login_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(217, 114);
            label1.Name = "label1";
            label1.Size = new Size(223, 37);
            label1.TabIndex = 2;
            label1.Text = "הכנס תעדות זהות";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 513);
            Controls.Add(label1);
            Controls.Add(button_login);
            Controls.Add(textBox_IdentityNum);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_IdentityNum;
        private Button button_login;
        private Label label1;
    }
}