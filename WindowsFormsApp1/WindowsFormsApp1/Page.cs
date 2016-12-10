using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace PaSaver
{
    /// <summary>
    /// Класс для вкладок TabControl
    /// </summary>
    public class DataTab
    {
        protected Form1 F1;
        protected string type;
        public string Type
        {
            get { return type; }
            set {; }
        }
        protected TabPage page = new TabPage();
        public TabPage Page
        {
            get { return page; }
            set {; }
        }
        public DataTab(Form1 f1,string type = ""){ F1 = f1; this.type = type;page.Text = type;page.Name = type; }
    }
    /// <summary>
    /// Сабкласс вкладки , DataGridViewControl
    /// </summary>
    public class DataTable : DataTab
    {
        private DataGridView data = new DataGridView();
        public DataGridView Data
        {
            get { return data; }
            set {; }
        }
        public DataTable(Form1 f1, string type = "") :base(f1,type)
        {
            
            this.AddColumnsAndSettings(data);
            AddDataToPage(data);
            AddEvents();
            
        }


        private void AddEvents()
        {
            this.Data.CellMouseClick += this.Dgv_Cell_MouseClick;
            this.Data.MouseClick += this.Dgv_Gray_Space_MouseClick;
        }
        #region Bonus menu
        private void Dgv_Cell_MouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();

                m.MenuItems.Add(new MenuItem("Fix", FixCell_Click));
                m.MenuItems.Add(new MenuItem("Copy", CopyCell_Click));
                m.MenuItems.Add(new MenuItem("Delete", DeleteRow_Click));
                MenuItem[] moveto = new MenuItem[F1.ThisTabs.TabPages.Count];
                int i = 0;
                foreach (TabPage page in F1.ThisTabs.TabPages)
                {
                    moveto[i] = new MenuItem(page.Text, MoveRow_Click);
                    moveto[i].Tag = page.Tag;
                    i++;
                }
                m.MenuItems.Add(new MenuItem("Move to", moveto));
                if (((DataGridView)sender).SelectedCells.Count == 1)
                {
                    if (((DataGridView)sender).SelectedCells.Count > 0)
                    {
                        ((DataGridView)sender).SelectedCells[0].Selected = false;
                    }
                    ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Selected = true;
                }
                m.Show(((DataGridView)sender), new Point(e.X, e.Y));
            }
        }
        private void Dgv_Gray_Space_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (((DataGridView)sender).HitTest(e.X, e.Y).Type == DataGridViewHitTestType.None)
                {
                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Add", AddElement_Click));
                    m.MenuItems[0].Tag = ((DataGridView)sender).Tag;
                    m.Show(((DataGridView)sender), new Point(e.X, e.Y));
                }
            }
        }
        /// <summary>
        /// Кнопка для изменения элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FixCell_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in ((DataTable)F1.ThisTabs.SelectedTab.Tag).Data.SelectedCells)
            {
                cell.Value = F1.ShowAddBox(cell.Value.ToString());
                if (cell.ColumnIndex == 0)
                {
                    ((Row)((DataTable)F1.ThisTabs.SelectedTab.Tag).Data.Rows[cell.RowIndex].Tag).Login = cell.Value.ToString();
                }
                else if (cell.ColumnIndex == 1)
                {
                    ((Row)((DataTable)F1.ThisTabs.SelectedTab.Tag).Data.Rows[cell.RowIndex].Tag).Password = cell.Value.ToString();
                }
                else if (cell.ColumnIndex == 2)
                {
                    ((Row)((DataTable)F1.ThisTabs.SelectedTab.Tag).Data.Rows[cell.RowIndex].Tag).Info = cell.Value.ToString();
                }
                else
                {
                    MessageBox.Show("Wot");
                }
            }
            F1.NeedSave = true;
            
        }
        /// <summary>
        /// Кнопка для копирования элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyCell_Click(object sender, EventArgs e)
        {
            if (F1.ThisTabs.TabCount > 0)
            {
                if (((DataTable)F1.ThisTabs.SelectedTab.Tag).Data.SelectedCells.Count > 1)
                {
                    string text = "|";
                    foreach (DataGridViewCell cell in ((DataTable)F1.ThisTabs.SelectedTab.Tag).Data.SelectedCells)
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
                else if (((DataTable)F1.ThisTabs.SelectedTab.Tag).Data.SelectedCells.Count == 1)
                {
                    Clipboard.SetText(((DataTable)F1.ThisTabs.SelectedTab.Tag).Data.SelectedCells[0].Value.ToString());
                }
                else { MessageBox.Show("Choice elements to copy"); }
            }
        }
        /// <summary>
        /// Кнопка добавления элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddElement_Click(object sender, EventArgs e)
        {
            Row r = F1.ShowAddElementBox();
            if (r.Login != "" && r.Password != "")
            {
                ((DataTable)((MenuItem)sender).Tag).AddRowToData(r);
            }
            F1.NeedSave = true;

        }
        /// <summary>
        /// Кнопка удаления элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteRow_Click(object sender, EventArgs e)
        {
            if (((DataTable)F1.ThisTabs.SelectedTab.Tag).Data.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in ((DataTable)F1.ThisTabs.SelectedTab.Tag).Data.SelectedCells)
                {
                    ((DataTable)F1.ThisTabs.SelectedTab.Tag).DeleteRowFromData(cell.RowIndex);
                }
            }
        }
        /// <summary>
        /// Кнопка перемещения с ряда с одной вкладки на другую
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveRow_Click(object sender, EventArgs e)
        {
            if (((DataTable)F1.ThisTabs.SelectedTab.Tag).Data.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in ((DataTable)F1.ThisTabs.SelectedTab.Tag).Data.SelectedCells)
                {
                    ((DataTable)((MenuItem)sender).Tag).AddRowToData((Row)((DataTable)F1.ThisTabs.SelectedTab.Tag).Data.Rows[cell.RowIndex].Tag);
                    ((DataTable)F1.ThisTabs.SelectedTab.Tag).DeleteRowFromData(cell.RowIndex);
                }
            }
        }
        #endregion

        /// <summary>
        /// Настройка DataGridView Control
        /// </summary>
        /// <param name="DataTo">Настраеваемый объект</param>
        public void AddColumnsAndSettings(DataGridView DataTo)
        {
            if (DataTo.Columns.Count == 0)
            {
                var col1 = new DataGridViewTextBoxColumn();
                var col2 = new DataGridViewTextBoxColumn();
                var col3 = new DataGridViewTextBoxColumn();
                col1.ReadOnly = true;
                col2.ReadOnly = true;
                col3.ReadOnly = true;
                col1.HeaderText = "Login";
                col1.Name = "Login";
                col2.HeaderText = "Pass";
                col2.Name = "Pass";
                col3.HeaderText = "Info";
                col3.Name = "Info";
                DataTo.Columns.AddRange(new DataGridViewColumn[] { col1, col2, col3 });
            }
            DataSettings(DataTo);
        }
        private void DataSettings(DataGridView data)
        {
            foreach (DataGridViewColumn d in data.Columns)
            {
                d.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                d.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                d.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            data.Dock = DockStyle.Fill;
            data.AllowUserToResizeColumns = false;
            data.AllowUserToResizeRows = false;
            data.RowHeadersVisible = false;
            data.AllowUserToAddRows = false;
        }
        /// <summary>
        /// Добавление DataGridView на новую вкладку
        /// </summary>
        /// <param name="data">DataGridView control</param>
        private void AddDataToPage(DataGridView data)
        {
            page.Controls.Add(data);
            page.Tag = this;
            data.Tag = this;

        }
        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="r">Ряд на добавление</param>
        public void AddRowToData(Row r)
        {
            data.Rows.Add(r.ArrayList.ToArray());
            data.Rows[data.Rows.Count - 1].Tag = r;
        }
        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="index">Номер ряда</param>
        public void DeleteRowFromData(int index)
        {
            data.Rows.RemoveAt(index);
        }
    }
    /// <summary>
    /// Класс для рядов DataGridView
    /// </summary>
    public class Row
    {
        private ArrayList array = new ArrayList();
        private string login, password, info;
        public string Login
        {
            get { return this.login; }
            set { login = value; array[0] = value; }
        }
        public string Password
        {
            get { return this.password; }
            set { password = value;array[1] = value; }
        }
        public string Info
        {
            get { return this.info; }
            set { info = value; array[2] = value; }
        }
        public ArrayList ArrayList
        {
            get { return array; }
            set {; }
        }
        public Row( string login = "", string pass = "", string info = "")
        {
            this.login = login;
            this.password = pass;
            this.info = info;
            array.Add(login);
            array.Add(pass);
            array.Add(info);
        }
        public Row( ArrayList array )
        {
            this.login = array[0].ToString();
            this.password = array[1].ToString();
            this.info = array[2].ToString();
            this.array = array;
        }
        public void CopyElements(Row r)
        {
            this.login = r.Login;
            this.password = r.Password;
            this.info = r.Info;
            array[0] = r.Login;
            array[1] = r.Password;
            array[2] = r.Info;
        }
    }
}
