using System;
using System.Threading;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using Logic;

namespace UserInterface
{
     public partial class FormProfile : Form
     {
          private User m_LoggedInUser;
          private FormLogin m_FormLogIn;
          private AppSettings m_AppSettings;
          private FormBirthday m_FormBirthday;
          private FormPosts m_FormPosts;
          private FormFriends m_FormFriends;
          private FormAlbums m_FormAlbums;
          private FormGroups m_FormGroups;
          private FormCheckIn m_FormCheckIn;
          private FormEventComposer m_FormEvents;
          private FormMatch m_FormMatch;
          private FormCoronaIsolationPost m_FormCorona;

          public FormProfile()
          {
               if(!checkIfUserExists())
               {
                    initSetting();
               }

               m_AppSettings.SaveToFile();
               InitializeComponent();
               FacebookWrapper.FacebookService.s_CollectionLimit = 200;
               FacebookWrapper.FacebookService.s_FbApiVersion = 2.8f;
          }

          private void setToolTips()
          {
               setToolTip(pictureBoxAlbums, "Albums");
               setToolTip(pictureBoxMyPosts, "Posts");
               setToolTip(pictureBoxFriends, "Friends");
               setToolTip(pictureBoxGroups, "Groups");
               setToolTip(pictureBoxCheckin, "Check-Ins");
               setToolTip(pictureBoxEvents, "Events");
               setToolTip(pictureBoxCorona, "Corona virus update");
               setToolTip(pictureBoxBirthday, "Birthdays");
               setToolTip(pictureBoxMatch, "Most liked");
               setToolTip(pictureBoxPost, "Post");
               setToolTip(pictureBoxUpload, "Upload photo");
          }

          private void setToolTip(Control i_Element, string i_Text)
          {
               ToolTip toolTip = new ToolTip
               {
                    IsBalloon = true,
                    AutoPopDelay = 0,
                    InitialDelay = 0,
                    ReshowDelay = 0,
                    ShowAlways = true
               };

               toolTip.SetToolTip(i_Element, i_Text);
          }

          private void initSetting()
          {
               m_AppSettings = new AppSettings();
               m_FormLogIn = new FormLogin();
               m_FormLogIn.ShowDialog();

               if(m_FormLogIn.DialogResult == DialogResult.Cancel)
               {
                    MessageBox.Show("Sorry you must login to use our application bye bye.");
                    Environment.Exit(0);
               }

               m_LoggedInUser = m_FormLogIn.LoggedInUser;

               if(m_LoggedInUser == null)
               {
                    MessageBox.Show("Failed to login, try again next time");
                    Environment.Exit(0);
               }
          }

          protected override void OnFormClosing(FormClosingEventArgs e)
          {
               base.OnFormClosing(e);

               if(m_FormLogIn != null)
               {
                    m_AppSettings.RememberUser = m_FormLogIn.RememberMe;

                    if(m_AppSettings.RememberUser)
                    {
                         m_AppSettings.LastAccessToken = m_FormLogIn.FormLoginResult.AccessToken;
                    }
               }

               m_AppSettings.SaveToFile();
          }

          private bool checkIfUserExists()
          {
               bool v_IfRememberUser = false;

               m_AppSettings = AppSettings.LoadFromFile();
               if(m_AppSettings.RememberUser && !string.IsNullOrEmpty(m_AppSettings.LastAccessToken))
               {
                    v_IfRememberUser = true;
                    m_LoggedInUser = FacebookService.Connect(m_AppSettings.LastAccessToken).LoggedInUser;
               }

               return v_IfRememberUser;
          }

          protected override void OnShown(EventArgs e)
          {
               base.OnShown(e);
               fetchUserInfo();
               setToolTips();
               new Thread(firstInitPart).Start();
               new Thread(secondInitPart).Start();
               new Thread(thirdInitPart).Start();
          }

          private void firstInitPart()
          {
               m_FormBirthday = new FormBirthday(m_LoggedInUser);
               m_FormFriends = new FormFriends(m_LoggedInUser);
               m_FormPosts = new FormPosts(m_LoggedInUser);
          }

          private void secondInitPart()
          {
               m_FormAlbums = new FormAlbums(m_LoggedInUser);
               m_FormGroups = new FormGroups(m_LoggedInUser);
               m_FormCheckIn = new FormCheckIn(m_LoggedInUser);
          }

          private void thirdInitPart()
          {
            m_FormEvents = new FormEventComposer(m_LoggedInUser);
            m_FormCorona = new FormCoronaIsolationPost(m_LoggedInUser);
            m_FormMatch = new FormMatch(m_LoggedInUser);
          }

          private void fetchUserInfo()
          {
               pictureBoxProfilePic.Image = m_LoggedInUser.ImageSmall;
               labelBirthday.Text = string.Concat(labelBirthday.Text, m_LoggedInUser.Birthday);
               labelGender.Text = string.Concat(labelGender.Text, m_LoggedInUser.Gender);
               pictureBoxProfilePic.LoadAsync(m_LoggedInUser.PictureNormalURL);
               labelLogInName.Text = string.Format("Hello, {0}", m_LoggedInUser.Name);
               textBoxPost.Text = "Write your post...";
          }

          private void pictureBoxFriends_Click(object sender, EventArgs e)
          {
               if(m_FormFriends != null)
               {
                    m_FormFriends.ShowDialog();
               }
          }

          private void pictureBoxAlbums_Click(object sender, EventArgs e)
          {
               if(m_FormAlbums != null)
               {
                    m_FormAlbums.ShowDialog();
               }
          }

          private void pictureBoxPost_Click(object sender, EventArgs e)
          {
               try
               {
                    Status status = this.m_LoggedInUser.PostStatus(textBoxPost.Text, "1");
               }
               catch(Exception)
               {
                    MessageBox.Show("Posting Permission error !!!!");
                    textBoxPost.Clear();
               }
          }

          private void pictureBoxUpload_Click(object sender, EventArgs e)
          {
               try
               {
                    string pictureUrl;
                    openFileUploadPicture.InitialDirectory = "c:\\";
                    openFileUploadPicture.Filter = "*.png|*.jpg|*.jpeg|*.gif";
                    openFileUploadPicture.ShowDialog();
                    pictureUrl = openFileUploadPicture.FileName;
                    m_LoggedInUser.PostPhoto(pictureUrl, textBoxPost.Text);
               }
               catch(Exception)
               {
                    MessageBox.Show("Posting picture permission error !!!!");
               }
          }

          private void buttonLogOut_Click(object sender, EventArgs e)
          {
               FacebookService.Logout(new Action(onLogOut));
          }

          private void onLogOut()
          {
               m_AppSettings.LastAccessToken = null;
               m_AppSettings.RememberUser = false;
               m_AppSettings.SaveToFile();
               MessageBox.Show("Thank you for using our facebook, bye bye.");
               labelLogInName.Text = string.Format("Hello, {0}", m_LoggedInUser.Name);
               this.Close();
          }

          private void pictureBoxMyPosts_Click(object sender, EventArgs e)
          {
               if(m_FormPosts != null)
               {
                    m_FormPosts.ShowDialog();
               }
          }

          private void pictureBoxGroups_Click(object sender, EventArgs e)
          {
               if(m_FormGroups != null)
               {
                    m_FormGroups.ShowDialog();
               }
          }

          private void pictureBoxCheckin_Click(object sender, EventArgs e)
          {
               if(m_FormCheckIn != null)
               {
                    m_FormCheckIn.ShowDialog();
               }
          }

          private void pictureBoxEvents_Click(object sender, EventArgs e)
          {
               if(m_FormEvents != null)
               {
                    m_FormEvents.ShowDialog();
               }
          }

          private void pictureBoxBirthday_Click(object sender, EventArgs e)
          {
               if(m_FormBirthday != null)
               {
                    m_FormBirthday.ShowDialog();
               }
          }

          private void buttonExit_Click(object sender, EventArgs e)
          {
               this.DialogResult = DialogResult.OK;
               this.Close();
          }

          private void pictureBoxCorona_Click(object sender, EventArgs e)
          {
               if(m_FormCorona != null)
               {
                    m_FormCorona.ShowDialog();
               }
          }

          private void pictureBoxMatch_Click(object sender, EventArgs e)
          {
               if(m_FormMatch != null)
               {
                    m_FormMatch.ShowDialog();
               }
          }

        private void FormProfile_Load(object sender, EventArgs e)
        {

        }
    }
}
