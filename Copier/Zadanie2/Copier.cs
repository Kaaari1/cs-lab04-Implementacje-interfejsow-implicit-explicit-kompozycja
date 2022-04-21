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
            
            switch (formatType)
            {
                case IDocument.FormatType.PDF:
                    type = "PDF";
                    
                    break;
                case IDocument.FormatType.JPG:
                    type = "JPG";
                    
                    break;
                case IDocument.FormatType.TXT:
                    type = "TXT";
                    
                    break;
            }
            string nameFile = string.Format(type + "Scan" + (ScanCounter + 1) + "." + formatType.ToString());
            if (formatType == IDocument.FormatType.TXT)
            {
                document = new TextDocument(nameFile);
            }
            else if (formatType == IDocument.FormatType.JPG)
            {
                document = new ImageDocument(nameFile);
            }
            else
            {
                document = new PDFDocument(nameFile);
            }
            if (state == IDevice.State.on)
            {
                Console.WriteLine(localDate + ", Scan: " + document.GetFileName());
                ScanCounter++;
            }
        }
        public void ScanAndPrint()
        {
            if (state == IDevice.State.on)
            {
                Scan(out IDocument document, IDocument.FormatType.JPG);
                Print(document);
            }
        }
    }
}


