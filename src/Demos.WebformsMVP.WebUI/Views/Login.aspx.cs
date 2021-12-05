using Demos.WebformsMVP.BusinessLogic;
using Demos.WebformsMVP.BusinessLogic.Presenters;
using Demos.WebformsMVP.BusinessLogic.Views;
using System;

namespace Demos.WebformsMVP.WebUI.Views
{
    public partial class Login : BasePage, ILoginView
    {
        private LoginPresenter _presenter;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            _presenter = new LoginPresenter(this, UserInfoService);
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                _presenter.TryLogin();
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }

        }


        #region ILoginView
        public string UserNameInput
        {
            get { return txtUsername.Text; }
            set { txtUsername.Text = value; }
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

        public void RedirectLoginOK()
        {
            Response.Redirect("RegisterActivity.aspx", true);
        }

        public void RedirectAlreadyLoggedIn()
        {
            Response.Redirect("UserProfile.aspx", true);
        }
        #endregion
    }
}