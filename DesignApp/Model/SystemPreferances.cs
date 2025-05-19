using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignApp.Model
{
    class SystemPreferances
    {
        public static class NavigationState
        {
            public static string LastTabRoute { get; set; } = "home"; // default
        }
    }
}
