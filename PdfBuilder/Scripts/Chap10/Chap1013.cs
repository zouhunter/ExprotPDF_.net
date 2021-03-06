﻿using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Learn.Chap10
{
    public class Chap1013
    {
        public static void Main()
        {

            Console.WriteLine("Chapter 10 Example 13: Spot Color");

            // step 1: creation of a document-object
            Document document = new Document();
            try
            {

                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file
                PdfWriter writer = PdfWriter.getInstance(document, new FileStream("Chap1013.pdf", FileMode.Create));
                BaseFont bf = BaseFont.createFont("Helvetica", "winansi", BaseFont.NOT_EMBEDDED);

                // step 3: we open the document
                document.Open();

                // step 4: we add some content
                PdfContentByte cb = writer.DirectContent;

                // Note: I made up these names unless someone give me a PANTONE swatch as gift (phillip@formstar.com)
                PdfSpotColor spc_cmyk = new PdfSpotColor("PANTONE 280 CV", 0.25f, new CMYKColor(0.9f, .2f, .3f, .1f));
                PdfSpotColor spc_rgb = new PdfSpotColor("PANTONE 147", 0.9f, new Color(114, 94, 38));
                PdfSpotColor spc_g = new PdfSpotColor("PANTONE 100 CV", 0.5f, new GrayColor(0.9f));

                // Stroke a rectangle with CMYK alternate
                cb.setColorStroke(spc_cmyk, .5f);
                cb.LineWidth = 10f;
                // draw a rectangle
                cb.rectangle(100, 700, 100, 100);
                // add the diagonal
                cb.moveTo(100, 700);
                cb.lineTo(200, 800);
                // stroke the lines
                cb.stroke();

                // Fill a rectangle with CMYK alternate
                cb.setColorFill(spc_cmyk, spc_cmyk.Tint);
                cb.rectangle(250, 700, 100, 100);
                cb.fill();

                // Stroke a circle with RGB alternate
                cb.setColorStroke(spc_rgb, spc_rgb.Tint);
                cb.LineWidth = 5f;
                cb.circle(150f, 500f, 100f);
                cb.stroke();

                // Fill the circle with RGB alternate
                cb.setColorFill(spc_rgb, spc_rgb.Tint);
                cb.circle(150f, 500f, 50f);
                cb.fill();

                // example with colorfill
                cb.setColorFill(spc_g, spc_g.Tint);
                cb.moveTo(100f, 200f);
                cb.lineTo(200f, 250f);
                cb.lineTo(400f, 150f);
                cb.fill();
                document.newPage();
                String text = "Some text to show";
                document.Add(new Paragraph(text, FontFactory.getFont(FontFactory.HELVETICA, 24, Font.NORMAL, new SpotColor(spc_cmyk))));
                document.Add(new Paragraph(text, FontFactory.getFont(FontFactory.HELVETICA, 24, Font.NORMAL, new SpotColor(spc_cmyk, 0.5f))));

                // example with template
                PdfTemplate t = cb.createTemplate(500f, 500f);
                // Stroke a rectangle with CMYK alternate
                t.ColorStroke = new SpotColor(spc_cmyk, .5f);
                t.LineWidth = 10f;
                // draw a rectangle
                t.rectangle(100, 10, 100, 100);
                // add the diagonal
                t.moveTo(100, 10);
                t.lineTo(200, 100);
                // stroke the lines
                t.stroke();

                // Fill a rectangle with CMYK alternate
                t.setColorFill(spc_g, spc_g.Tint);
                t.rectangle(100, 125, 100, 100);
                t.fill();
                t.beginText();
                t.setFontAndSize(bf, 20f);
                t.setTextMatrix(1f, 0f, 0f, 1f, 10f, 10f);
                t.showText("Template text upside down");
                t.endText();
                t.rectangle(0, 0, 499, 499);
                t.stroke();
                cb.addTemplate(t, -1.0f, 0.00f, 0.00f, -1.0f, 550f, 550f);
            }
            catch (Exception de)
            {
                Console.Error.WriteLine(de.Message);
                Console.Error.WriteLine(de.StackTrace);
            }

            // step 5: we close the document
            document.Close();

            System.Diagnostics.Process.Start("Chap1013.pdf");
        }
    }


}