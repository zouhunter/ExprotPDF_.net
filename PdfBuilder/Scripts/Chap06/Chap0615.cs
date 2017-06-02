using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing.Imaging;

namespace Learn.Chap06
{

    public class Chap0615
    {
        public static void Main()
        {
            Console.WriteLine("Chapter 6 example 15: images in tables");
            // step 1: creation of a document-object
            Document document = new Document();
            try
            {
                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file
                PdfWriter.getInstance(document, new FileStream("Chap0615.pdf", FileMode.Create));
                // step 3: we open the document
                document.Open();
                // step 4: we create a table and add it to the document
                Image img0 = Image.getInstance("jpgPic.jpg");
                img0.Alignment = Image.MIDDLE;
                Image img1 = Image.getInstance("jpgPic.jpg");
                img1.Alignment = Image.LEFT | Image.UNDERLYING;
                Image img2 = Image.getInstance("jpgPic.jpg");
                img2.Alignment = Image.RIGHT | Image.TEXTWRAP;
                Image img3 = Image.getInstance("jpgPic.jpg");
                img3.Alignment = Image.LEFT;
                Image img4 = Image.getInstance("jpgPic.jpg");
                img4.Alignment = Image.MIDDLE;
                Image img5 = Image.getInstance("jpgPic.jpg");
                img5.Alignment = Image.RIGHT;
                Table table = new Table(3);
                table.Padding = 2;
                table.DefaultHorizontalAlignment = Element.ALIGN_CENTER;
                // row 1
                table.addCell("I see an image\non my right");
                Cell cell = new Cell("This is the image (aligned in the middle):");
                cell.BackgroundColor = new Color(0xC0, 0xC0, 0xC0);
                cell.Add(img0);
                cell.Add(new Phrase("This was the image"));
                table.addCell(cell);
                table.addCell("I see an image\non my left");
                // row 2
                cell = new Cell("This is the image (left aligned):");
                cell.Add(img1);
                cell.Add(new Phrase("This was the image"));
                table.addCell(cell);
                table.addCell("I see images\neverywhere");
                cell = new Cell("This is the image (right aligned):");
                cell.Add(img2);
                cell.Add(new Phrase("This was the image"));
                table.addCell(cell);
                // row 3
                table.addCell("I see an image\non my right");
                cell = new Cell(img3);
                cell.Add(img4);
                cell.Add(img5);
                table.addCell(cell);
                table.addCell("I see an image\non my left");
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

            System.Diagnostics.Process.Start("Chap0615.pdf");
        }
    }


}