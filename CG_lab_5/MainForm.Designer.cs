namespace Lab5
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
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.polygonClipButton = new System.Windows.Forms.Button();
            this.resultPictureBox = new System.Windows.Forms.PictureBox();
            this.configurationScriptLabel = new System.Windows.Forms.Label();
            this.lineClipButton = new System.Windows.Forms.Button();
            this.configurationScriptInputBox = new System.Windows.Forms.TextBox();
            this.mainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.mainLayout.Controls.Add(this.polygonClipButton, 1, 3);
            this.mainLayout.Controls.Add(this.resultPictureBox, 0, 0);
            this.mainLayout.Controls.Add(this.configurationScriptLabel, 1, 0);
            this.mainLayout.Controls.Add(this.lineClipButton, 1, 2);
            this.mainLayout.Controls.Add(this.configurationScriptInputBox, 1, 1);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 4;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.Size = new System.Drawing.Size(894, 495);
            this.mainLayout.TabIndex = 0;
            // 
            // polygonClipButton
            // 
            this.polygonClipButton.AutoSize = true;
            this.polygonClipButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.polygonClipButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polygonClipButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.polygonClipButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.polygonClipButton.Location = new System.Drawing.Point(598, 460);
            this.polygonClipButton.Name = "polygonClipButton";
            this.polygonClipButton.Size = new System.Drawing.Size(293, 32);
            this.polygonClipButton.TabIndex = 4;
            this.polygonClipButton.Text = "Interpret as polygon clip";
            this.polygonClipButton.UseVisualStyleBackColor = true;
            this.polygonClipButton.Click += new System.EventHandler(this.polygonClipButton_Click);
            // 
            // resultPictureBox
            // 
            this.resultPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPictureBox.Location = new System.Drawing.Point(3, 3);
            this.resultPictureBox.Name = "resultPictureBox";
            this.mainLayout.SetRowSpan(this.resultPictureBox, 4);
            this.resultPictureBox.Size = new System.Drawing.Size(589, 489);
            this.resultPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.resultPictureBox.TabIndex = 1;
            this.resultPictureBox.TabStop = false;
            // 
            // configurationScriptLabel
            // 
            this.configurationScriptLabel.AutoSize = true;
            this.configurationScriptLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configurationScriptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.configurationScriptLabel.Location = new System.Drawing.Point(598, 0);
            this.configurationScriptLabel.Name = "configurationScriptLabel";
            this.configurationScriptLabel.Size = new System.Drawing.Size(293, 24);
            this.configurationScriptLabel.TabIndex = 2;
            this.configurationScriptLabel.Text = "Configuration script";
            this.configurationScriptLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lineClipButton
            // 
            this.lineClipButton.AutoSize = true;
            this.lineClipButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lineClipButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineClipButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lineClipButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lineClipButton.Location = new System.Drawing.Point(598, 422);
            this.lineClipButton.Name = "lineClipButton";
            this.lineClipButton.Size = new System.Drawing.Size(293, 32);
            this.lineClipButton.TabIndex = 3;
            this.lineClipButton.Text = "Interpret as line clip";
            this.lineClipButton.UseVisualStyleBackColor = true;
            this.lineClipButton.Click += new System.EventHandler(this.lineClipButton_Click);
            // 
            // configurationScriptInputBox
            // 
            this.configurationScriptInputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.configurationScriptInputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configurationScriptInputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.configurationScriptInputBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.configurationScriptInputBox.Location = new System.Drawing.Point(598, 27);
            this.configurationScriptInputBox.Multiline = true;
            this.configurationScriptInputBox.Name = "configurationScriptInputBox";
            this.configurationScriptInputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.configurationScriptInputBox.Size = new System.Drawing.Size(293, 389);
            this.configurationScriptInputBox.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(894, 495);
            this.Controls.Add(this.mainLayout);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.Name = "MainForm";
            this.Text = "Konstantin Tomashevich CG Lab 5";
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.PictureBox resultPictureBox;
        private System.Windows.Forms.Button polygonClipButton;
        private System.Windows.Forms.Label configurationScriptLabel;
        private System.Windows.Forms.Button lineClipButton;
        private System.Windows.Forms.TextBox configurationScriptInputBox;
    }
}

