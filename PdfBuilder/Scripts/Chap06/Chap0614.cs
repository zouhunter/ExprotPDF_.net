using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing.Imaging;

namespace Learn.Chap06
{

    public class Chap0614
    {
        public static void Main()
        {
            Document.compress = false;
            Console.WriteLine("Chapter 6 example 14: images wrapped in a Chunk");
            // step 1: creation of a document-object
            Document document = new Document();
            try
            {
                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file
                PdfWriter.getInstance(document, new FileStream("Chap0614.pdf", FileMode.Create));
                // step 3: we open the document
                document.Open();
                // step 4: we create a table and add it to the document
                Image img = Image.getInstance("jpgPic.jpg");
                img.scalePercent(70);

                Chunk ck = new Chunk(img, 0, -5);
                Table table = new Table(3);
                table.WidthPercentage = 100;
                table.Padding = 2;
                table.DefaultHorizontalAlignment = Element.ALIGN_CENTER;

                Cell cell = new Cell(new Chunk(img, 0, -13));
                cell.BackgroundColor = new Color(0xC0, 0xC0, 0xC0);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.addCell("I see an image\non my right");
                table.addCell(cell);
                table.addCell("I see an image\non my left");
                table.addCell(cell);
                table.addCell("I see images\neverywhere");
                table.addCell(cell);
                table.addCell("I see an image\non my right");
                table.addCell(cell);
                table.addCell("I see an image\non my left");

                Phrase p1 = new Phrase("This is an image ");
                p1.Add(ck);
                p1.Add(" just here.");
                document.Add(p1);
                document.Add(p1);
                document.Add(p1);
                document.Add(p1);
                document.Add(p1);
                document.Add(p1);
                document.Add(p1);
                document.Add(table);
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

            System.Diagnostics.Process.Start("Chap0614.pdf");
        }
    }


}