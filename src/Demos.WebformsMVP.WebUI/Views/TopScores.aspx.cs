using Demos.WebformsMVP.BusinessLogic;
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
    public partial class TopScores : DemoBasePage, ITopScoresView
    {
        private TopScoresPresenter _presenter;

        public TopScores()
        {
            _presenter = new TopScoresPresenter(this);
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


        #region ITopScoresView
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