using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.rtf;

namespace Learn.Chap08
{

    public class Chap0801
    {

        public static void Main()
        {

            Console.WriteLine("Chapter 8 example 1: RtfWriter");

            // step 1: creation of a document-object
            Document document = new Document();

            try
            {

                // step 2:
                // we create a writer that listens to the document
                // and directs a RTF-stream to a file

                RtfWriter.getInstance(document, new FileStream("Chap0801.rtf", FileMode.Create));

                // step 3: we open the document
                document.Open();

                // step 4: we add a paragraph to the document
                document.Add(new Paragraph("Hello World"));

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


            System.Diagnostics.Process.Start("Chap0801.rtf");
        }
    }

}