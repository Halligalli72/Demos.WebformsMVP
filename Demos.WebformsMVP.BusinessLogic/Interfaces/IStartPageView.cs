using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.WebformsMVP.BusinessLogic.Interfaces
{
    public interface IStartPageView
    {



        void DisplayInfoMessage(string msg);

        void DisplayErrorMessage(string msg);

    }
}
