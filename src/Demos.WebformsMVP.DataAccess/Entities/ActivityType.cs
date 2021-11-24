using System.Collections.Generic;

namespace Demos.WebformsMVP.DataAccess.Entities
{
    
    public partial class ActivityType
    {
        public ActivityType()
        {
            this.Activity = new HashSet<Activity>();
        }
    
        public int ActivityTypeId { get; set; }
        public string Name { get; set; }
        public int StepValue { get; set; }
        public bool IsActivated { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Updated { get; set; }
    
        public virtual ICollection<Activity> Activity { get; set; }
    }
}
