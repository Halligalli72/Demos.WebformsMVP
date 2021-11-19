using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace Demos.WebformsMVP.WebUI.Views
{
    public partial class RegisterActivity : DemoBasePage, IRegisterActivityView
    {
        private RegisterActivityPresenter _presenter;

        private IList<IActivityType> _activityTypes = null;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            _presenter = new RegisterActivityPresenter(this, ActivityService, ActivityTypeService);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    UserName = LoggedInUser.UserName;
                    _presenter.InitView();
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _presenter.HandleSaveAction();
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
        }

        #region IRegisterActivityView
        public string ActivityDateInput
        {
            get { return txtActivityDate.Text; }
            set { txtActivityDate.Text = value; }
        }

        public int DurationInput
        {
            get { return int.Parse(txtDuration.Text); }
            set { txtDuration.Text = value.ToString(); }
        }

        public string UserName
        {
            get { return lblUsername.Text; }
            set { lblUsername.Text = value; }
        }

        public int SelectedActivityIdInput
        {
            get
            {
                int selectedId = 0;
                if (int.TryParse(drpActivityTypes.SelectedValue, out selectedId))
                {
                    return selectedId;
                }
                else
                {
                    throw new Exception("Invalid value in dropdown");
                }
            }
        }

        public string OtherActivityNameInput
        {
            get { return txtOtherActivity.Text; }
            set { txtOtherActivity.Text = value; }
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

        public void RedirectAfterSaveOK()
        {
            Response.Redirect("ActivityList.aspx?selection=own", false);
        }

        public void InitAvailableActivities(IList<IActivityType> types)
        {
            if (types != null)
            {
                _activityTypes = types.OrderBy(at => at.ActivityName).ToList();
                //Fill drop down
                drpActivityTypes.Items.Add(new ListItem() { Value = "0", Text = "- choose -" });
                foreach (var actType in _activityTypes)
                {
                    drpActivityTypes.Items.Add(new ListItem() { Value = actType.ID.ToString(), Text = actType.ActivityName });
                }
                drpActivityTypes.DataBind();
            }
            else
            {
                throw new ArgumentNullException("types");
            }
        }

        public void RedirectToLoginView()
        {
            Response.Redirect("Login.aspx", true);
        }


        #endregion

    }
}