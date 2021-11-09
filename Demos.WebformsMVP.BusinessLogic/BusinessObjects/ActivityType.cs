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
    public interface IActivityType
    {
        int ID { get; set; }
        string ActivityName { get; set; }
        int Steps { get; set; }
        bool IsActivated { get; set; }
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
    }
}

/// <summary>
/// IMPLEMENTATION
/// </summary>
namespace Demos.WebformsMVP.BusinessLogic.BusinessObjects
{
    public class ActivityType : IActivityType
    {
        #region private members
        private int _id = 0;
        private string _name = string.Empty;
        private int _stepValue = 0;
        bool _isActive = false;
        private DateTime _created;
        private DateTime _updated;
        #endregion

        /// <summary>
        /// Protected constructor
        /// </summary>
        internal ActivityType()
        {
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string ActivityName
        {
            get { return _name; }
            set { _name = value; }
        }


        public int Steps
        {
            get { return _stepValue; }
            set { _stepValue = value; }
        }

        public bool IsActivated
        {
            get { return _isActive; }
            set { _isActive = value; }
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

    }
}
