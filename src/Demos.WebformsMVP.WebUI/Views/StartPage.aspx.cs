using Demos.WebformsMVP.BusinessLogic.Presenters;
using Demos.WebformsMVP.BusinessLogic.Views;
using System;

namespace Demos.WebformsMVP.WebUI.Views
{
    public partial class StartPage : BasePage, IStartPageView
    {
        private StartPagePresenter _presenter;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            _presenter = new StartPagePresenter(this, ActivityService);
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