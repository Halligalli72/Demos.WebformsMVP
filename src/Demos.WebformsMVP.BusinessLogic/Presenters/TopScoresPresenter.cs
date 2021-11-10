using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.WebformsMVP.BusinessLogic.Presenters
{
    public class TopScoresPresenter
    {
        private ITopScoresView _view;
        private IActivityService _service;

        public TopScoresPresenter(ITopScoresView view)
        {
            _view = view;
            _service = new ActivityService();
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
