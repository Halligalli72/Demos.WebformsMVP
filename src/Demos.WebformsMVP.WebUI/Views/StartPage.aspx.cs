﻿using Demos.WebformsMVP.BusinessLogic;
using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Presenters;
using Demos.WebformsMVP.BusinessLogic.Services;
using System;

namespace Demos.WebformsMVP.WebUI.Views
{
    public partial class StartPage : DemoBasePage, IStartPageView
    {
        private StartPagePresenter _presenter;

        public StartPage()
        {
            //TODO: Use DI framework with interfaces instead
            var dbCtx = new DataAccess.WebformsMVPDemoEntities(Constants.CONNECTION_STRING);
            var activitySvc = new ActivityService(DataAccess.ActivityRepository.CreateInstance(dbCtx));
            _presenter = new StartPagePresenter(this, activitySvc);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    _presenter.InitView();
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
        }

        #region IStartPageView
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

        #endregion
    }
}