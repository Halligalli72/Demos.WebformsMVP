using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Views;

namespace Demos.WebformsMVP.BusinessLogic.Presenters
{
    public class TopScoresPresenter
    {
        private readonly ITopScoresView _view;
        private readonly IActivityService _service;

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
