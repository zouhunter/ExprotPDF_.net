using System;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Learn.Chap01
{
    public class Chap0110
    {

        public static void Main()
        {
            Console.WriteLine("Chapter 1 example 10: encryption 128 bits");

            Document document = new Document(PageSize.A4, 50, 50, 50, 50);
            try
            {
                PdfWriter writer = PdfWriter.getInstance(document, new FileStream("Chap0110.pdf", FileMode.Create));
                writer.setEncryption(PdfWriter.STRENGTH128BITS, "userpass", "ownerpass", PdfWriter.AllowCopy | PdfWriter.AllowPrinting);
                document.Open();
                document.Add(new Paragraph("This document is Top Secret!"));
                document.Close();
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

            System.Diagnostics.Process.Start("Chap0110.pdf");
        }
    }
}