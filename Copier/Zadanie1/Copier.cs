using System;

namespace Zadanie1
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {
        public int PrintCounter { get; set; } = 0;
        public int ScanCounter { get; set; } = 0;
        public int Counter { get; set; } = 0;

        public void PowerOn()
        {
            base.PowerOn();
            Counter++;
        }

        public void Print(in IDocument document)
        {
            DateTime localDate = DateTime.Now;
            if (state == IDevice.State.on)
            {
                Console.WriteLine(localDate + " Print: " + document.GetFileName());
                PrintCounter++;
            }
        }
        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.PDF)
        {
            DateTime localDate = DateTime.Now;
            string type = "";
            string nameFile = string.Format(type + "Scan" + ScanCounter + 1 + "." + formatType.ToString());
            switch (formatType)
            {
                case IDocument.FormatType.PDF:
                    type = "PDF";
                    document = new PDFDocument(nameFile);
                    break;
                case IDocument.FormatType.JPG:
                    type = "JPG";
                    document = new ImageDocument(nameFile);
                    break;
                case IDocument.FormatType.TXT:
                    type = "TXT";
                    document = new TextDocument(nameFile);
                    break;
            }
            if (state == IDevice.State.on)
            {
                Console.WriteLine(localDate + ", Scan: " + document.GetFileName());
                ScanCounter++;
            }
        }
    }
}


