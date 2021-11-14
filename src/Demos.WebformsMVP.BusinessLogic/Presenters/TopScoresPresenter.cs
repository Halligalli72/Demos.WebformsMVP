using Demos.WebformsMVP.BusinessLogic.Interfaces;

namespace Demos.WebformsMVP.BusinessLogic.Presenters
{
    public class TopScoresPresenter
    {
        private ITopScoresView _view;
        private IActivityService _service;

        public TopScoresPresenter(ITopScoresView view, IActivityService activitySvc)
        {
            _view = view;
            _service = activitySvc;
        }

        public ITopScoresView View
        {
            get { return _view; }
        }

        public void InitView()
        {

        }

    }
}
