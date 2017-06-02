using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing.Imaging;

namespace Learn.Chap06
{
    public class Chap0613
    {
        public static void Main()
        {
            Console.WriteLine("Chapter 6 example 13: masked images");

            Document document = new Document(PageSize.A4, 50, 50, 50, 50);
            try
            {
                PdfWriter writer = PdfWriter.getInstance(document, new FileStream("Chap0613.pdf", FileMode.Create));

                document.Open();
                Paragraph p = new Paragraph("Some text behind a masked image.");
                document.Add(p);
                document.Add(p);
                document.Add(p);
                document.Add(p);
                document.Add(p);
                document.Add(p);
                document.Add(p);
                document.Add(p);
                document.Add(p);
                document.Add(p);

                document.Add(p);
                document.Add(p);
                document.Add(p);
                document.Add(p);
                document.Add(p);
                document.Add(p);
                document.Add(p);
                document.Add(p);
                document.Add(p);
                document.Add(p);
                document.Add(p);
                document.Add(p);
                document.Add(p);
                document.Add(p);
                document.Add(p);
                PdfContentByte cb = writer.DirectContent;
                byte[] maskr = { (byte)0x3c, (byte)0x7e, (byte)0xe7, (byte)0xc3, (byte)0xc3, (byte)0xe7, (byte)0x7e, (byte)0x3c };
                Image mask = Image.getInstance(8, 8, 1, 1, maskr);
                mask.makeMask();
                mask.InvertMask = true;
                Image image = Image.getInstance("jpgPic.jpg");
                image.ImageMask = mask;
                image.setAbsolutePosition(60, 620);
                // explicit masking
                cb.addImage(image);
                // stencil masking
                cb.setRGBColorFill(255, 0, 0);
                cb.addImage(mask, mask.ScaledWidth * 8, 0, 0, mask.ScaledHeight * 8, 100, 400);
                cb.setRGBColorFill(0, 255, 0);
                cb.addImage(mask, mask.ScaledWidth * 8, 0, 0, mask.ScaledHeight * 8, 200, 400);
                cb.setRGBColorFill(0, 0, 255);
                cb.addImage(mask, mask.ScaledWidth * 8, 0, 0, mask.ScaledHeight * 8, 300, 400);
                document.Close();

                System.Diagnostics.Process.Start("Chap0613.pdf");
            }
            catch (Exception de)
            {
                Console.Error.WriteLine(de.StackTrace);
            }
        }
    }


}