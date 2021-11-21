
namespace Demos.WebformsMVP.DataAccess.Entities
{
    public partial class Activity
    {
        public int UserProfileId { get; set; }
        public int ActivityTypeId { get; set; }
        public string OtherActivity { get; set; }
        public System.DateTime ActivityDate { get; set; }
        public int Duration { get; set; }
        public int Score { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Updated { get; set; }
    
        public virtual ActivityType ActivityType { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
