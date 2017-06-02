using System;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Learn.Chap06
{
    public class Chap0607
    {

        public static void Main()
        {

            Console.WriteLine("Chapter 6 example 7: Scaling an Image");

            // step 1: creation of a document-object
            Document document = new Document();

            try
            {

                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file

                PdfWriter.getInstance(document, new FileStream("Chap0607.pdf", FileMode.Create));

                // step 3: we open the document
                document.Open();

                // step 4: we add content
                Image jpg1 = Image.getInstance("jpgPic.jpg");
                jpg1.scaleAbsolute(97, 101);
                document.Add(new Paragraph("scaleAbsolute(97, 101)"));
                document.Add(jpg1);
                Image jpg2 = Image.getInstance("jpgPic.jpg");
                jpg2.scalePercent(50);
                document.Add(new Paragraph("scalePercent(50)"));
                document.Add(jpg2);
                Image jpg3 = Image.getInstance("jpgPic.jpg");
                jpg3.scaleAbsolute(194, 101);
                document.Add(new Paragraph("scaleAbsolute(194, 101)"));
                document.Add(jpg3);
                Image jpg4 = Image.getInstance("jpgPic.jpg");
                jpg4.scalePercent(100, 50);
                document.Add(new Paragraph("scalePercent(100, 50)"));
                document.Add(jpg4);
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

            System.Diagnostics.Process.Start("Chap0607.pdf");
        }
    }
}