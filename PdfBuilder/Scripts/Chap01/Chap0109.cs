using System;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Learn.Chap01
{
    public class Chap0109
    {
        public static void Main()
        {
            Console.WriteLine("Chapter 1 example 9: encryption 40 bits");

            Document document = new Document(PageSize.A4, 50, 50, 50, 50);
            try
            {
                PdfWriter writer = PdfWriter.getInstance(document, new FileStream("Chap0109.pdf", FileMode.Create));
                writer.setEncryption(PdfWriter.STRENGTH40BITS, null, null, PdfWriter.AllowCopy);
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

            System.Diagnostics.Process.Start("Chap0109.pdf");
        }
    }
}