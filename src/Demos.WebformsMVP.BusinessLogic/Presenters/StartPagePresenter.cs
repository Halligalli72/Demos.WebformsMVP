using Demos.WebformsMVP.BusinessLogic.Interfaces;

namespace Demos.WebformsMVP.BusinessLogic.Presenters
{
    public class StartPagePresenter
    {
        private IStartPageView _view;
        private IActivityService _service;

        public StartPagePresenter(IStartPageView view, IActivityService activitySvc)
        {
            _view = view;
            _service = activitySvc;
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
