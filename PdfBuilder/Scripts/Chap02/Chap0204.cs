using System;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Learn.Chap02
{
    public class Chap0204
{

    public static void Main()
    {

        Console.WriteLine("Chapter 2 example 4: Negative leading");

        // step 1: creation of a document-object
        Document document = new Document();

        try
        {
            // step 2:
            // we create a writer that listens to the document
            // and directs a PDF-stream to a file
            PdfWriter.getInstance(document, new FileStream("Chap0204.pdf", FileMode.Create));

            // step 3: we open the document
            document.Open();

            // step 4: we Add a paragraph to the document
            document.Add(new Phrase(16, "\n\n\n"));
            document.Add(new Phrase(-16, "Hello, this is a very long phrase to show you the somewhat odd effect of a negative leading. You can write from bottom to top. This is not fully supported. It's something between a feature and a bug."));

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

            System.Diagnostics.Process.Start("Chap0204.pdf");
        }
    }
}

