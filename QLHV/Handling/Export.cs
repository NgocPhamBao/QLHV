using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLHV.Handling
{
     public class Export
     {
          public void genToFile(string inputPath, List<string> str_list)
          {
               //var path = HttpContext.Current.Server.MapPath(@"~/Data/XML/Fields.xml");
               string dataDir = HttpContext.Current.Server.MapPath(@"~/Data/Word/");

               Aspose.Words.Document doc = new Aspose.Words.Document(dataDir + inputPath);

               doc.Save(dataDir + "html/Aspose_DocToHTML.html", SaveFormat.Html); //Save the document in HTML format.

               var list_fields = doc.MailMerge.GetFieldNames().ToArray();
               //String[] field_array = field_list.ToArray();
               //field_array[field_array.Length-1] = field_array[field_array.Length-1].Replace("\r\n", string.Empty);
               doc.MailMerge.UseNonMergeFields = true;


               // Fill the fields in the document with user data.
               doc.MailMerge.Execute(list_fields, str_list.ToArray());

               dataDir = dataDir + ".docx";
               // Send the document in Word format to the client browser with an option to save to disk or open inside the current browser.
               doc.Save(@dataDir);

               string time = DateTime.Now.ToString();


               System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
               response.ClearContent();
               response.Clear();
               response.ContentType = "Application/msword";
               response.AddHeader("Content-Disposition", "attachment; filename=" + time + "_" + @inputPath + ";");
               response.TransmitFile(dataDir);
               response.Flush();
               response.End();
               //Microsoft.Office.Interop.Word.Document document = ap.Documents.Open(@dataDir);
               //Process.Start(@dataDir);
          }
     }
}