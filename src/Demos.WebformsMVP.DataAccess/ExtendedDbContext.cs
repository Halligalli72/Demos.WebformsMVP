using System.Data.Entity;

namespace Demos.WebformsMVP.DataAccess
{
    public partial class WebformsMVPDemoEntities : IDbContext
    {
        public WebformsMVPDemoEntities(string connectionString) : base(connectionString) { }

        public new virtual IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
