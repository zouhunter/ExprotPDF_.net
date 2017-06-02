using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;

namespace Learn.Chap07
{

    public class Chap0702
    {

        public static void Main()
        {

            Console.WriteLine("Chapter 7 example 2: parsing the result of example 1");

            // step 1: creation of a document-object
            Document document = new Document();

            try
            {

                // step 2:
                // we create a writer that listens to the document
                // and directs a XML-stream to a file
                PdfWriter.getInstance(document, new FileStream("Chap0702.pdf", FileMode.Create));

                // step 3: we create a parser
                iTextHandler h = new iTextHandler(document);

                // step 4: we parse the document
                h.Parse("Config.xml");

                System.Diagnostics.Process.Start("Chap0702.pdf");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.StackTrace);
                Console.Error.WriteLine(e.Message);
            }
        }
    }

}