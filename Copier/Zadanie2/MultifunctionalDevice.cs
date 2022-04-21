using System;
using System.Collections.Generic;
using System.Text;
using Zadanie1;
namespace Zadanie2
{
    class MultifunctionalDevice : Copier, IFax
    {
        public int FaxCounter { get; set; } = 0;
    }
}
