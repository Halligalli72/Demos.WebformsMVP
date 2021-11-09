using Demos.WebformsMVP.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// INTERFACE
/// </summary>
namespace Demos.WebformsMVP.BusinessLogic.Interfaces
{
    public interface IActivity
    {
        int UserProfileId { get; set; }
        IUserInfo Performer { get; set; }
        DateTime ActivityDate { get; set; }
        int ActivityTypeId { get; set; }
        IActivityType ActivityType { get; set; }
        string OtherActivity { get; set; }
        int Duration { get; set; }
        int Score { get; set; }
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
    }
}

/// <summary>
/// IMPLEMENTATION
/// </summary>
namespace Demos.WebformsMVP.BusinessLogic.BusinessObjects
{
    public class Activity : IActivity
    {
        #region private members
        private int _userProfileId = 0;
        private IUserInfo _userInfo = null;
        private DateTime _activityDate;
        private int _activityTypeId = 0;
        private IActivityType _activityType = null;
        private string _otherActivity = string.Empty;
        private int _duration = 0;
        private int _score = 0;
        private DateTime _created;
        private DateTime _updated;
        #endregion

        /// <summary>
        /// Protected constructor
        /// </summary>
        internal Activity()
        {
        }

        public IUserInfo Performer
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        public IActivityType ActivityType
        {
            get { return _activityType; }
            set { _activityType = value; }
        }

        public DateTime ActivityDate
        {
            get { return _activityDate; }
            set { _activityDate = value; }
        }

        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }

        public DateTime Updated
        {
            get { return _updated; }
            set { _updated = value; }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public string OtherActivity
        {
            get { return _otherActivity; }
            set { _otherActivity = value; }
        }

        public int UserProfileId
        {
            get { return _userProfileId; }
            set { _userProfileId = value; }
        }

        public int ActivityTypeId
        {
            get { return _activityTypeId; }
            set { _activityTypeId = value; }
        }
    }
}
