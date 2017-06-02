using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Learn.Chap11
{
    public class Chap1101
    {

        public static void Main()
        {

            Console.WriteLine("Chapter 11 example 1: local goto");

            // step 1: creation of a document-object
            Document document = new Document();

            try
            {

                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file
                PdfWriter writer = PdfWriter.getInstance(document, new FileStream("Chap1101.pdf", FileMode.Create));

                // step 3: we open the document
                document.Open();

                // step 4: we add some content

                Paragraph p1 = new Paragraph("We will do something special with this paragraph. If you click on ", FontFactory.getFont(FontFactory.HELVETICA, 12));
                p1.Add(new Chunk("this word", FontFactory.getFont(FontFactory.HELVETICA, 12, Font.NORMAL, new Color(0, 0, 255))).setLocalGoto("test"));
                p1.Add(" you will automatically jump to another location in this document.");
                Paragraph p2 = new Paragraph("blah, blah, blah");
                Paragraph p3 = new Paragraph("This paragraph contains a local ");
                p3.Add(new Chunk("local destination", FontFactory.getFont(FontFactory.HELVETICA, 12, Font.NORMAL, new Color(0, 255, 0))).setLocalDestination("test"));
                document.Add(p1);
                document.Add(p2);
                document.Add(p2);
                document.Add(p2);
                document.Add(p2);
                document.Add(p2);
                document.Add(p2);
                document.Add(p2);
                document.Add(p3);
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

            System.Diagnostics.Process.Start("Chap1101.pdf");
        }
    }


}