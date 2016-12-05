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
        private XmlReWr xrw;
        private string Path,keytext;
        private bool needsave = false;
        /// <summary>
        /// Параметр ответа - Нужно ли сохранение или создание для файла
        /// </summary>
        private bool NeedSave
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
            Key1.Text = keytext;
            Key2.Text = keytext;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Кнопка добавления вкладки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTab_Click(object sender, EventArgs e)
        {
            DataTab dt = new DataTable(ShowAddBox());
            TabTypes.Controls.Add(dt.Page);
            NeedSave = true;
        }
        /// <summary>
        /// Кнопка удаления вкладки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteTab_Click(object sender, EventArgs e)
        {
            TabTypes.TabPages.RemoveAt(TabTypes.SelectedIndex);
            NeedSave = true;
        }
        /// <summary>
        /// Всплывание окна для ввода названия новой вкладки
        /// </summary>
        /// <returns>Имя вкладки</returns>
        private string ShowAddBox(string value = "")
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
        /// <summary>
        /// Всплывание окна для ввода данных о элементе и последующего создания на конкретной вкладке(фокус)
        /// </summary>
        /// <returns> Созданный объект класса ряд </returns>
        private Row ShowAddElementBox()
        {
            if(TabTypes.TabCount > 0)
            {
                Form3 DialogForm = new Form3();
                if (DialogForm.ShowDialog(this) == DialogResult.OK && DialogForm.Login_TextBox.Text != "" && DialogForm.Password_TextBox.Text != "")
                {
                    return (new Row(DialogForm.Login_TextBox.Text, DialogForm.Password_TextBox.Text, DialogForm.Info_TextBox.Text));
                }
                else return new Row();
            }
            else
            {
                MessageBox.Show("Need to add tab first!", "Tab error");
                return null;
            }
        }
        /// <summary>
        /// Кнопка добавления элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddElement_Click(object sender, EventArgs e)
        {
            if (TabTypes.TabCount > 0)
            {
                Row r = ShowAddElementBox();
                if (r.Login != "" && r.Password != "")
                {
                    ((DataTable)TabTypes.SelectedTab.Tag).AddRowToData(r);
                }
                NeedSave = true;
            }
            else
            {
                MessageBox.Show("Need to add tab first!", "Tab error");
            }
        }
        /// <summary>
        /// Кнопка удаления элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteElement_Click(object sender, EventArgs e)
        {
            if (TabTypes.TabCount > 0&& ((DataTable)TabTypes.SelectedTab.Tag).Data.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in ((DataTable)TabTypes.SelectedTab.Tag).Data.SelectedCells)
                {
                    ((DataTable)TabTypes.SelectedTab.Tag).DeleteRowFromData(cell.RowIndex);
                }
            }
        }
        /// <summary>
        /// Кнопка для сохранения XML файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStrip_Click(object sender, EventArgs e)
        {
            NeedSave = false;
        }
        /// <summary>
        /// Кнопка для изменения элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FixElement_Click(object sender, EventArgs e)
        {
            if (TabTypes.TabCount > 0 && ((DataTable)TabTypes.SelectedTab.Tag).Data.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in ((DataTable)TabTypes.SelectedTab.Tag).Data.SelectedCells)
                {
                    cell.Value = ShowAddBox(cell.Value.ToString());
                    if (cell.ColumnIndex == 0)
                    {
                        ((Row)((DataTable)TabTypes.SelectedTab.Tag).Data.Rows[cell.RowIndex].Tag).Login = cell.Value.ToString();
                    }
                    else if (cell.ColumnIndex == 1)
                    {
                        ((Row)((DataTable)TabTypes.SelectedTab.Tag).Data.Rows[cell.RowIndex].Tag).Password = cell.Value.ToString();
                    }
                    else if (cell.ColumnIndex == 2)
                    {
                        ((Row)((DataTable)TabTypes.SelectedTab.Tag).Data.Rows[cell.RowIndex].Tag).Info = cell.Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Wot");
                    }
                }
                NeedSave = true;
            }
        }
        /// <summary>
        /// Кнопка для копирования элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyToolStrip_Click(object sender, EventArgs e)
        {
            if (TabTypes.TabCount > 0)
            {
                if (((DataTable)TabTypes.SelectedTab.Tag).Data.SelectedCells.Count > 1)
                {
                    string text = "|";
                    foreach (DataGridViewCell cell in ((DataTable)TabTypes.SelectedTab.Tag).Data.SelectedCells)
                    {
                        if (cell.ColumnIndex == 0)
                        {
                            text = "|Login: " + cell.Value.ToString() + " " + text;
                        }
                        if (cell.ColumnIndex == 1)
                        {
                            text = "|Password: " + cell.Value.ToString() + " " + text;
                        }
                        if (cell.ColumnIndex == 2)
                        {
                            text = "|Info: " + cell.Value.ToString() + " " + text;
                        }
                    }
                    Clipboard.SetText(text);
                }
                else if (((DataTable)TabTypes.SelectedTab.Tag).Data.SelectedCells.Count == 1)
                {
                    Clipboard.SetText(((DataTable)TabTypes.SelectedTab.Tag).Data.SelectedCells[0].Value.ToString());
                }
                else { MessageBox.Show("Choice elements to copy"); }
            }
        }
        /// <summary>
        /// Кнопка для создания XML Файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void СreateXmlToolStrip_Click(object sender, EventArgs e)
        {
            if (Key1.Text != keytext && Key2.Text != keytext)
            {
                List<DataTable> List = new List<DataTable>();
                foreach (TabPage page in TabTypes.TabPages)
                {
                    List.Add((DataTable)page.Tag);
                }

                if (OpenDirectory.ShowDialog() == DialogResult.OK)
                {
                    Path = OpenDirectory.InitialDirectory;

                }
                else
                { return; }

                this.xrw = new XmlReWr(Path + "\\PaSaver.xml", Key1.Text, Key1.Text, List);
                using (XmlWriter writer = XmlWriter.Create(Path + "\\PaSaver.xml"))
                {
                    XmlSerializer xmlserialize = new XmlSerializer(typeof(XmlReWr));
                    xrw.WriteXml(writer);
                }
                ShowNotify("Xml file created");
            }
            else { MessageBox.Show("Write keys!","Key error"); }
        }
        /// <summary>
        /// Кнопка для открытия XML файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenXmlToolStrip_Click(object sender, EventArgs e)
        {
            if (Key1.Text != keytext && Key2.Text != keytext)
            {
                if (OpenXml.ShowDialog() == DialogResult.OK)
                {
                    Path = OpenXml.FileName;
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
    }
}
