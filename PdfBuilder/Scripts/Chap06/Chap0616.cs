using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing.Imaging;

namespace Learn.Chap06
{
    public class Chap0616
    {

        public static void Main()
        {

            Console.WriteLine("Chapter 6 example 16: images and annotations");

            // step 1: creation of a document-object
            Document document = new Document(PageSize.A4, 50, 50, 50, 50);
            try
            {
                // step 2:
                // we create a writer that listens to the document
                PdfWriter writer = PdfWriter.getInstance(document, new FileStream("Chap0616.pdf", FileMode.Create));
                // step 3: we open the document
                document.Open();
                //// step 4: we add some content
                //Image wmf = Image.getInstance(new Uri("http://itext.sourceforge.net/examples/harbour.wmf"));
                //wmf.Annotation = new Annotation(0, 0, 0, 0, "http://www.lowagie.com");
                //wmf.setAbsolutePosition(100f, 600f);
                //document.Add(wmf);
                //Image gif = Image.getInstance(new Uri("http://itext.sourceforge.net/examples/vonnegut.gif"));
                //gif.Annotation = new Annotation(0, 0, 0, 0, "Chap0610.pdf", 3);
                //gif.setAbsolutePosition(100f, 400f);
                //document.Add(gif);
                Image jpeg = Image.getInstance("jpgPic.jpg");//new Uri("http://itext.sourceforge.net/examples/myKids.jpg")
                jpeg.Annotation = new Annotation("picture", "These are my children", 0, 0, 0, 0);
                jpeg.setAbsolutePosition(100f, 150f);
                document.Add(jpeg);
                //Image png = Image.getInstance(new Uri("http://itext.sourceforge.net/examples/hitchcock.png"));
                //png.Annotation = new Annotation(0, 0, 0, 0, "Chap0610.pdf", "test");
                //png.setAbsolutePosition(350f, 250f);
                //document.Add(png);
            }
            catch (Exception de)
            {
                Console.Error.WriteLine(de.StackTrace);
            }

            // step 5: we close the document
            document.Close();


            System.Diagnostics.Process.Start("Chap0616.pdf");
        }
    }


}