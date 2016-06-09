namespace BIMAsistant
{
    partial class CreateSheetForm
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
            this.closeButton = new System.Windows.Forms.Button();
            this.selectTitleBoxLabel = new System.Windows.Forms.Label();
            this.selectTitleBox = new System.Windows.Forms.ComboBox();
            this.sheetNumberSuffixLabel = new System.Windows.Forms.Label();
            this.inputSheetNumSuffix = new System.Windows.Forms.TextBox();
            this.sheetNameLabel = new System.Windows.Forms.Label();
            this.inputSheetName = new System.Windows.Forms.TextBox();
            this.createSheetsButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.openXLfile = new System.Windows.Forms.OpenFileDialog();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(554, 127);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(160, 38);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // selectTitleBoxLabel
            // 
            this.selectTitleBoxLabel.AutoSize = true;
            this.selectTitleBoxLabel.Location = new System.Drawing.Point(40, 32);
            this.selectTitleBoxLabel.Name = "selectTitleBoxLabel";
            this.selectTitleBoxLabel.Size = new System.Drawing.Size(116, 17);
            this.selectTitleBoxLabel.TabIndex = 10;
            this.selectTitleBoxLabel.Text = "Select Title Block";
            // 
            // selectTitleBox
            // 
            this.selectTitleBox.FormattingEnabled = true;
            this.selectTitleBox.Location = new System.Drawing.Point(43, 52);
            this.selectTitleBox.Name = "selectTitleBox";
            this.selectTitleBox.Size = new System.Drawing.Size(420, 24);
            this.selectTitleBox.TabIndex = 2;
            this.selectTitleBox.SelectedIndexChanged += new System.EventHandler(this.selectTitleBox_SelectedIndexChanged);
            // 
            // sheetNumberSuffixLabel
            // 
            this.sheetNumberSuffixLabel.AutoSize = true;
            this.sheetNumberSuffixLabel.Location = new System.Drawing.Point(40, 107);
            this.sheetNumberSuffixLabel.Name = "sheetNumberSuffixLabel";
            this.sheetNumberSuffixLabel.Size = new System.Drawing.Size(137, 17);
            this.sheetNumberSuffixLabel.TabIndex = 12;
            this.sheetNumberSuffixLabel.Text = "Sheet Number Suffix";
            // 
            // inputSheetNumSuffix
            // 
            this.inputSheetNumSuffix.Location = new System.Drawing.Point(43, 127);
            this.inputSheetNumSuffix.Multiline = true;
            this.inputSheetNumSuffix.Name = "inputSheetNumSuffix";
            this.inputSheetNumSuffix.Size = new System.Drawing.Size(177, 24);
            this.inputSheetNumSuffix.TabIndex = 3;
            // 
            // sheetNameLabel
            // 
            this.sheetNameLabel.AutoSize = true;
            this.sheetNameLabel.Location = new System.Drawing.Point(283, 107);
            this.sheetNameLabel.Name = "sheetNameLabel";
            this.sheetNameLabel.Size = new System.Drawing.Size(90, 17);
            this.sheetNameLabel.TabIndex = 14;
            this.sheetNameLabel.Text = "Sheet Name ";
            // 
            // inputSheetName
            // 
            this.inputSheetName.Location = new System.Drawing.Point(286, 127);
            this.inputSheetName.Multiline = true;
            this.inputSheetName.Name = "inputSheetName";
            this.inputSheetName.Size = new System.Drawing.Size(177, 24);
            this.inputSheetName.TabIndex = 4;
            // 
            // createSheetsButton
            // 
            this.createSheetsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.createSheetsButton.Location = new System.Drawing.Point(554, 52);
            this.createSheetsButton.Name = "createSheetsButton";
            this.createSheetsButton.Size = new System.Drawing.Size(160, 38);
            this.createSheetsButton.TabIndex = 5;
            this.createSheetsButton.Text = "Create Sheets";
            this.createSheetsButton.UseVisualStyleBackColor = true;
            this.createSheetsButton.Click += new System.EventHandler(this.createSheetsButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(554, 197);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(160, 38);
            this.aboutButton.TabIndex = 7;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // openXLfile
            // 
            this.openXLfile.FileName = "openXLfile";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(40, 205);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(52, 17);
            this.statusLabel.TabIndex = 19;
            this.statusLabel.Text = "Status:";
            // 
            // CreateSheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 427);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.createSheetsButton);
            this.Controls.Add(this.inputSheetName);
            this.Controls.Add(this.sheetNameLabel);
            this.Controls.Add(this.inputSheetNumSuffix);
            this.Controls.Add(this.sheetNumberSuffixLabel);
            this.Controls.Add(this.selectTitleBox);
            this.Controls.Add(this.selectTitleBoxLabel);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CreateSheetForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Sheets 3.0";
            this.Load += new System.EventHandler(this.CreateSheetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label selectTitleBoxLabel;
        private System.Windows.Forms.ComboBox selectTitleBox;
        private System.Windows.Forms.Label sheetNumberSuffixLabel;
        private System.Windows.Forms.TextBox inputSheetNumSuffix;
        private System.Windows.Forms.Label sheetNameLabel;
        private System.Windows.Forms.TextBox inputSheetName;
        private System.Windows.Forms.Button createSheetsButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.OpenFileDialog openXLfile;
        private System.Windows.Forms.Label statusLabel;
        
    }
}