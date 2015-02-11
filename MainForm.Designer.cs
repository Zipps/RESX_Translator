namespace RESX_Translator
{
    partial class MainForm
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
            this.resxGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openResxFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTMFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveTargetResourceFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveChangesToNewTMFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTMFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bingTranslateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translateAllLinesUsingBIngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translateOnlyMissingLinesUsingBingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.targetResxLabel = new System.Windows.Forms.Label();
            this.sourceResxLabel = new System.Windows.Forms.Label();
            this.translateButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resxGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // resxGrid
            // 
            this.resxGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resxGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resxGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resxGrid.Location = new System.Drawing.Point(0, 116);
            this.resxGrid.Name = "resxGrid";
            this.resxGrid.Size = new System.Drawing.Size(1240, 457);
            this.resxGrid.TabIndex = 0;
            this.resxGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resxGrid_CellClick);
            this.resxGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.resxGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.bingTranslateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1240, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openResxFileToolStripMenuItem,
            this.openTMFileToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveTargetResourceFileToolStripMenuItem,
            this.saveChangesToNewTMFileToolStripMenuItem,
            this.saveTMFileToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openResxFileToolStripMenuItem
            // 
            this.openResxFileToolStripMenuItem.Name = "openResxFileToolStripMenuItem";
            this.openResxFileToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.openResxFileToolStripMenuItem.Text = "Open source resource file";
            this.openResxFileToolStripMenuItem.Click += new System.EventHandler(this.openResxFileToolStripMenuItem_Click);
            // 
            // openTMFileToolStripMenuItem
            // 
            this.openTMFileToolStripMenuItem.Name = "openTMFileToolStripMenuItem";
            this.openTMFileToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.openTMFileToolStripMenuItem.Text = "Open TM file";
            this.openTMFileToolStripMenuItem.Click += new System.EventHandler(this.openTMFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(242, 6);
            // 
            // saveTargetResourceFileToolStripMenuItem
            // 
            this.saveTargetResourceFileToolStripMenuItem.Name = "saveTargetResourceFileToolStripMenuItem";
            this.saveTargetResourceFileToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.saveTargetResourceFileToolStripMenuItem.Text = "Save target resource file";
            this.saveTargetResourceFileToolStripMenuItem.Click += new System.EventHandler(this.saveTargetResourceFileToolStripMenuItem_Click);
            // 
            // saveChangesToNewTMFileToolStripMenuItem
            // 
            this.saveChangesToNewTMFileToolStripMenuItem.Name = "saveChangesToNewTMFileToolStripMenuItem";
            this.saveChangesToNewTMFileToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.saveChangesToNewTMFileToolStripMenuItem.Text = "Save changes to new TM file";
            this.saveChangesToNewTMFileToolStripMenuItem.Click += new System.EventHandler(this.saveChangesToNewTMFileToolStripMenuItem_Click);
            // 
            // saveTMFileToolStripMenuItem
            // 
            this.saveTMFileToolStripMenuItem.Name = "saveTMFileToolStripMenuItem";
            this.saveTMFileToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.saveTMFileToolStripMenuItem.Text = "Save changes to exisiting TM file";
            this.saveTMFileToolStripMenuItem.Click += new System.EventHandler(this.saveTMFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(242, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(242, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // bingTranslateToolStripMenuItem
            // 
            this.bingTranslateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.translateAllLinesUsingBIngToolStripMenuItem,
            this.translateOnlyMissingLinesUsingBingToolStripMenuItem});
            this.bingTranslateToolStripMenuItem.Name = "bingTranslateToolStripMenuItem";
            this.bingTranslateToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.bingTranslateToolStripMenuItem.Text = "Microsoft Translate";
            // 
            // translateAllLinesUsingBIngToolStripMenuItem
            // 
            this.translateAllLinesUsingBIngToolStripMenuItem.Name = "translateAllLinesUsingBIngToolStripMenuItem";
            this.translateAllLinesUsingBIngToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.translateAllLinesUsingBIngToolStripMenuItem.Text = "Translate All Lines Using Microsoft Translator";
            this.translateAllLinesUsingBIngToolStripMenuItem.Click += new System.EventHandler(this.translateAllLinesUsingBIngToolStripMenuItem_Click);
            // 
            // translateOnlyMissingLinesUsingBingToolStripMenuItem
            // 
            this.translateOnlyMissingLinesUsingBingToolStripMenuItem.Name = "translateOnlyMissingLinesUsingBingToolStripMenuItem";
            this.translateOnlyMissingLinesUsingBingToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.translateOnlyMissingLinesUsingBingToolStripMenuItem.Text = "Translate Only Missing Lines Using Microsoft Translator";
            this.translateOnlyMissingLinesUsingBingToolStripMenuItem.Click += new System.EventHandler(this.translateOnlyMissingLinesUsingBingToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "The source RESX culture is:";
            // 
            // targetResxLabel
            // 
            this.targetResxLabel.AutoSize = true;
            this.targetResxLabel.Location = new System.Drawing.Point(19, 75);
            this.targetResxLabel.Name = "targetResxLabel";
            this.targetResxLabel.Size = new System.Drawing.Size(136, 13);
            this.targetResxLabel.TabIndex = 3;
            this.targetResxLabel.Text = "The target RESX culture is:";
            // 
            // sourceResxLabel
            // 
            this.sourceResxLabel.AutoSize = true;
            this.sourceResxLabel.Location = new System.Drawing.Point(166, 41);
            this.sourceResxLabel.Name = "sourceResxLabel";
            this.sourceResxLabel.Size = new System.Drawing.Size(10, 13);
            this.sourceResxLabel.TabIndex = 5;
            this.sourceResxLabel.Text = "-";
            this.sourceResxLabel.UseMnemonic = false;
            this.sourceResxLabel.Click += new System.EventHandler(this.sourceResxLabel_Click);
            // 
            // translateButton
            // 
            this.translateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.translateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.translateButton.BackColor = System.Drawing.SystemColors.Control;
            this.translateButton.Location = new System.Drawing.Point(469, 46);
            this.translateButton.Name = "translateButton";
            this.translateButton.Size = new System.Drawing.Size(156, 42);
            this.translateButton.TabIndex = 6;
            this.translateButton.Text = "        Translate using TM         ";
            this.translateButton.UseVisualStyleBackColor = false;
            this.translateButton.Click += new System.EventHandler(this.translateButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(169, 71);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(904, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(311, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(905, 75);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(310, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(727, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Enter Microsoft Translator Client ID";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(706, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Enter Microsoft Translator Client Secret";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 585);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.translateButton);
            this.Controls.Add(this.sourceResxLabel);
            this.Controls.Add(this.targetResxLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resxGrid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "RESX Translator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resxGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView resxGrid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openResxFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTMFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveTargetResourceFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTMFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bingTranslateToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label targetResxLabel;
        private System.Windows.Forms.Label sourceResxLabel;
        private System.Windows.Forms.ToolStripMenuItem saveChangesToNewTMFileToolStripMenuItem;
        private System.Windows.Forms.Button translateButton;
        private System.Windows.Forms.ToolStripMenuItem translateAllLinesUsingBIngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem translateOnlyMissingLinesUsingBingToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}

