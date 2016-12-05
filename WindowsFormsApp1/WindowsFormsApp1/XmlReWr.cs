using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace PaSaver
{
    [Serializable]
    public class XmlReWr : IXmlSerializable
    {
        private List<DataTable> pages = new List<DataTable>();
        public List<DataTable> Pages
        {
            get { return pages; }
            set {; }
        }
        private string key1, key2;
        private string path;
        public string GetPath
        {
            get { return path; }
            set {; }
        }
        public XmlReWr( string path, string key1, string key2, List<DataTable> tp = null)
        {
            this.key1 = key1;
            this.key2 = key2;
            pages = tp;
            this.path = path;
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Tabs");
            WriteTabXml(writer,this.pages);
            writer.WriteValue(true);
            writer.WriteEndElement();

        }
        private void WriteTabXml(XmlWriter writer, List<DataTable> pages)
        {
            foreach(DataTable page in pages)
            {
                writer.WriteStartElement("Tab");
                writer.WriteValue(page.Type);
                WriteRowXml(writer, page);
                writer.WriteEndElement();
            }
        }
        private void WriteRowXml(XmlWriter writer, DataTable dt)
        {
            foreach (DataGridViewRow row in dt.Data.Rows)
            {
                writer.WriteStartElement("Row");
                string Row = "";
                int i = 0;
                foreach (string a in ((Row)row.Tag).ArrayList.ToArray())
                {
                    if (i == 0)
                    {
                        Row = a + Row;
                    }
                    else
                    {
                        Row = a + "||" + Row;
                    }
                    i++;
                }
                writer.WriteValue(Row);
                writer.WriteEndElement();
            }
        }
        public void ReadXml(XmlReader reader)
        {

        }
        public XmlSchema GetSchema()
        {
            return null;
        }
    }
}
