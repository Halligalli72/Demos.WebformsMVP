using Demos.WebformsMVP.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.WebformsMVP.BusinessLogic
{
    public static class Helper
    {
        public static string ExtractUserName(string userNameString)
        {
            if (userNameString.Contains("\\"))
                return userNameString.Substring(userNameString.LastIndexOf("\\") + 1);
            else
                return userNameString;
        }

        internal static int CalculateScore(int duration)
        {
            //Every 30 minutes scores point
            const int divider = 30;
            decimal product = (duration / divider);
            return (int) Math.Floor(product);
        }
    }
}
