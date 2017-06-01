﻿using System;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Learn.Chap02
{
    public class Chap0207
{

    public static void Main()
    {
        Console.WriteLine("Chapter 2 example 7: font propagation");

        // step 1: creation of a document-object
        Document document = new Document();

        try
        {
            // step 2:
            // we create a writer that listens to the document
            // and directs a PDF-stream to a file
            /*PdfWriter writer = */PdfWriter.getInstance(document, new FileStream("Chap0207.pdf", FileMode.Create));

            // step 3: we open the document
            document.Open();

            // step 4:
            // we Add some content
            Phrase myPhrase = new Phrase("Hello 1! ", new Font(Font.TIMES_NEW_ROMAN, 8, Font.BOLD));
            myPhrase.Add(new Phrase("some other font ", new Font(Font.HELVETICA, 8)));
            myPhrase.Add(new Phrase("This is the end of the sentence.\n", new Font(Font.TIMES_NEW_ROMAN, 8, Font.ITALIC)));
            document.Add(myPhrase);

            myPhrase = new Phrase("Hello 1bis! ", FontFactory.getFont(FontFactory.TIMES_NEW_ROMAN, 8, Font.BOLD));
            myPhrase.Add(new Phrase("some other font ", FontFactory.getFont(FontFactory.HELVETICA, 8)));
            myPhrase.Add(new Phrase("This is the end of the sentence.\n", FontFactory.getFont(FontFactory.TIMES_NEW_ROMAN, 8, Font.ITALIC)));
            document.Add(myPhrase);

            Paragraph myParagraph = new Paragraph("Hello 2! ", new Font(Font.TIMES_NEW_ROMAN, 8, Font.BOLD));
            myParagraph.Add(new Paragraph("This is the end of the sentence.", new Font(Font.TIMES_NEW_ROMAN, 8, Font.ITALIC)));
            document.Add(myParagraph);

            myParagraph = new Paragraph(12);
            myParagraph.Add(new Paragraph("Hello 3! ", new Font(Font.TIMES_NEW_ROMAN, 8, Font.BOLD)));
            myParagraph.Add(new Paragraph("This is the end of the sentence.", new Font(Font.TIMES_NEW_ROMAN, 8, Font.ITALIC)));
            document.Add(myParagraph);

            myPhrase = new Phrase(12);
            myPhrase.Add(new Phrase("Hello 4! ", new Font(Font.TIMES_NEW_ROMAN, 8, Font.BOLD)));
            myPhrase.Add(new Phrase("This is the end of the sentence.\n", new Font(Font.TIMES_NEW_ROMAN, 8, Font.ITALIC)));
            document.Add(myPhrase);
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

            System.Diagnostics.Process.Start("Chap0207.pdf");
        }
    }
}

