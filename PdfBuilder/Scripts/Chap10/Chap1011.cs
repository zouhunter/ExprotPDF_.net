using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Learn.Chap10
{
    public class Chap1011
    {

        public static void Main()
        {

            Console.WriteLine("Chapter 10 example 11: a PdfPTable in a template");

            // step 1: creation of a document-object
            Rectangle rect = new Rectangle(PageSize.A4);
            rect.BackgroundColor = new Color(238, 221, 88);
            Document document = new Document(rect, 50, 50, 50, 50);
            try
            {
                // step 2: we create a writer that listens to the document
                PdfWriter writer = PdfWriter.getInstance(document, new FileStream("Chap1011.pdf", FileMode.Create));
                // step 3: we open the document
                document.Open();
                // step 4:
                PdfTemplate template = writer.DirectContent.createTemplate(20, 20);
                BaseFont bf = BaseFont.createFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.NOT_EMBEDDED);
                String text = "Vertical";
                float size = 16;
                float width = bf.getWidthPoint(text, size);
                template.beginText();
                template.setRGBColorFillF(1, 1, 1);
                template.setFontAndSize(bf, size);
                template.setTextMatrix(0, 2);
                template.showText(text);
                template.endText();
                template.Width = width;
                template.Height = size + 2;
                Image img = Image.getInstance(template);
                img.setRotationDegrees(90);
                Chunk ck = new Chunk(img, 0, 0);
                PdfPTable table = new PdfPTable(3);
                table.WidthPercentage = 100;
                table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                PdfPCell cell = new PdfPCell(img);
                cell.Padding = 4;
                cell.BackgroundColor = new Color(0, 0, 255);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.addCell("I see a template on my right");
                table.addCell(cell);
                table.addCell("I see a template on my left");
                table.addCell(cell);
                table.addCell("I see a template everywhere");
                table.addCell(cell);
                table.addCell("I see a template on my right");
                table.addCell(cell);
                table.addCell("I see a template on my left");

                Paragraph p1 = new Paragraph("This is a template ");
                p1.Add(ck);
                p1.Add(" just here.");
                p1.Leading = img.ScaledHeight * 1.1f;
                document.Add(p1);
                document.Add(table);
                Paragraph p2 = new Paragraph("More templates ");
                p2.Leading = img.ScaledHeight * 1.1f;
                p2.Alignment = Element.ALIGN_JUSTIFIED;
                img.scalePercent(70);
                for (int k = 0; k < 20; ++k)
                    p2.Add(ck);
                document.Add(p2);
                // step 5: we close the document
                document.Close();

                System.Diagnostics.Process.Start("Chap1011.pdf");
            }
            catch (Exception de)
            {
                Console.Error.WriteLine(de.Message);
                Console.Error.WriteLine(de.StackTrace);
            }
        }
    }


}