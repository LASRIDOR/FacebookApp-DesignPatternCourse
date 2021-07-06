namespace UserInterface
{
     public partial class FormLogin
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
               if(disposing && (components != null))
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
            this.checkBoxRemeberMe = new System.Windows.Forms.CheckBox();
            this.LogoPicture = new System.Windows.Forms.PictureBox();
            this.LoginButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxRemeberMe
            // 
            this.checkBoxRemeberMe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxRemeberMe.AutoSize = true;
            this.checkBoxRemeberMe.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.checkBoxRemeberMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRemeberMe.Location = new System.Drawing.Point(149, 331);
            this.checkBoxRemeberMe.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.checkBoxRemeberMe.Name = "checkBoxRemeberMe";
            this.checkBoxRemeberMe.Size = new System.Drawing.Size(122, 21);
            this.checkBoxRemeberMe.TabIndex = 2;
            this.checkBoxRemeberMe.Text = "Remember Me!";
            this.checkBoxRemeberMe.UseVisualStyleBackColor = true;
            this.checkBoxRemeberMe.CheckedChanged += new System.EventHandler(this.checkBoxRemeberMe_CheckedChanged);
            // 
            // LogoPicture
            // 
            this.LogoPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogoPicture.BackColor = System.Drawing.Color.White;
            this.LogoPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogoPicture.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.LogoPicture.Image = global::FacebookApiApp.Properties.Resources.FacebookLogo;
            this.LogoPicture.Location = new System.Drawing.Point(121, 41);
            this.LogoPicture.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.LogoPicture.Name = "LogoPicture";
            this.LogoPicture.Size = new System.Drawing.Size(171, 168);
            this.LogoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoPicture.TabIndex = 1;
            this.LogoPicture.TabStop = false;
            // 
            // LoginButton
            // 
            this.LoginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LoginButton.BackgroundImage = global::FacebookApiApp.Properties.Resources.FacebookLoginButton;
            this.LoginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoginButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.Location = new System.Drawing.Point(104, 274);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(201, 47);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.buttonLogIn_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(409, 365);
            this.Controls.Add(this.checkBoxRemeberMe);
            this.Controls.Add(this.LogoPicture);
            this.Controls.Add(this.LoginButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.MaximumSize = new System.Drawing.Size(430, 422);
            this.MinimumSize = new System.Drawing.Size(234, 348);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login ";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.Button LoginButton;
          private System.Windows.Forms.PictureBox LogoPicture;
          private System.Windows.Forms.CheckBox checkBoxRemeberMe;
     }
}