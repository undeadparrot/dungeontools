namespace PerspectiveTester
{
    partial class ProjectorForm
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
            this.pnlProjection = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlProjection
            // 
            this.pnlProjection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProjection.BackColor = System.Drawing.Color.Thistle;
            this.pnlProjection.Location = new System.Drawing.Point(0, 0);
            this.pnlProjection.Name = "pnlProjection";
            this.pnlProjection.Size = new System.Drawing.Size(240, 240);
            this.pnlProjection.TabIndex = 4;
            this.pnlProjection.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlProjection_Paint);
            // 
            // ProjectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.pnlProjection);
            this.Name = "ProjectorForm";
            this.Text = "ProjectorForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.WindowProjector_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlProjection;
    }
}