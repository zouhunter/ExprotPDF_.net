using System;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Learn.Chap06
{
    public class Chap0601
    {

        public static void Main()
        {

            Console.WriteLine("Chapter 6 example 1: Adding a Wmf, Gif, Jpeg and Png-file using urls");

            // step 1: creation of a document-object
            Document document = new Document();

            try
            {
                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file
                PdfWriter.getInstance(document, new FileStream("Chap0601.pdf", FileMode.Create));

                // step 3: we open the document
                document.Open();

                //Image wmf = Image.getInstance(new Uri("http://itextsharp.sourceforge.net/examples/harbour.wmf"));
                //Image gif = Image.getInstance(new Uri("http://itextsharp.sourceforge.net/examples/vonnegut.gif"));
                //Image jpeg = Image.getInstance(new Uri("http://itextsharp.sourceforge.net/examples/myKids.jpg"));
                //Image png = Image.getInstance(new Uri("http://itextsharp.sourceforge.net/examples/hitchcock.png"));
                //Image gif = Image.getInstance(new Uri("file://" + System.IO.Path.GetFullPath("gifPic.gif")));
                Image jpeg = Image.getInstance(new Uri("file://" + System.IO.Path.GetFullPath("jpgPic.jpg")));
                //Image png = Image.getInstance(new Uri("file://" + System.IO.Path.GetFullPath("pngPic.png")));

                //document.Add(wmf);
                //document.Add(gif);
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


            System.Diagnostics.Process.Start("Chap0601.pdf");
        }
    }
}