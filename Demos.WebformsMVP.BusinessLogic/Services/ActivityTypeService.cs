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
    public interface IActivityTypeService
    {
        IList<IActivityType> GetAll(bool includeInactive);
    }
}

/// <summary>
/// IMPLEMENTATION
/// </summary>
namespace Demos.WebformsMVP.BusinessLogic.Services
{
    public class ActivityTypeService: IActivityTypeService
    {
        private DataAccess.IActivityTypeRepository _repo = null;

        public ActivityTypeService()
        {
            _repo = DataAccess.ActivityTypeRepository.CreateInstance();
        }

        public IList<IActivityType> GetAll(bool includeInactive)
        {
            return Translator.TranslateToBusinessObject(_repo.GetAll(includeInactive));
        }
    }
}
