﻿using Demos.WebformsMVP.BusinessLogic;
using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demos.WebformsMVP.WebUI.Views
{
    public partial class Login : DemoBasePage, ILoginView
    {
        private LoginPresenter _presenter;
        //private string _suggestedUserName = string.Empty;
        public Login()
        {
            _presenter = new LoginPresenter(this);
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