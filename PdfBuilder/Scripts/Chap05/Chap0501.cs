using System;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Learn.Chap05
{
    public class Chap0501
    {

        public static void Main()
        {
            Console.WriteLine("Chapter 5 example 1: my first table");
            // step 1: creation of a document-object
            Document document = new Document();
            try
            {
                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file
                PdfWriter.getInstance(document, new FileStream("Chap0501.pdf", FileMode.Create));
                // step 3: we open the document
                document.Open();
                // step 4: we create a table and add it to the document
                Table aTable = new Table(2, 2);    // 2 rows, 2 columns
                aTable.addCell("0.0");
                aTable.addCell("0.1");
                aTable.addCell("1.0");
                aTable.addCell("1.1");
                document.Add(aTable);
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

            System.Diagnostics.Process.Start("Chap0501.pdf");
        }
    }
}