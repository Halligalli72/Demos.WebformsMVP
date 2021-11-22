using System.Collections.Generic;

namespace Demos.WebformsMVP.DataAccess.Entities
{
    
    public partial class UserProfile
    {
        public UserProfile()
        {
            this.Activity = new HashSet<Activity>();
        }
    
        public int UserProfileId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string Department { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsPublic { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Updated { get; set; }
    
        public virtual ICollection<Activity> Activity { get; set; }
    }
}
