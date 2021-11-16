using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace QLHV.Handling
{
     public class Field
     {
        public static List<Field> listFields;
        public int id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        public string type { get; set; }

        public string value { get; set; }

        [StringLength(50)]
        public string templatecode { get; set; }

        public int? DocumentId { get; set; }

        public int height { get; set; }
        public int width { get; set; }
        public int upper { get; set; }
        public int bold { get; set; }
        public int italic { get; set; }
        public int center { get; set; }

        public static List<Field> GetFields(int id)
        {
            var path = HttpContext.Current.Server.MapPath(@"~/Data/XML/Fields.xml");
            XElement stXml = XElement.Load(path);
            var a = stXml.Descendants("field").ToList();
            var fields = new List<Field>();
            foreach (var st in a)
            {
                var field = new Field();
                field.id = Convert.ToInt32(st.Attribute("id").Value);
                field.type = Convert.ToString(st.Elements("type").First().Value);
                field.name = Convert.ToString(st.Elements("name").First().Value);
                field.templatecode = Convert.ToString(st.Elements("templatecode").First().Value);
                field.DocumentId = Convert.ToInt32(st.Elements("DocumentId").First().Value);
                field.height = Convert.ToInt32(st.Elements("height").First().Value);
                field.width = Convert.ToInt32(st.Elements("width").First().Value);
                field.upper = Convert.ToInt32(st.Elements("upper").First().Value);
                field.bold = Convert.ToInt32(st.Elements("bold").First().Value);
                field.italic = Convert.ToInt32(st.Elements("italic").First().Value);
                field.center = Convert.ToInt32(st.Elements("center").First().Value);
                field.value = Convert.ToString(st.Elements("value").First().Value);
                if (field.DocumentId == id) fields.Add(field);
            }
            listFields = fields;
            return fields;
        }

        public static List<Field> List(int id)
        {
            List<Field> list = GetFields(id).ToList();
            return list;
        }
    }
}