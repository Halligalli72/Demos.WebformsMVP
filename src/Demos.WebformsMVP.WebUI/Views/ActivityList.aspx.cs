using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Presenters;
using Demos.WebformsMVP.BusinessLogic.Views;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Demos.WebformsMVP.WebUI.Views
{
    public partial class ActivityList : BaseView, IActivityListView
    {
        private ActivityListPresenter _presenter;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            _presenter = new ActivityListPresenter(this, ActivityService);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string selection = Request.QueryString.Get("selection");
                if (!IsPostBack)
                {
                    _presenter.InitView(selection);
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
        }

        protected void gvActivityList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //Read values from row labels and send to presenter
                string userProfileIdStringValue = ((HiddenField)gvActivityList.Rows[e.RowIndex].FindControl("lblUserProfileId")).Value;
                string activityDateStringValue = ((Label)gvActivityList.Rows[e.RowIndex].FindControl("lblActivityDate")).Text;
                string activityTypeIdStringValue = ((HiddenField)gvActivityList.Rows[e.RowIndex].FindControl("lblActivityTypeId")).Value;

                _presenter.HandleDeleteOfSingleActivity(int.Parse(userProfileIdStringValue),
                    DateTime.Parse(activityDateStringValue),
                    int.Parse(activityTypeIdStringValue));
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
        }


        #region IActivityList

        public void DisplayActivities(IList<IActivity> activities)
        {
            if (activities != null)
            {
                gvActivityList.DataSource = activities;
                gvActivityList.DataBind();
            }
        }
        public string ListHeader
        {
            get { return lblListHeader.Text; }
            set { lblListHeader.Text = value; }
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

        public void DisplayUserInfo(IUserInfo user)
        {
            throw new NotImplementedException();
        }

        public void RedirectToLoginView()
        {
            Response.Redirect("Login.aspx", true);
        }

        #endregion

    }
}