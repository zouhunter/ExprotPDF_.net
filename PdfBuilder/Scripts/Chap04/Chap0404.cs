using System;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Learn.Chap04

{
    public class Chap0404
{
    public static void Main()
    {
        Console.WriteLine("Chapter 4 example 4: Simple Graphic");

        // step 1: creation of a document-object
        Document document = new Document();

        try
        {

            // step 2:
            // we create a writer that listens to the document
            // and directs a PDF-stream to a file

            PdfWriter.getInstance(document, new FileStream("Chap0404.pdf", FileMode.Create));

            // step 3: we open the document
            document.Open();

            // step 4: we add a Graphic to the document
            Graphic grx = new Graphic();
            // add a rectangle
            grx.rectangle(100, 700, 100, 100);
            // add the diagonal
            grx.moveTo(100, 700);
            grx.lineTo(200, 800);
            // stroke the lines
            grx.stroke();
            document.Add(grx);

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

            System.Diagnostics.Process.Start("Chap0404.pdf");
        }
    }
}