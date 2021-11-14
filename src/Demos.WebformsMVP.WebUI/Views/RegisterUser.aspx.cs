using Demos.WebformsMVP.BusinessLogic;
using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Presenters;
using Demos.WebformsMVP.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Demos.WebformsMVP.WebUI.Views
{
    public partial class RegisterUser : DemoBasePage, IRegisterUserView
    {
        private RegisterUserPresenter _presenter;

        public RegisterUser()
        {
            //TODO: Use DI framework with interfaces instead
            var dbCtx = new DataAccess.WebformsMVPDemoEntities(Constants.CONNECTION_STRING);
            var svc = new UserInfoService(DataAccess.UserProfileRepository.CreateInstance(dbCtx));
            _presenter = new RegisterUserPresenter(this, svc);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    _presenter.InitView(LoggedInUser, Helper.ExtractUserName(Request.LogonUserIdentity.Name));
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
        }

        protected void btnRegisterUser_Click(object sender, EventArgs e)
        {
            try
            {
                _presenter.HandleRegisterNewUserAction();
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
        }


        #region IRegisterUserView
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

        public void InitAvailableTeams(IList<string> teamNames)
        {
            drpAvailableTeams.Items.Add(new ListItem() { Value = string.Empty, Text = "- choose -" });
            foreach (var team in teamNames)
            {
                drpAvailableTeams.Items.Add(new ListItem() {Value = team, Text = team });
            }
            drpAvailableTeams.SelectedIndex = 0;
        }

        public void RedirectToProfilePage()
        {
            Response.Redirect("UserProfile.aspx", true);
        }

        #endregion

    }
}