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
            this.TabTypes = new System.Windows.Forms.TabControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.safeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabsMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.AddTab = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTab = new System.Windows.Forms.ToolStripMenuItem();
            this.ElementMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.AddElement = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteElement = new System.Windows.Forms.ToolStripMenuItem();
            this.FixElement = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KeyMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Key1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Key2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.OpenXml = new System.Windows.Forms.OpenFileDialog();
            this.OpenDirectory = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabTypes
            // 
            this.TabTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabTypes.Location = new System.Drawing.Point(0, 31);
            this.TabTypes.Name = "TabTypes";
            this.TabTypes.SelectedIndex = 0;
            this.TabTypes.Size = new System.Drawing.Size(376, 222);
            this.TabTypes.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.TabsMenu,
            this.ElementMenu,
            this.KeyMenu});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(376, 28);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.createToolStripMenuItem,
            this.safeToolStripMenuItem});
            this.FileMenu.Image = global::PaSaver.Properties.Resources.file_explorer__1_;
            this.FileMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(63, 25);
            this.FileMenu.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(124, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenXmlToolStrip_Click);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(124, 26);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.СreateXmlToolStrip_Click);
            // 
            // safeToolStripMenuItem
            // 
            this.safeToolStripMenuItem.Name = "safeToolStripMenuItem";
            this.safeToolStripMenuItem.Size = new System.Drawing.Size(124, 26);
            this.safeToolStripMenuItem.Text = "Save";
            this.safeToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStrip_Click);
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
            this.AddTab.Size = new System.Drawing.Size(152, 26);
            this.AddTab.Text = "Add";
            this.AddTab.Click += new System.EventHandler(this.AddTab_Click);
            // 
            // DeleteTab
            // 
            this.DeleteTab.Image = global::PaSaver.Properties.Resources.delete;
            this.DeleteTab.Name = "DeleteTab";
            this.DeleteTab.Size = new System.Drawing.Size(152, 26);
            this.DeleteTab.Text = "Delete";
            this.DeleteTab.Click += new System.EventHandler(this.DeleteTab_Click);
            // 
            // ElementMenu
            // 
            this.ElementMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddElement,
            this.DeleteElement,
            this.FixElement,
            this.CopyToolStripMenuItem});
            this.ElementMenu.Image = global::PaSaver.Properties.Resources.File__2_;
            this.ElementMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ElementMenu.Name = "ElementMenu";
            this.ElementMenu.Size = new System.Drawing.Size(94, 25);
            this.ElementMenu.Text = "Element";
            // 
            // AddElement
            // 
            this.AddElement.Image = global::PaSaver.Properties.Resources.Add_file;
            this.AddElement.Name = "AddElement";
            this.AddElement.Size = new System.Drawing.Size(152, 26);
            this.AddElement.Text = "Add";
            this.AddElement.Click += new System.EventHandler(this.AddElement_Click);
            // 
            // DeleteElement
            // 
            this.DeleteElement.Image = global::PaSaver.Properties.Resources.Delete_File;
            this.DeleteElement.Name = "DeleteElement";
            this.DeleteElement.Size = new System.Drawing.Size(152, 26);
            this.DeleteElement.Text = "Delete";
            this.DeleteElement.Click += new System.EventHandler(this.DeleteElement_Click);
            // 
            // FixElement
            // 
            this.FixElement.Image = global::PaSaver.Properties.Resources.Add_file;
            this.FixElement.Name = "FixElement";
            this.FixElement.Size = new System.Drawing.Size(152, 26);
            this.FixElement.Text = "Fix";
            this.FixElement.Click += new System.EventHandler(this.FixElement_Click);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Image = global::PaSaver.Properties.Resources.Download;
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.CopyToolStripMenuItem.Text = "Copy";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStrip_Click);
            // 
            // KeyMenu
            // 
            this.KeyMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.KeyMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.KeyMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.Key1,
            this.toolStripSeparator2,
            this.Key2,
            this.toolStripSeparator3});
            this.KeyMenu.Image = global::PaSaver.Properties.Resources.lock_blue;
            this.KeyMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.KeyMenu.Name = "KeyMenu";
            this.KeyMenu.Size = new System.Drawing.Size(29, 25);
            this.KeyMenu.Text = "toolStripDropDownButton1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // Key1
            // 
            this.Key1.Name = "Key1";
            this.Key1.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
            // 
            // Key2
            // 
            this.Key2.Name = "Key2";
            this.Key2.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(376, 253);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.TabTypes);
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

        private System.Windows.Forms.TabControl TabTypes;
        private System.Windows.Forms.ToolStripDropDownButton TabsMenu;
        private System.Windows.Forms.ToolStripMenuItem AddTab;
        private System.Windows.Forms.ToolStripMenuItem DeleteTab;
        private System.Windows.Forms.ToolStripDropDownButton ElementMenu;
        private System.Windows.Forms.ToolStripMenuItem AddElement;
        private System.Windows.Forms.ToolStripMenuItem DeleteElement;
        private System.Windows.Forms.ToolStripMenuItem FixElement;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripDropDownButton FileMenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenXml;
        private System.Windows.Forms.ToolStripMenuItem safeToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton KeyMenu;
        private System.Windows.Forms.ToolStripTextBox Key1;
        private System.Windows.Forms.ToolStripTextBox Key2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenDirectory;
    }
}

