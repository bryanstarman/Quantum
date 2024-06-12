using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Modelo
{
    public class MenuFlyoutItem
    {
        public string Title { get; set; }

        public string IconSource { get; set; }
        public string ButtonExit { get; set; }

        public Type TargetType { get; set; }
    }
}
