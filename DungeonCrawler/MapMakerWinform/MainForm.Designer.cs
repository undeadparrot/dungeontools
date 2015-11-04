/*
 * Created by SharpDevelop.
 * User: smatu
 * Date: 11/01/2015
 * Time: 12:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MapMakerWinform
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel pnlMap;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lblStatusCoords;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.FlowLayoutPanel flowPal;
		private System.Windows.Forms.Button btnPal;
		private System.Windows.Forms.ToolStripStatusLabel lblStatusMessage;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem openMapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveMapAsToolStripMenuItem;
		private System.Windows.Forms.Panel pnlPreview;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.pnlMap = new System.Windows.Forms.Panel();
			this.btnPal = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblStatusCoords = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.flowPal = new System.Windows.Forms.FlowLayoutPanel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.openMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveMapAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pnlPreview = new System.Windows.Forms.Panel();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.flowPal.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMap
			// 
			this.pnlMap.BackColor = System.Drawing.Color.Gray;
			this.pnlMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMap.Location = new System.Drawing.Point(0, 0);
			this.pnlMap.Name = "pnlMap";
			this.pnlMap.Size = new System.Drawing.Size(186, 215);
			this.pnlMap.TabIndex = 0;
			this.pnlMap.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlMapPaint);
			this.pnlMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlMapMouseDown);
			this.pnlMap.MouseLeave += new System.EventHandler(this.PnlMapMouseLeave);
			this.pnlMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PnlMapMouseMove);
			this.pnlMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PnlMapMouseUp);
			this.pnlMap.Resize += new System.EventHandler(this.PnlMapResize);
			// 
			// btnPal
			// 
			this.btnPal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.btnPal.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
			this.btnPal.FlatAppearance.BorderSize = 3;
			this.btnPal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPal.ForeColor = System.Drawing.Color.White;
			this.btnPal.Location = new System.Drawing.Point(3, 109);
			this.btnPal.Name = "btnPal";
			this.btnPal.Size = new System.Drawing.Size(36, 34);
			this.btnPal.TabIndex = 0;
			this.btnPal.TabStop = false;
			this.btnPal.Text = "1";
			this.btnPal.UseVisualStyleBackColor = false;
			this.btnPal.Click += new System.EventHandler(this.BtnPalClick);
			this.btnPal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnPalMouseClick);
			this.btnPal.MouseCaptureChanged += new System.EventHandler(this.BtnPalMouseCaptureChanged);
			this.btnPal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnPalMouseDown);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.lblStatusCoords,
			this.lblStatusMessage});
			this.statusStrip1.Location = new System.Drawing.Point(0, 239);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(284, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblStatusCoords
			// 
			this.lblStatusCoords.Name = "lblStatusCoords";
			this.lblStatusCoords.Size = new System.Drawing.Size(0, 17);
			// 
			// lblStatusMessage
			// 
			this.lblStatusMessage.Name = "lblStatusMessage";
			this.lblStatusMessage.Size = new System.Drawing.Size(17, 17);
			this.lblStatusMessage.Text = ": )";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.flowPal);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.pnlMap);
			this.splitContainer1.Size = new System.Drawing.Size(284, 215);
			this.splitContainer1.SplitterDistance = 94;
			this.splitContainer1.TabIndex = 2;
			// 
			// flowPal
			// 
			this.flowPal.Controls.Add(this.pnlPreview);
			this.flowPal.Controls.Add(this.btnPal);
			this.flowPal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowPal.Location = new System.Drawing.Point(0, 0);
			this.flowPal.Name = "flowPal";
			this.flowPal.Size = new System.Drawing.Size(94, 215);
			this.flowPal.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.openMapToolStripMenuItem,
			this.saveMapToolStripMenuItem,
			this.saveMapAsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(284, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// openMapToolStripMenuItem
			// 
			this.openMapToolStripMenuItem.Name = "openMapToolStripMenuItem";
			this.openMapToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
			this.openMapToolStripMenuItem.Text = "Open Map";
			this.openMapToolStripMenuItem.Click += new System.EventHandler(this.OpenMapToolStripMenuItemClick);
			// 
			// saveMapToolStripMenuItem
			// 
			this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
			this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
			this.saveMapToolStripMenuItem.Text = "Save Map";
			this.saveMapToolStripMenuItem.Click += new System.EventHandler(this.SaveMapToolStripMenuItemClick);
			// 
			// saveMapAsToolStripMenuItem
			// 
			this.saveMapAsToolStripMenuItem.Name = "saveMapAsToolStripMenuItem";
			this.saveMapAsToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
			this.saveMapAsToolStripMenuItem.Text = "Save Map As";
			this.saveMapAsToolStripMenuItem.Click += new System.EventHandler(this.SaveMapAsToolStripMenuItemClick);
			// 
			// pnlPreview
			// 
			this.pnlPreview.BackColor = System.Drawing.Color.Gray;
			this.pnlPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlPreview.Location = new System.Drawing.Point(3, 3);
			this.pnlPreview.Name = "pnlPreview";
			this.pnlPreview.Size = new System.Drawing.Size(91, 100);
			this.pnlPreview.TabIndex = 1;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "MapMakerWinform";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyUp);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseClick);
			this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainFormPreviewKeyDown);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.flowPal.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
