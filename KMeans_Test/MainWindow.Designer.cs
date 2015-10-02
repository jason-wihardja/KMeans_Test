namespace KMeans_Test {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.leftTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.calcButton = new System.Windows.Forms.Button();
            this.numOfTerminusLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.fileDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.numOfTerminusComboBox = new System.Windows.Forms.ComboBox();
            this.chooseFileLabel = new System.Windows.Forms.Label();
            this.resultGroupBox = new System.Windows.Forms.GroupBox();
            this.aboutButton = new System.Windows.Forms.Button();
            this.resultRichTextBox = new System.Windows.Forms.RichTextBox();
            this.saveImageButton = new System.Windows.Forms.Button();
            this.saveResultButton = new System.Windows.Forms.Button();
            this.DrawingPanel = new System.Windows.Forms.Panel();
            this.saveImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.saveResultDialog = new System.Windows.Forms.SaveFileDialog();
            this.mainTableLayoutPanel.SuspendLayout();
            this.leftTableLayoutPanel.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.resultGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "CSV Files|*.csv";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.AutoSize = true;
            this.mainTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.leftTableLayoutPanel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.DrawingPanel, 1, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1008, 729);
            this.mainTableLayoutPanel.TabIndex = 3;
            // 
            // leftTableLayoutPanel
            // 
            this.leftTableLayoutPanel.ColumnCount = 1;
            this.leftTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftTableLayoutPanel.Controls.Add(this.optionsPanel, 0, 0);
            this.leftTableLayoutPanel.Controls.Add(this.resultGroupBox, 0, 1);
            this.leftTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.leftTableLayoutPanel.Name = "leftTableLayoutPanel";
            this.leftTableLayoutPanel.RowCount = 2;
            this.leftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.leftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftTableLayoutPanel.Size = new System.Drawing.Size(244, 723);
            this.leftTableLayoutPanel.TabIndex = 2;
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.calcButton);
            this.optionsPanel.Controls.Add(this.numOfTerminusLabel);
            this.optionsPanel.Controls.Add(this.browseButton);
            this.optionsPanel.Controls.Add(this.fileDirectoryTextBox);
            this.optionsPanel.Controls.Add(this.numOfTerminusComboBox);
            this.optionsPanel.Controls.Add(this.chooseFileLabel);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsPanel.Location = new System.Drawing.Point(3, 3);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(238, 84);
            this.optionsPanel.TabIndex = 0;
            // 
            // calcButton
            // 
            this.calcButton.Enabled = false;
            this.calcButton.Location = new System.Drawing.Point(6, 55);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(232, 23);
            this.calcButton.TabIndex = 5;
            this.calcButton.Text = "Calculate!";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
            // 
            // numOfTerminusLabel
            // 
            this.numOfTerminusLabel.AutoSize = true;
            this.numOfTerminusLabel.Location = new System.Drawing.Point(3, 31);
            this.numOfTerminusLabel.Name = "numOfTerminusLabel";
            this.numOfTerminusLabel.Size = new System.Drawing.Size(110, 13);
            this.numOfTerminusLabel.TabIndex = 4;
            this.numOfTerminusLabel.Text = "Number of bus station";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(213, 0);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(25, 23);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // fileDirectoryTextBox
            // 
            this.fileDirectoryTextBox.BackColor = System.Drawing.Color.White;
            this.fileDirectoryTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fileDirectoryTextBox.ForeColor = System.Drawing.Color.Black;
            this.fileDirectoryTextBox.Location = new System.Drawing.Point(65, 2);
            this.fileDirectoryTextBox.Name = "fileDirectoryTextBox";
            this.fileDirectoryTextBox.ReadOnly = true;
            this.fileDirectoryTextBox.Size = new System.Drawing.Size(142, 20);
            this.fileDirectoryTextBox.TabIndex = 2;
            // 
            // numOfTerminusComboBox
            // 
            this.numOfTerminusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numOfTerminusComboBox.Enabled = false;
            this.numOfTerminusComboBox.FormattingEnabled = true;
            this.numOfTerminusComboBox.Location = new System.Drawing.Point(119, 28);
            this.numOfTerminusComboBox.Name = "numOfTerminusComboBox";
            this.numOfTerminusComboBox.Size = new System.Drawing.Size(119, 21);
            this.numOfTerminusComboBox.TabIndex = 1;
            // 
            // chooseFileLabel
            // 
            this.chooseFileLabel.AutoSize = true;
            this.chooseFileLabel.Location = new System.Drawing.Point(3, 5);
            this.chooseFileLabel.Name = "chooseFileLabel";
            this.chooseFileLabel.Size = new System.Drawing.Size(62, 13);
            this.chooseFileLabel.TabIndex = 0;
            this.chooseFileLabel.Text = "Choose File";
            // 
            // resultGroupBox
            // 
            this.resultGroupBox.Controls.Add(this.aboutButton);
            this.resultGroupBox.Controls.Add(this.resultRichTextBox);
            this.resultGroupBox.Controls.Add(this.saveImageButton);
            this.resultGroupBox.Controls.Add(this.saveResultButton);
            this.resultGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultGroupBox.Location = new System.Drawing.Point(3, 93);
            this.resultGroupBox.Name = "resultGroupBox";
            this.resultGroupBox.Size = new System.Drawing.Size(238, 627);
            this.resultGroupBox.TabIndex = 1;
            this.resultGroupBox.TabStop = false;
            this.resultGroupBox.Text = "Result";
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(6, 598);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(226, 23);
            this.aboutButton.TabIndex = 2;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // resultRichTextBox
            // 
            this.resultRichTextBox.BackColor = System.Drawing.Color.White;
            this.resultRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultRichTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.resultRichTextBox.DetectUrls = false;
            this.resultRichTextBox.ForeColor = System.Drawing.Color.Black;
            this.resultRichTextBox.Location = new System.Drawing.Point(6, 19);
            this.resultRichTextBox.Name = "resultRichTextBox";
            this.resultRichTextBox.ReadOnly = true;
            this.resultRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.resultRichTextBox.Size = new System.Drawing.Size(226, 515);
            this.resultRichTextBox.TabIndex = 1;
            this.resultRichTextBox.Text = "";
            // 
            // saveImageButton
            // 
            this.saveImageButton.Enabled = false;
            this.saveImageButton.Location = new System.Drawing.Point(6, 569);
            this.saveImageButton.Name = "saveImageButton";
            this.saveImageButton.Size = new System.Drawing.Size(226, 23);
            this.saveImageButton.TabIndex = 0;
            this.saveImageButton.Text = "Save Image";
            this.saveImageButton.UseVisualStyleBackColor = true;
            this.saveImageButton.Click += new System.EventHandler(this.saveImageButton_Click);
            // 
            // saveResultButton
            // 
            this.saveResultButton.Enabled = false;
            this.saveResultButton.Location = new System.Drawing.Point(6, 540);
            this.saveResultButton.Name = "saveResultButton";
            this.saveResultButton.Size = new System.Drawing.Size(226, 23);
            this.saveResultButton.TabIndex = 0;
            this.saveResultButton.Text = "Save Result";
            this.saveResultButton.UseVisualStyleBackColor = true;
            this.saveResultButton.Click += new System.EventHandler(this.saveResultButton_Click);
            // 
            // DrawingPanel
            // 
            this.DrawingPanel.BackColor = System.Drawing.Color.White;
            this.DrawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawingPanel.Location = new System.Drawing.Point(253, 3);
            this.DrawingPanel.Name = "DrawingPanel";
            this.DrawingPanel.Size = new System.Drawing.Size(752, 723);
            this.DrawingPanel.TabIndex = 0;
            this.DrawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingPanel_Paint);
            // 
            // saveImageDialog
            // 
            this.saveImageDialog.Filter = "BMP Files|*.bmp";
            this.saveImageDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveImageDialog_FileOk);
            // 
            // timer
            // 
            this.timer.Interval = 750;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // saveResultDialog
            // 
            this.saveResultDialog.Filter = "Text Files|*.txt";
            this.saveResultDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveResultDialog_FileOk);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bus Station Positioning System";
            this.Activated += new System.EventHandler(this.MainWindow_Activated);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.leftTableLayoutPanel.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            this.resultGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.Panel DrawingPanel;
        private System.Windows.Forms.SaveFileDialog saveImageDialog;
        private System.Windows.Forms.TableLayoutPanel leftTableLayoutPanel;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.Label chooseFileLabel;
        private System.Windows.Forms.ComboBox numOfTerminusComboBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox fileDirectoryTextBox;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.Label numOfTerminusLabel;
        private System.Windows.Forms.GroupBox resultGroupBox;
        private System.Windows.Forms.Button saveImageButton;
        private System.Windows.Forms.Button saveResultButton;
        private System.Windows.Forms.RichTextBox resultRichTextBox;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.SaveFileDialog saveResultDialog;

    }
}

