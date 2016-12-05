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

namespace PaSaver
{
    /// <summary>
    /// Класс для вкладок TabControl
    /// </summary>
    public class DataTab 
    {
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
        public DataTab(string type = ""){ this.type = type;page.Text = type;page.Name = type; }
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
        public DataTable(string type = ""):base(type)
        {
            this.AddColumnsAndSettings(data);
            AddDataToPage(data);
        }
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
        /// <summary>
        /// Изменение элемента DataGridView
        /// </summary>
        /// <param name="index">Номер ряда</param>
        /// <param name="r">Новый объект ряда</param>
        public void ChangeRow(int index,Row r)
        {
            data.Rows[index].Cells[0].Value = r.Login;
            data.Rows[index].Cells[1].Value = r.Password;
            data.Rows[index].Cells[2].Value = r.Info;
            ((Row)data.Rows[index].Tag).CopyElements(r);
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
