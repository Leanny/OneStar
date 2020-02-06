namespace SeedSearcherGui
{
    partial class ExportWindow
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
            this.ExportText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ExportText
            // 
            this.ExportText.Location = new System.Drawing.Point(12, 12);
            this.ExportText.Multiline = true;
            this.ExportText.Name = "ExportText";
            this.ExportText.ReadOnly = true;
            this.ExportText.Size = new System.Drawing.Size(466, 242);
            this.ExportText.TabIndex = 0;
            // 
            // ExportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 265);
            this.Controls.Add(this.ExportText);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportWindow";
            this.ShowIcon = false;
            this.Text = "Export";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ExportText;
    }
}