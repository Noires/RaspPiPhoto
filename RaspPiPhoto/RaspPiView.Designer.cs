namespace RaspPiPhoto
{
    partial class RaspPiView
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxGroup = new System.Windows.Forms.TextBox();
            this.labelIP = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.labelGroup = new System.Windows.Forms.Label();
            this.buttonPicture = new System.Windows.Forms.Button();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.btnSetID = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(4, 42);
            this.textBoxIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.ReadOnly = true;
            this.textBoxIP.Size = new System.Drawing.Size(132, 22);
            this.textBoxIP.TabIndex = 0;
            this.textBoxIP.Text = "127.0.0.1";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(145, 41);
            this.textBoxID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(132, 22);
            this.textBoxID.TabIndex = 1;
            this.textBoxID.Text = "0";
            // 
            // textBoxGroup
            // 
            this.textBoxGroup.Location = new System.Drawing.Point(287, 39);
            this.textBoxGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxGroup.Name = "textBoxGroup";
            this.textBoxGroup.Size = new System.Drawing.Size(132, 22);
            this.textBoxGroup.TabIndex = 2;
            this.textBoxGroup.Text = "0";
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(0, 14);
            this.labelIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(77, 17);
            this.labelIP.TabIndex = 3;
            this.labelIP.Text = "IP-Adresse";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(141, 14);
            this.labelID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(93, 17);
            this.labelID.TabIndex = 4;
            this.labelID.Text = "RaspBerry-ID";
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Location = new System.Drawing.Point(283, 14);
            this.labelGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(120, 17);
            this.labelGroup.TabIndex = 5;
            this.labelGroup.Text = "RaspBerry-Group";
            // 
            // buttonPicture
            // 
            this.buttonPicture.Location = new System.Drawing.Point(428, 39);
            this.buttonPicture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPicture.Name = "buttonPicture";
            this.buttonPicture.Size = new System.Drawing.Size(101, 25);
            this.buttonPicture.TabIndex = 6;
            this.buttonPicture.Text = "Take Picture";
            this.buttonPicture.UseVisualStyleBackColor = true;
            this.buttonPicture.Click += new System.EventHandler(this.buttonPicture_Click);
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Location = new System.Drawing.Point(537, 14);
            this.pictureBoxPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(71, 50);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPreview.TabIndex = 7;
            this.pictureBoxPreview.TabStop = false;
            this.pictureBoxPreview.Click += new System.EventHandler(this.pictureBoxPreview_Click);
            // 
            // btnSetID
            // 
            this.btnSetID.Location = new System.Drawing.Point(428, 14);
            this.btnSetID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSetID.Name = "btnSetID";
            this.btnSetID.Size = new System.Drawing.Size(100, 25);
            this.btnSetID.TabIndex = 8;
            this.btnSetID.Text = "Set ID";
            this.btnSetID.UseVisualStyleBackColor = true;
            this.btnSetID.Click += new System.EventHandler(this.OnIDBtnCLick);
            // 
            // RaspPiView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSetID);
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.buttonPicture);
            this.Controls.Add(this.labelGroup);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.textBoxGroup);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBoxIP);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RaspPiView";
            this.Size = new System.Drawing.Size(619, 78);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxGroup;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.Button buttonPicture;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Button btnSetID;
    }
}
