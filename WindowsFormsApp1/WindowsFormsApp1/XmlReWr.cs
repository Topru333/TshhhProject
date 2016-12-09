using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Collections;


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
        VigenerCoder vc;
        private Form1 F1;
        private string path;
        public string GetPath
        {
            get { return path; }
            set {; }
        }
        public XmlReWr( Form1 f1,string path, ArrayList keys)
        {
            F1 = f1;
            vc = new VigenerCoder(keys);
            this.path = path;
        }
        public XmlReWr( Form1 f1, string path, ArrayList keys,List<DataTable> tabpages)
        {
            F1 = f1;
            vc = new VigenerCoder(keys);
            pages = tabpages;
            this.path = path;
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartDocument(true);
            writer.WriteStartElement("Tabs");
            writer.WriteAttributeString("Value", Pages.Count.ToString());
            foreach(DataTable Page in Pages)
            {
                writer.WriteStartElement("Tab");
                writer.WriteAttributeString("Type", vc.MultiEncode(Page.Type));

                writer.WriteStartElement("Rows");
                writer.WriteAttributeString("Value", Page.Data.RowCount.ToString());
                foreach (DataGridViewRow row in Page.Data.Rows)
                {
                    writer.WriteStartElement("Row");

                    writer.WriteStartElement("Login");
                    writer.WriteString(vc.MultiEncode(((Row)row.Tag).Login));
                    writer.WriteEndElement();

                    writer.WriteStartElement("Password");
                    writer.WriteString(vc.MultiEncode(((Row)row.Tag).Password));
                    writer.WriteEndElement();

                    writer.WriteStartElement("Info");
                    writer.WriteString(vc.MultiEncode(((Row)row.Tag).Info));
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("Tabs");
            while (reader.Name == "Tab")
            {
                DataTable dt = new DataTable(F1, vc.MultiDecode(reader.GetAttribute("Type")));
                Pages.Add(dt);

                reader.ReadStartElement("Tab");

                reader.ReadStartElement("Rows");
                while (reader.Name == "Row")
                {
                    reader.ReadStartElement("Row");

                    reader.ReadStartElement("Login");
                    string Login = vc.MultiDecode(reader.ReadContentAsString());
                    reader.ReadEndElement();

                    reader.ReadStartElement("Password");
                    string Password = vc.MultiDecode(reader.ReadContentAsString());
                    reader.ReadEndElement();

                    reader.ReadStartElement("Info");
                    string Info = vc.MultiDecode(reader.ReadContentAsString());
                    reader.ReadEndElement();

                    dt.AddRowToData(new Row(Login, Password, Info));

                    reader.ReadEndElement();
                }
                reader.ReadEndElement();
                reader.ReadEndElement();
            }
            reader.ReadEndElement();
        }
        public XmlSchema GetSchema()
        {
            return null;
        }
    }
}
