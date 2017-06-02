using System;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Learn.Chap06
{
    public class Chap0602
    {

        public static void Main()
        {

            Console.WriteLine("Chapter 6 example 2: Adding a Wmf, Gif, Jpeg and Png-file using filenames");

            // step 1: creation of a document-object
            Document document = new Document();

            try
            {
                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file
                PdfWriter.getInstance(document, new FileStream("Chap0602.pdf", FileMode.Create));

                // step 3: we open the document
                document.Open();

                Image gif = Image.getInstance("gifPic.gif");
                Image jpeg = Image.getInstance("jpgPic.jpg");
                Image png = Image.getInstance("pngPic.png");

                //document.Add(gif);
                jpeg.scalePercent(50);
                document.Add(jpeg);
                //document.Add(png);
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

            System.Diagnostics.Process.Start("Chap0602.pdf");
        }
    }
}