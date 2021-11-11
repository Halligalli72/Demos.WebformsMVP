namespace Demos.WebformsMVP.BusinessLogic
{
    public static class Constants
    {
        /// <summary>
        /// Name in app.config/web.config
        /// </summary>
        public const string CONNECTION_STRING = "name=WebformsMVPDemoEntities";

        public static string UserObjectKey
        {
            get { return "Demos.WebformsMVP.UserInfo"; }
        }
    }
}
