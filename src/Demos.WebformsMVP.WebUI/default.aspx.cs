using System;

namespace Demos.WebformsMVP.WebUI
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("Views/StartPage.aspx");
        }
    }
}