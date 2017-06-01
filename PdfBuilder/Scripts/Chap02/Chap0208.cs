using System;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Learn.Chap02
{
    public class Chap0208 : ISplitCharacter
    {

        public static void Main()
        {

            Console.WriteLine("Chapter 2 example 8: split character");

            // step 1: creation of a document-object
            Document document = new Document();

            try
            {

                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file
                /*PdfWriter writer = */
                PdfWriter.getInstance(document, new FileStream("Chap0208.pdf", FileMode.Create));

                // step 3: we Open the document
                document.Open();

                // step 4:
                // we Add some content
                String text = "Some.text.to.show.the.splitting.action.of.the.interface.";
                Chunk ck = new Chunk(text, FontFactory.getFont(FontFactory.HELVETICA, 24));
                Paragraph p = new Paragraph(24, ck);
                document.Add(new Paragraph("Normal split."));
                document.Add(p);


                ck = new Chunk(text, FontFactory.getFont(FontFactory.HELVETICA, 24));
                Chap0208 split = new Chap0208();
                ck.setSplitCharacter(split);
                p = new Paragraph(24, ck);
                document.Add(new Paragraph("The dot '.' is the split character."));
                document.Add(p);

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

            System.Diagnostics.Process.Start("Chap0208.pdf");
        }



        /**
             * Returns <CODE>true</CODE> if the character can split a line.
             * @param c the character
             * @return <CODE>true</CODE> if the character can split a line
             */
        public bool isSplitCharacter(char c)
        {
            return (c == '.');
        }
    }
}