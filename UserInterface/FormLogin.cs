using System;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using Logic;

namespace UserInterface
{
     public partial class FormLogin : Form
     {
          private const string m_AppID = "283238313148583";

          public User LoggedInUser
          {
               get;
               private set;
          }

          public LoginResult FormLoginResult
          {
               get;
               private set;
          }

          public bool RememberMe
          {
               get;
               set;
          }

          public FormLogin()
          {
               InitializeComponent();
          }

          private void loggedInUserData()
          {
               FormLoginResult = FacebookService.Login(
                    m_AppID,
            "public_profile",
            "email",
            "publish_to_groups",
            "user_birthday",
            "user_age_range",
            "user_gender",
            "user_link",
            "user_videos",
            "publish_to_groups",
            "groups_access_member_info",
            "user_friends",
            "user_events",
            "user_likes",
            "user_location",
            "user_photos",
            "user_posts",
            "user_hometown");

               AppSettings appSettings = AppSettings.LoadFromFile();

               if(!string.IsNullOrEmpty(FormLoginResult.AccessToken))
               {
                    LoggedInUser = FormLoginResult.LoggedInUser;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
               }
               else
               {
                    MessageBox.Show(FormLoginResult.ErrorMessage);
               }
          }

          private void checkBoxRemeberMe_CheckedChanged(object sender, EventArgs e)
          {
               this.RememberMe = checkBoxRemeberMe.Checked;
          }

          private void buttonLogIn_Click(object sender, EventArgs e)
          {
               loggedInUserData();
          }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}