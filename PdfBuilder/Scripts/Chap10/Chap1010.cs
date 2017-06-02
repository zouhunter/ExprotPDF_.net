using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Learn.Chap10
{
    public class Chap1010
    {
        public static void Main()
        {
            Console.WriteLine("Chapter 10 example 10: nested PdfPTables");

            // step 1: creation of a document-object
            Document document = new Document(PageSize.A4, 50, 50, 50, 50);
            try
            {
                // step 2: we create a writer that listens to the document
                PdfWriter writer = PdfWriter.getInstance(document, new FileStream("Chap1010.pdf", FileMode.Create));
                // step 3: we open the document
                document.Open();
                // step 4: we add some content
                PdfPTable table = new PdfPTable(4);
                PdfPTable nested1 = new PdfPTable(2);
                nested1.addCell("1.1");
                nested1.addCell("1.2");
                PdfPTable nested2 = new PdfPTable(1);
                nested2.addCell("2.1");
                nested2.addCell("2.2");
                for (int k = 0; k < 24; ++k)
                {
                    if (k == 1)
                    {
                        table.addCell(nested1);
                    }
                    else if (k == 20)
                    {
                        table.addCell(nested2);
                    }
                    else
                    {
                        table.addCell("cell " + k);
                    }
                }
                table.TotalWidth = 300;
                table.writeSelectedRows(0, -1, 100, 600, writer.DirectContent);
                // step 5: we close the document
                document.Close();

                System.Diagnostics.Process.Start("Chap1010.pdf");
            }
            catch (Exception de)
            {
                Console.Error.WriteLine(de.Message);
                Console.Error.WriteLine(de.StackTrace);
            }
        }
    }

}