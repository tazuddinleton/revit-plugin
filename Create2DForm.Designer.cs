namespace BIMAsistant
{
    partial class Create2DForm
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
            this.aboutButton = new System.Windows.Forms.Button();
            this.createUnitPlans = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.filePath = new System.Windows.Forms.TextBox();
            this.selectHousingLIstLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.openXLfile = new System.Windows.Forms.OpenFileDialog();
            this.statusLabel = new System.Windows.Forms.Label();
            this.selectFloorPlan = new System.Windows.Forms.ComboBox();
            this.selectFloorPlanLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(559, 278);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(160, 38);
            this.aboutButton.TabIndex = 13;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            // 
            // createUnitPlans
            // 
            this.createUnitPlans.ForeColor = System.Drawing.SystemColors.ControlText;
            this.createUnitPlans.Location = new System.Drawing.Point(559, 133);
            this.createUnitPlans.Name = "createUnitPlans";
            this.createUnitPlans.Size = new System.Drawing.Size(160, 38);
            this.createUnitPlans.TabIndex = 10;
            this.createUnitPlans.Text = "Create Unit Plans";
            this.createUnitPlans.UseVisualStyleBackColor = true;
            this.createUnitPlans.Click += new System.EventHandler(this.createUnitPlans_Click);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(559, 55);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(160, 38);
            this.browseButton.TabIndex = 9;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(42, 63);
            this.filePath.Multiline = true;
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(420, 24);
            this.filePath.TabIndex = 14;
            // 
            // selectHousingLIstLabel
            // 
            this.selectHousingLIstLabel.AutoSize = true;
            this.selectHousingLIstLabel.Location = new System.Drawing.Point(39, 43);
            this.selectHousingLIstLabel.Name = "selectHousingLIstLabel";
            this.selectHousingLIstLabel.Size = new System.Drawing.Size(129, 17);
            this.selectHousingLIstLabel.TabIndex = 11;
            this.selectHousingLIstLabel.Text = "Select Housing List";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(559, 208);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(160, 38);
            this.closeButton.TabIndex = 12;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // openXLfile
            // 
            this.openXLfile.FileName = "openFileDialog1";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(48, 278);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(52, 17);
            this.statusLabel.TabIndex = 20;
            this.statusLabel.Text = "Status:";
            // 
            // selectFloorPlan
            // 
            this.selectFloorPlan.FormattingEnabled = true;
            this.selectFloorPlan.Location = new System.Drawing.Point(42, 110);
            this.selectFloorPlan.Name = "selectFloorPlan";
            this.selectFloorPlan.Size = new System.Drawing.Size(420, 24);
            this.selectFloorPlan.TabIndex = 21;
            this.selectFloorPlan.SelectedIndexChanged += new System.EventHandler(this.selectFloorPlan_SelectedIndexChanged);
            // 
            // selectFloorPlanLabel
            // 
            this.selectFloorPlanLabel.AutoSize = true;
            this.selectFloorPlanLabel.Location = new System.Drawing.Point(39, 90);
            this.selectFloorPlanLabel.Name = "selectFloorPlanLabel";
            this.selectFloorPlanLabel.Size = new System.Drawing.Size(115, 17);
            this.selectFloorPlanLabel.TabIndex = 22;
            this.selectFloorPlanLabel.Text = "Select Floor Plan";
            // 
            // Create2DForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 427);
            this.Controls.Add(this.selectFloorPlan);
            this.Controls.Add(this.selectFloorPlanLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.createUnitPlans);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.selectHousingLIstLabel);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Create2DForm";
            this.Text = "Create2DForm";
            this.Load += new System.EventHandler(this.Create2DForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button createUnitPlans;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Label selectHousingLIstLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.OpenFileDialog openXLfile;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ComboBox selectFloorPlan;
        private System.Windows.Forms.Label selectFloorPlanLabel;

    }
}