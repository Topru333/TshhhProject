using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Xml.Serialization;
using System.Xml;

namespace PaSaver
{
    public partial class Form1 : Form
    {
        private XmlReWr xw,xr;
        public TabControl ThisTabs
        {
            get { return Tabs; }
            set {; }
        }
        private string path,keytext;
        private string Path
        {
            get { return path; }
            set { path = value;saveToolStripMenuItem.Enabled = true; }
        }
        private ArrayList k;
        private ArrayList Keys
        {
            get
            {
                k = new ArrayList();
                foreach(ToolStripTextBox tb in KeyMenu.DropDownItems)
                {
                    if (tb.Text != keytext && tb.Text != " " && tb.Text != "")
                    {
                        k.Add(tb.Text.ToString());
                    }
                }
                return k;
            }
            set {; }
        }
        private bool needsave = false;
        /// <summary>
        /// Параметр ответа - Нужно ли сохранение или создание для файла
        /// </summary>
        public bool NeedSave
        {
            get { return needsave; }
            set
            {
                if(value == true)
                {
                    if (toolStrip1.Items[0].Text[toolStrip1.Items[0].Text.Length-1]!='*')
                    {
                        toolStrip1.Items[0].Text += '*';
                        ((ToolStripDropDownButton)toolStrip1.Items[0]).DropDownItems[2].Text += '*';
                    }
                }
                else
                {
                    toolStrip1.Items[0].Text = toolStrip1.Items[0].Text.Substring(0, toolStrip1.Items[0].Text.Length - 1);
                    ((ToolStripDropDownButton)toolStrip1.Items[0]).DropDownItems[2].Text = ((ToolStripDropDownButton)toolStrip1.Items[0]).DropDownItems[2].Text.Substring(0, ((ToolStripDropDownButton)toolStrip1.Items[0]).DropDownItems[2].Text.Length - 1);
                }
                needsave = value;
            }
        }
        public Form1()
        {
            InitializeComponent();
            keytext = "Write key here";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            KeyStart();
        }
        private void KeyStart()
        {
            Form4 DialogForm = new Form4();
            if (DialogForm.ShowDialog(this) == DialogResult.OK)
            {
                toolStripTextBox1.Text = DialogForm.KeyBox1.Text;
                toolStripTextBox2.Text = DialogForm.KeyBox2.Text;
                toolStripTextBox3.Text = DialogForm.KeyBox3.Text;
                toolStripTextBox4.Text = DialogForm.KeyBox4.Text;
                toolStripTextBox5.Text = DialogForm.KeyBox5.Text;
            }
            else { this.Close(); }
            
        }
        /// <summary>
        /// Кнопка добавления вкладки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTab_Click(object sender, EventArgs e)
        { 
            string sab = ShowAddBox();
            if (sab != "")
            {
                DataTable dt = new DataTable(this,sab);
                ThisTabs.Controls.Add(dt.Page);
                NeedSave = true;
            }
            else
            {
                MessageBox.Show("Write name!");
            }
            
        }
        /// <summary>
        /// Кнопка удаления вкладки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteTab_Click(object sender, EventArgs e)
        {
            if (ThisTabs.TabPages.Count > 0)
            {
                ThisTabs.TabPages.RemoveAt(ThisTabs.SelectedIndex);
                NeedSave = true;
            }
        }
        /// <summary>
        /// Кнопка для сохранения XML файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStrip_Click(object sender, EventArgs e)
        {
            if (Path != "")
            {
                if (Keys.Count > 0)
                {
                    List<DataTable> Pages = new List<DataTable>();
                    foreach (TabPage page in ThisTabs.TabPages)
                    {
                        Pages.Add((DataTable)page.Tag);
                    }
                    this.xw = new XmlReWr(this,Path, Keys, Pages);
                    using (XmlWriter writer = XmlWriter.Create(Path, new XmlWriterSettings { ConformanceLevel = ConformanceLevel.Document, Encoding = Encoding.Unicode }))
                    {
                        xw.WriteXml(writer);
                    }
                    ShowNotify("Xml file created");
                    NeedSave = false;
                }
                else { MessageBox.Show("Please write ur keys for encoding information!", "Key error"); }
            }
        }
        /// <summary>
        /// Кнопка для создания XML Файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void СreateXmlToolStrip_Click(object sender, EventArgs e)
        {
            if (Keys.Count>0)
            {
                List<DataTable> Pages = new List<DataTable>();
                foreach (TabPage page in ThisTabs.TabPages)
                {
                    Pages.Add((DataTable)page.Tag);
                }
                OpenDirectory.Description = "Choice folder";
                if (OpenDirectory.ShowDialog() == DialogResult.OK)
                {
                    Path = OpenDirectory.SelectedPath;
                }
                else
                { return; }
                Path = Path + "\\PaSaver.xml";
                this.xw = new XmlReWr(this,Path, Keys, Pages);
                using (XmlWriter writer = XmlWriter.Create(Path, new XmlWriterSettings { ConformanceLevel = ConformanceLevel.Document, Encoding = Encoding.Unicode }))
                {
                    xw.WriteXml(writer);
                }
                ShowNotify("Xml file created");
                NeedSave = false;
            }
            else { MessageBox.Show("Please write ur keys for encoding information!", "Key error"); }
        }
        /// <summary>
        /// Кнопка для открытия XML файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenXmlToolStrip_Click(object sender, EventArgs e)
        {
            if (Keys.Count > 0)
            {
                if (OpenXml.ShowDialog() == DialogResult.OK)
                {
                    Path = OpenXml.FileName;
                }
                this.xr = new XmlReWr(this,Path, Keys);
                using (XmlReader reader = XmlReader.Create(Path))
                {
                    xr.ReadXml(reader);
                }
                foreach(DataTable dt in xr.Pages)
                {
                    ThisTabs.TabPages.Add(dt.Page);
                }
            }
            else { MessageBox.Show("Please write ur keys for decoding information!","Key error"); }
        }
        /// <summary>
        /// Метод для вывода сообщений
        /// </summary>
        /// <param name="text">Текст сообщения</param>
        /// <param name="tip">Размер времени прибытия сообщения на экране</param>
        private void ShowNotify(string text, int tip = 1000)
        {
            notifyIcon1.BalloonTipText = text;
            notifyIcon1.ShowBalloonTip(tip);
        }
        /// <summary>
        /// Всплывание окна для ввода данных о элементе и последующего создания на конкретной вкладке(фокус)
        /// </summary>
        /// <returns> Созданный объект класса ряд </returns>
        public Row ShowAddElementBox()
        {
            Form3 DialogForm = new Form3();
            if (DialogForm.ShowDialog(this) == DialogResult.OK && DialogForm.Login_TextBox.Text != "" && DialogForm.Password_TextBox.Text != "")
            {
                return (new Row(DialogForm.Login_TextBox.Text, DialogForm.Password_TextBox.Text, DialogForm.Info_TextBox.Text));
            }
            else return new Row();
        }
        /// <summary>
        /// Всплывание окна для ввода названия новой вкладки
        /// </summary>
        /// <returns>Имя вкладки</returns>
        public string ShowAddBox(string value = "")
        {
            Form2 DialogForm = new Form2();
            DialogForm.Name_TextBox.Text = value;
            if (DialogForm.ShowDialog(this) == DialogResult.OK)
            {
                return DialogForm.Name_TextBox.Text;
            }
            else
            {
                return value;
            }
        }
    }
}
