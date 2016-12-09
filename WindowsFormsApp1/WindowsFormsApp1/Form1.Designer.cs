namespace PaSaver
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Tabs = new System.Windows.Forms.TabControl();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.OpenXml = new System.Windows.Forms.OpenFileDialog();
            this.OpenDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.FileMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabsMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.AddTab = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTab = new System.Windows.Forms.ToolStripMenuItem();
            this.KeyMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox4 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox5 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tabs.Location = new System.Drawing.Point(0, 31);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(450, 222);
            this.Tabs.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "PaSafer";
            this.notifyIcon1.Visible = true;
            // 
            // OpenXml
            // 
            this.OpenXml.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            this.OpenXml.Title = "Open XML";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.createToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.FileMenu.Image = global::PaSaver.Properties.Resources.file_explorer__1_;
            this.FileMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(63, 25);
            this.FileMenu.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenXmlToolStrip_Click);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.СreateXmlToolStrip_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStrip_Click);
            // 
            // TabsMenu
            // 
            this.TabsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTab,
            this.DeleteTab});
            this.TabsMenu.Image = global::PaSaver.Properties.Resources.Puzzle;
            this.TabsMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TabsMenu.Name = "TabsMenu";
            this.TabsMenu.Size = new System.Drawing.Size(69, 25);
            this.TabsMenu.Text = "Tabs";
            // 
            // AddTab
            // 
            this.AddTab.Image = global::PaSaver.Properties.Resources.add;
            this.AddTab.Name = "AddTab";
            this.AddTab.Size = new System.Drawing.Size(124, 26);
            this.AddTab.Text = "Add";
            this.AddTab.Click += new System.EventHandler(this.AddTab_Click);
            // 
            // DeleteTab
            // 
            this.DeleteTab.Image = global::PaSaver.Properties.Resources.delete;
            this.DeleteTab.Name = "DeleteTab";
            this.DeleteTab.Size = new System.Drawing.Size(124, 26);
            this.DeleteTab.Text = "Delete";
            this.DeleteTab.Click += new System.EventHandler(this.DeleteTab_Click);
            // 
            // KeyMenu
            // 
            this.KeyMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.KeyMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.KeyMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripTextBox2,
            this.toolStripTextBox3,
            this.toolStripTextBox4,
            this.toolStripTextBox5});
            this.KeyMenu.Image = global::PaSaver.Properties.Resources.lock_blue;
            this.KeyMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.KeyMenu.Name = "KeyMenu";
            this.KeyMenu.Size = new System.Drawing.Size(29, 25);
            this.KeyMenu.Text = "toolStripDropDownButton1";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripTextBox4
            // 
            this.toolStripTextBox4.Name = "toolStripTextBox4";
            this.toolStripTextBox4.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripTextBox5
            // 
            this.toolStripTextBox5.Name = "toolStripTextBox5";
            this.toolStripTextBox5.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.TabsMenu,
            this.KeyMenu});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(450, 28);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(450, 253);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Tabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PaSaver";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.OpenFileDialog OpenXml;
        private System.Windows.Forms.FolderBrowserDialog OpenDirectory;
        private System.Windows.Forms.ToolStripDropDownButton FileMenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton TabsMenu;
        private System.Windows.Forms.ToolStripMenuItem AddTab;
        private System.Windows.Forms.ToolStripMenuItem DeleteTab;
        private System.Windows.Forms.ToolStripDropDownButton KeyMenu;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox4;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox5;
    }
}

