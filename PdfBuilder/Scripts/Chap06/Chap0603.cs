using System;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Learn.Chap06
{
    public class Chap0603
    {

        public static void Main()
        {
            //Console.WriteLine("Chapter 6 example 3: using a relative path for HTML");

            //// step 1: creation of a document-object
            //Document document = new Document();

            //try
            //{

            //    // step 2:
            //    // we create a writer that listens to the document
            //    // and directs a PDF-stream to a file

            //    PdfWriter.getInstance(document, new FileStream("Chap0603.pdf", FileMode.Create));

            //    // step 3: we open the document
            //    document.Open();

            //    // step 4: we add content
            //    Image jpg = Image.getInstance("jpgPic.jpg");
            //    jpg.scalePercent(50);
            //    document.Add(jpg);

            //}
            //catch (DocumentException de)
            //{
            //    Console.Error.WriteLine(de.Message);
            //}
            //catch (IOException ioe)
            //{
            //    Console.Error.WriteLine(ioe.Message);
            //}

            //// step 5: we close the document
            //document.Close();


            //System.Diagnostics.Process.Start("Chap0603.pdf");
        }
    }
}