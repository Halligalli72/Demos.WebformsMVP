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
    public interface IUserInfo
    {
        int ID { get; set; }
        string UserName { get; set; }
        string Name { get; set; }
        string TeamName { get; set; }
        string Department { get; set; }
        bool IsAdmin { get; set; }
        bool ResultsArePublic { get; set; }
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
    }
}

/// <summary>
/// IMPLEMENTATION
/// </summary>
namespace Demos.WebformsMVP.BusinessLogic.BusinessObjects
{
    public class UserInfo : IUserInfo
    {
        #region private members
        private int _id = 0;
        private string _userName = string.Empty;
        private string _name = string.Empty;
        private string _teamName = string.Empty;
        private string _department = string.Empty;
        private bool _isAdmin = false;
        private bool _resultsArePublic = false;
        private DateTime _created;
        private DateTime _updated;
        #endregion

        /// <summary>
        /// Protected constructor
        /// </summary>
        internal UserInfo()
        {
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Department
        {
            get { return _department; }
            set { _department = value; }
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

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string TeamName
        {
            get { return _teamName; }
            set { _teamName = value; }
        }

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

        public bool ResultsArePublic
        {
            get { return _resultsArePublic; }
            set { _resultsArePublic = value; }
        }
    }
}
