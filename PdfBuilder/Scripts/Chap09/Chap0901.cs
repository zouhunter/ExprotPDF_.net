using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Learn.Chap09
{
    public class Chap0901
    {

        public static void Main()
        {
            // step 1: creation of a document-object
            Document document = new Document();

            try
            {
                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file
                PdfWriter.getInstance(document, new FileStream("Chap0901.pdf", FileMode.Create));

                // step 3: we open the document
                document.Open();

                // step 4: we Add content to the document
                BaseFont bfHei = BaseFont.createFont(@"c:\Windows\fonts\SIMHEI.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                Font font = new Font(bfHei, 32);
                String text = "这是黑体字测试！";
                document.Add(new Paragraph(text, font));

                BaseFont bfSun = BaseFont.createFont(@"c:\Windows\fonts\SIMSUN.TTC,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                font = new Font(bfSun, 16);
                text = "这是字体集合中的新宋体测试！";
                document.Add(new Paragraph(text, font));
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

            System.Diagnostics.Process.Start("Chap0901.pdf");
        }
    }

}
