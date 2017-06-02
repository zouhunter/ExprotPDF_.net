using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Learn.Chap06
{
    public class Chap0610
    {
        public static void Main()
    {

        Console.WriteLine("Chapter 6 example 10: Images using System.Drawing.Bitmap!");

        // step 1: creation of a document-object
        Document document = new Document();

        try
        {

            // step 2:
            // we create a writer that listens to the document
            // and directs a PDF-stream to a file
            PdfWriter writer = PdfWriter.getInstance(document, new FileStream("Chap0610.pdf", FileMode.Create));

            // step 3: we open the document
            document.Open();

            // step 4: we add content to the document
            for (int i = 0; i < 300; i++)
            {
                document.Add(new Phrase("Who is this? "));
            }
            PdfContentByte cb = writer.DirectContent;
            Image image = Image.getInstance(new System.Drawing.Bitmap("jpgPic.jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
            image.setAbsolutePosition(100, 200);
            cb.addImage(image);
        }
        catch (DocumentException de)
        {
            Console.WriteLine(de.Message);
        }
        catch (IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }

        // step 5: we close the document
        document.Close();


        System.Diagnostics.Process.Start("Chap0610.pdf");
        }
    }
}