using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.WebformsMVP.BusinessLogic.Presenters
{
    public class StartPagePresenter
    {
        private IStartPageView _view;
        private IActivityService _service;

        public StartPagePresenter(IStartPageView view)
        {
            _view = view;
            _service = new ActivityService();
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
