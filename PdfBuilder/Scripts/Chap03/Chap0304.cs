using System;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Learn.Chap03
{

    public class Chap0304
{

    public static void Main()
    {

        Console.WriteLine("Chapter 3 example 4: annotations at absolute positions");

        // step 1: creation of a document-object
        Document document = new Document(PageSize.A4, 50, 50, 50, 50);
        try
        {
            // step 2:
            // we create a writer that listens to the document
            PdfWriter writer = PdfWriter.getInstance(document, new FileStream("Chap0304.pdf", FileMode.Create));
            // step 3: we Open the document
            document.Open();
            // step 4: we Add some content

            PdfContentByte cb = writer.DirectContent;

            // draw a rectangle
            cb.setRGBColorStroke(0x00, 0x00, 0xFF);
            cb.rectangle(100, 700, 100, 100);
            cb.stroke();
            Annotation annot = new Annotation(100f, 700f, 200f, 800f, "http://itextsharp.sourceforge.net");
            document.Add(annot);
            cb.setRGBColorStroke(0xFF, 0x00, 0x00);
            cb.rectangle(200, 700, 100, 100);
            cb.stroke();
            try
            {
                document.Add(new Annotation(200f, 700f, 300f, 800f, new Uri("http://itextsharp.sourceforge.net")));
            }
            catch
            {
            }
            cb.setRGBColorStroke(0x00, 0xFF, 0x00);
            cb.rectangle(300, 700, 100, 100);
            cb.stroke();
            document.Add(new Annotation(300f, 700f, 400f, 800f, "c:/winnt/notepad.exe", null, null, null));
            cb.setRGBColorStroke(0x00, 0x00, 0xFF);
            cb.rectangle(100, 500, 100, 100);
            cb.stroke();
            document.Add(new Annotation("annotation", "This annotation is placed on an absolute position", 100f, 500f, 200f, 600f));
            cb.setRGBColorStroke(0xFF, 0x00, 0x00);
            cb.rectangle(200, 500, 100, 100);
            cb.stroke();
            document.Add(new Annotation(200f, 500f, 300f, 600f, "Chap1102a.pdf", "test"));
            cb.setRGBColorStroke(0x00, 0xFF, 0x00);
            cb.rectangle(300, 500, 100, 100);
            cb.stroke();
            document.Add(new Annotation(300f, 500f, 400f, 600f, "Chap1102b.pdf", 3));
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

            System.Diagnostics.Process.Start("Chap0304.pdf");
        }
    }
}

