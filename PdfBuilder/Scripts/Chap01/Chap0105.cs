//using System;
//using System.Collections;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Web;
//using System.Web.SessionState;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.HtmlControls;
//using System.IO;

//using iTextSharp.text;
//using iTextSharp.text.pdf;

///// <summary>
///// Summary description for Chap0501.
///// </summary>
//public class Chap0501 : System.Web.UI.Page
//{
//    private void Page_Load(object sender, System.EventArgs e)
//    {
//        // step 1
//        // need to write to memory first due to IE wanting
//        // to know the length of the pdf beforehand
//        MemoryStream m = new MemoryStream();
//        Document document = new Document();
//        try
//        {
//            // step 2: we set the ContentType and create an instance of the Writer
//            Response.ContentType = "application/pdf";
//            PdfWriter.getInstance(document, m);

//            // step 3
//            document.Open();

//            // step 4
//            document.Add(new Paragraph(DateTime.Now.ToString()));
//        }
//        catch (DocumentException ex)
//        {
//            Console.Error.WriteLine(ex.StackTrace);
//            Console.Error.WriteLine(ex.Message);
//        }
//        // step 5: Close document
//        document.Close();

//        // step 6: Write pdf bytes to outputstream
//        Response.OutputStream.Write(m.GetBuffer(), 0, m.GetBuffer().Length);
//        Response.OutputStream.Flush();
//        Response.OutputStream.Close();
//    }

//    #region Web Form Designer generated code
//    override protected void OnInit(EventArgs e)
//    {
//        //
//        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
//        //
//        InitializeComponent();
//        base.OnInit(e);
//    }

//    /// <summary>
//    /// Required method for Designer support - do not modify
//    /// the contents of this method with the code editor.
//    /// </summary>
//    private void InitializeComponent()
//    {
//        this.Load += new System.EventHandler(this.Page_Load);
//    }
//    #endregion
//}
