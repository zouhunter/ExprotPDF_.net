﻿using System;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Learn.Chap01
{
    public class Chap0103
    {
        public static void Main()
        {
            Console.WriteLine("Chapter 1 example 3: PageSize");

            // step 1: creation of a document-object
            Document document = new Document(PageSize.A4.rotate());

            try
            {
                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file

                PdfWriter.getInstance(document, new FileStream("Chap0103.pdf", FileMode.Create));

                // step 3: we open the document
                document.Open();

                // step 4: we add some phrases to the document
                for (int i = 0; i < 20; i++)
                {
                    document.Add(new Phrase("Hello World, Hello Sun, Hello Moon, Hello Stars, Hello Sea, Hello Land, Hello People. "));
                }

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

            System.Diagnostics.Process.Start("Chap0103.pdf");
        }
    }
}