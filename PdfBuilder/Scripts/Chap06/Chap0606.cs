using System;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Learn.Chap06
{
    public class Chap0606
    {

        public static void Main()
        {

            Console.WriteLine("Chapter 6 example 6: Absolute Positioning of an Image");

            // step 1: creation of a document-object
            Document document = new Document();

            try
            {

                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file

                PdfWriter.getInstance(document, new FileStream("Chap0606.pdf", FileMode.Create));

                // step 3: we open the document
                document.Open();

                // step 4: we add content
                Image jpg = Image.getInstance("jpgPic.jpg");
                jpg.setAbsolutePosition(171, 250);
                document.Add(jpg);
                jpg.setAbsolutePosition(0, 0);
                document.Add(jpg);
            }
            catch (DocumentException de)
            {
                Console.Error.WriteLine(de.Message);
            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine(ioe.Message);
            }

            // step 5: we close the document
            document.Close();


            System.Diagnostics.Process.Start("Chap0606.pdf");
        }
    }
}