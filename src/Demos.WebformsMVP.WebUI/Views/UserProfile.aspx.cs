using Demos.WebformsMVP.BusinessLogic.Presenters;
using Demos.WebformsMVP.BusinessLogic.Views;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Demos.WebformsMVP.WebUI.Views
{
    public partial class UserProfile : DemoBasePage, IUserProfileView
    {
        private UserProfilePresenter _presenter;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            _presenter = new UserProfilePresenter(this, UserInfoService);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    _presenter.InitView(LoggedInUser);
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _presenter.HandleUpdateUserProfile();
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                LoggedInUser = null; //reset
                _presenter.HandleLogoutUser();
                Response.Redirect("StartPage.aspx", true);
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
        }


        #region IUserProfileView
        public string DepartmentInput
        {
            get { return txtDepartment.Text; }
            set { txtDepartment.Text = value; }
        }

        public string TeamNameInput
        {
            get { return txtTeam.Text; }
            set { txtTeam.Text = value; }
        }

        public string UserNameInput
        {
            get { return txtUsername.Text; }
            set { txtUsername.Text = value; }
        }

        public bool ResultsArePublicInput
        {
            get { return chkPublicResults.Checked; }
            set { chkPublicResults.Checked = value; }
        }

        public string NameInput
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        public string ExistingUserName
        {
            get
            {
                if (LoggedInUser != null)
                    return LoggedInUser.UserName;
                else
                    return string.Empty;
            }
        }

        public string SelectedTeam
        {
            get
            {
                return drpAvailableTeams.SelectedItem.Value;
            }
        }

        public void DisplayErrorMessage(string msg)
        {
            txtMessage.Text = msg;
            txtMessage.BackColor = System.Drawing.Color.Red;
            pnlMessage.Visible = true;
        }

        public void DisplayInfoMessage(string msg)
        {
            txtMessage.Text = msg;
            txtMessage.BackColor = System.Drawing.Color.LightGreen;
            pnlMessage.Visible = true;
        }

        public void RedirectToLoginPage()
        {
            Response.Redirect("Login.aspx", true);
        }

        public void DisplayUserProfileInformation()
        {
            if (LoggedInUser != null)
            {
                //Fill in read only form
                lblUserName.Text = LoggedInUser.UserName;
                lblName.Text = LoggedInUser.Name;
                lblTeamName.Text = LoggedInUser.TeamName;
                lblDepartmentName.Text = LoggedInUser.Department;
                if (LoggedInUser.ResultsArePublic)
                    lblResultsArePublic.Text = "YES";
                else
                    lblResultsArePublic.Text = "NO";

                //Fill in edit form
                UserNameInput = LoggedInUser.UserName;
                NameInput = LoggedInUser.Name;
                TeamNameInput = LoggedInUser.TeamName;
                DepartmentInput = LoggedInUser.Department;
                ResultsArePublicInput = LoggedInUser.ResultsArePublic;
            }
        }

        public void RedirectAfterUpdateOK()
        {
            Response.Redirect("UserProfile.aspx", true);
        }

        public void InitAvailableTeams(IList<string> teamNames)
        {
            drpAvailableTeams.Items.Add(new ListItem() { Value = string.Empty, Text = "- choose -" });
            foreach (var team in teamNames)
            {
                drpAvailableTeams.Items.Add(new ListItem() { Value = team, Text = team });
            }
            drpAvailableTeams.SelectedIndex = 0;
        }

        public void EnableLogoutFunction()
        {
            btnLogout.Visible = true;
        }

        #endregion

    }
}