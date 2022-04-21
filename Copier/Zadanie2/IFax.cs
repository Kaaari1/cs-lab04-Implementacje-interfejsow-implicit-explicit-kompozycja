using System;
using System.Collections.Generic;
using System.Text;
using Zadanie1;
namespace Zadanie2
{
    public interface IFax : IDevice
    {
        void Fax(in IDocument document, string numberOfFax);
    }
}
