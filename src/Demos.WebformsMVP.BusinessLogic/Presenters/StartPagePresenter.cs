using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Services;

namespace Demos.WebformsMVP.BusinessLogic.Presenters
{
    public class StartPagePresenter
    {
        private IStartPageView _view;
        private IActivityService _service;

        public StartPagePresenter(DataAccess.IDbContext dbCtx, IStartPageView view)
        {
            _view = view;
            _service = new ActivityService(dbCtx);
        }

        public IStartPageView View
        {
            get { return _view; }
        }

        public void InitView()
        {

        }
    }
}
