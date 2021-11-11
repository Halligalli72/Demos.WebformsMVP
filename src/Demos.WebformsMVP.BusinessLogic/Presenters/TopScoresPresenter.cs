using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Services;

namespace Demos.WebformsMVP.BusinessLogic.Presenters
{
    public class TopScoresPresenter
    {
        private ITopScoresView _view;
        private IActivityService _service;

        public TopScoresPresenter(DataAccess.IDbContext dbCtx, ITopScoresView view)
        {
            _view = view;
            _service = new ActivityService(dbCtx);
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
