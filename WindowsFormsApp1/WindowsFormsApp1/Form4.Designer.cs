namespace PaSaver
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.KeyBox1 = new System.Windows.Forms.TextBox();
            this.KeyBox2 = new System.Windows.Forms.TextBox();
            this.KeyBox3 = new System.Windows.Forms.TextBox();
            this.KeyBox4 = new System.Windows.Forms.TextBox();
            this.KeyBox5 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KeyBox1
            // 
            this.KeyBox1.Location = new System.Drawing.Point(12, 12);
            this.KeyBox1.Name = "KeyBox1";
            this.KeyBox1.Size = new System.Drawing.Size(100, 20);
            this.KeyBox1.TabIndex = 0;
            this.KeyBox1.Text = "Write key here";
            this.KeyBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown);
            // 
            // KeyBox2
            // 
            this.KeyBox2.Location = new System.Drawing.Point(12, 39);
            this.KeyBox2.Name = "KeyBox2";
            this.KeyBox2.Size = new System.Drawing.Size(100, 20);
            this.KeyBox2.TabIndex = 1;
            this.KeyBox2.Text = "Write key here";
            this.KeyBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown);
            // 
            // KeyBox3
            // 
            this.KeyBox3.Location = new System.Drawing.Point(12, 66);
            this.KeyBox3.Name = "KeyBox3";
            this.KeyBox3.Size = new System.Drawing.Size(100, 20);
            this.KeyBox3.TabIndex = 2;
            this.KeyBox3.Text = "Write key here";
            this.KeyBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown);
            // 
            // KeyBox4
            // 
            this.KeyBox4.Location = new System.Drawing.Point(12, 92);
            this.KeyBox4.Name = "KeyBox4";
            this.KeyBox4.Size = new System.Drawing.Size(100, 20);
            this.KeyBox4.TabIndex = 3;
            this.KeyBox4.Text = "Write key here";
            this.KeyBox4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown);
            // 
            // KeyBox5
            // 
            this.KeyBox5.Location = new System.Drawing.Point(13, 119);
            this.KeyBox5.Name = "KeyBox5";
            this.KeyBox5.Size = new System.Drawing.Size(100, 20);
            this.KeyBox5.TabIndex = 4;
            this.KeyBox5.Text = "Write key here";
            this.KeyBox5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(119, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 127);
            this.button1.TabIndex = 5;
            this.button1.Text = ":)";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(152, 149);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.KeyBox5);
            this.Controls.Add(this.KeyBox4);
            this.Controls.Add(this.KeyBox3);
            this.Controls.Add(this.KeyBox2);
            this.Controls.Add(this.KeyBox1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Keys";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.TextBox KeyBox3;
        internal System.Windows.Forms.TextBox KeyBox1;
        internal System.Windows.Forms.TextBox KeyBox2;
        internal System.Windows.Forms.TextBox KeyBox4;
        internal System.Windows.Forms.TextBox KeyBox5;
    }
}