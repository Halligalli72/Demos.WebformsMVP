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
        IActivityType Create(IActivityType activityType);
    }
}

/// <summary>
/// IMPLEMENTATION
/// </summary>
namespace Demos.WebformsMVP.BusinessLogic.Services
{
    public class ActivityTypeService: IActivityTypeService
    {
        private DataAccess.Repositories.IActivityTypeRepository _repo = null;

        public ActivityTypeService(DataAccess.Repositories.IActivityTypeRepository activityTypeRepo)
        {
            _repo = activityTypeRepo ?? throw new ArgumentNullException(nameof(activityTypeRepo));

        }
        private ActivityTypeService() { }

        public IActivityType Create(IActivityType activityType)
        {
            var hit = _repo.GetAll(includeInactive:true).Where(at => at.Name.ToLower().Equals(activityType.ActivityName)).FirstOrDefault();
            if (hit != null)
            {
                throw new Exception("An activity type with that name already exists!");
            }
            else 
            {
                int key = _repo.CreateType(Translator.TranslateToDatabaseObject(activityType));
                return Translator.TranslateToBusinessObject(_repo.GetByKey(key));
            }
        }

        public IList<IActivityType> GetAll(bool includeInactive)
        {
            return Translator.TranslateToBusinessObject(_repo.GetAll(includeInactive));
        }
    }
}
