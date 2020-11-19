
namespace TiledConverter
{
    partial class Form1
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
            this.ofdMap = new System.Windows.Forms.OpenFileDialog();
            this.mapBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mapPath = new System.Windows.Forms.TextBox();
            this.tilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tileBrowse = new System.Windows.Forms.Button();
            this.imgPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.imgBrowse = new System.Windows.Forms.Button();
            this.outPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.outBrowse = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.ofdTile = new System.Windows.Forms.OpenFileDialog();
            this.ofdImg = new System.Windows.Forms.OpenFileDialog();
            this.sfdOut = new System.Windows.Forms.SaveFileDialog();
            this.isPrettyPrint = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ofdMap
            // 
            this.ofdMap.Filter = "Map Files (.json)|*.json";
            // 
            // mapBrowse
            // 
            this.mapBrowse.Location = new System.Drawing.Point(393, 10);
            this.mapBrowse.Name = "mapBrowse";
            this.mapBrowse.Size = new System.Drawing.Size(75, 23);
            this.mapBrowse.TabIndex = 0;
            this.mapBrowse.Text = "Browse";
            this.mapBrowse.UseVisualStyleBackColor = true;
            this.mapBrowse.Click += new System.EventHandler(this.mapBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Map";
            // 
            // mapPath
            // 
            this.mapPath.Location = new System.Drawing.Point(52, 12);
            this.mapPath.Multiline = true;
            this.mapPath.Name = "mapPath";
            this.mapPath.Size = new System.Drawing.Size(335, 20);
            this.mapPath.TabIndex = 2;
            this.mapPath.WordWrap = false;
            // 
            // tilePath
            // 
            this.tilePath.Location = new System.Drawing.Point(52, 38);
            this.tilePath.Multiline = true;
            this.tilePath.Name = "tilePath";
            this.tilePath.Size = new System.Drawing.Size(335, 20);
            this.tilePath.TabIndex = 5;
            this.tilePath.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tileset";
            // 
            // tileBrowse
            // 
            this.tileBrowse.Location = new System.Drawing.Point(393, 36);
            this.tileBrowse.Name = "tileBrowse";
            this.tileBrowse.Size = new System.Drawing.Size(75, 23);
            this.tileBrowse.TabIndex = 3;
            this.tileBrowse.Text = "Browse";
            this.tileBrowse.UseVisualStyleBackColor = true;
            this.tileBrowse.Click += new System.EventHandler(this.tileBrowse_Click);
            // 
            // imgPath
            // 
            this.imgPath.Location = new System.Drawing.Point(52, 64);
            this.imgPath.Multiline = true;
            this.imgPath.Name = "imgPath";
            this.imgPath.Size = new System.Drawing.Size(335, 20);
            this.imgPath.TabIndex = 8;
            this.imgPath.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Image";
            // 
            // imgBrowse
            // 
            this.imgBrowse.Location = new System.Drawing.Point(393, 62);
            this.imgBrowse.Name = "imgBrowse";
            this.imgBrowse.Size = new System.Drawing.Size(75, 23);
            this.imgBrowse.TabIndex = 6;
            this.imgBrowse.Text = "Browse";
            this.imgBrowse.UseVisualStyleBackColor = true;
            this.imgBrowse.Click += new System.EventHandler(this.imgBrowse_Click);
            // 
            // outPath
            // 
            this.outPath.Location = new System.Drawing.Point(52, 107);
            this.outPath.Multiline = true;
            this.outPath.Name = "outPath";
            this.outPath.Size = new System.Drawing.Size(335, 20);
            this.outPath.TabIndex = 11;
            this.outPath.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Output";
            // 
            // outBrowse
            // 
            this.outBrowse.Location = new System.Drawing.Point(393, 105);
            this.outBrowse.Name = "outBrowse";
            this.outBrowse.Size = new System.Drawing.Size(75, 23);
            this.outBrowse.TabIndex = 9;
            this.outBrowse.Text = "Browse";
            this.outBrowse.UseVisualStyleBackColor = true;
            this.outBrowse.Click += new System.EventHandler(this.outBrowse_Click);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(198, 138);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 12;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // ofdTile
            // 
            this.ofdTile.Filter = "Tile Files (.json)|*.json";
            // 
            // ofdImg
            // 
            this.ofdImg.Filter = "Image Files| *.BMP; *.GIF; *.JPG; *.JPEG; *.PNG";
            // 
            // isPrettyPrint
            // 
            this.isPrettyPrint.AutoSize = true;
            this.isPrettyPrint.Location = new System.Drawing.Point(279, 142);
            this.isPrettyPrint.Name = "isPrettyPrint";
            this.isPrettyPrint.Size = new System.Drawing.Size(76, 17);
            this.isPrettyPrint.TabIndex = 13;
            this.isPrettyPrint.Text = "Pretty print";
            this.isPrettyPrint.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 173);
            this.Controls.Add(this.isPrettyPrint);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.outPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.outBrowse);
            this.Controls.Add(this.imgPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imgBrowse);
            this.Controls.Add(this.tilePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tileBrowse);
            this.Controls.Add(this.mapPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mapBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Map Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdMap;
        private System.Windows.Forms.Button mapBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mapPath;
        private System.Windows.Forms.TextBox tilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button tileBrowse;
        private System.Windows.Forms.TextBox imgPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button imgBrowse;
        private System.Windows.Forms.TextBox outPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button outBrowse;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.OpenFileDialog ofdTile;
        private System.Windows.Forms.OpenFileDialog ofdImg;
        private System.Windows.Forms.SaveFileDialog sfdOut;
        private System.Windows.Forms.CheckBox isPrettyPrint;
    }
}

