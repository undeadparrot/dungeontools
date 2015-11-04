namespace PerspectiveTester
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
            this.slider2dScale = new System.Windows.Forms.TrackBar();
            this.sliderWidth = new System.Windows.Forms.TrackBar();
            this.sliderDepth = new System.Windows.Forms.TrackBar();
            this.chkDrawLines = new System.Windows.Forms.CheckBox();
            this.slider3dScale = new System.Windows.Forms.TrackBar();
            this.sliderHeight = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.sliderTranslateY = new System.Windows.Forms.TrackBar();
            this.sliderTranslateX = new System.Windows.Forms.TrackBar();
            this.lblDebugOutput = new System.Windows.Forms.Label();
            this.groupButtonMatrix = new System.Windows.Forms.GroupBox();
            this.chkDrawLeft = new System.Windows.Forms.CheckBox();
            this.chkDrawFront = new System.Windows.Forms.CheckBox();
            this.chkDrawRight = new System.Windows.Forms.CheckBox();
            this.buttonReferencePic = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkShade = new System.Windows.Forms.CheckBox();
            this.sliderProjectorWidth = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.chkRefPic = new System.Windows.Forms.CheckBox();
            this.sliderProjectorHeight = new System.Windows.Forms.TrackBar();
            this.buttonSaveMatrixJson = new System.Windows.Forms.Button();
            this.buttonParseStringRequest = new System.Windows.Forms.Button();
            this.txtJsonRequests = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.slider2dScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider3dScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTranslateY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTranslateX)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderProjectorWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderProjectorHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // slider2dScale
            // 
            this.slider2dScale.Location = new System.Drawing.Point(12, 20);
            this.slider2dScale.Maximum = 20;
            this.slider2dScale.Minimum = 1;
            this.slider2dScale.Name = "slider2dScale";
            this.slider2dScale.Size = new System.Drawing.Size(260, 45);
            this.slider2dScale.TabIndex = 0;
            this.slider2dScale.Value = 1;
            this.slider2dScale.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // sliderWidth
            // 
            this.sliderWidth.Location = new System.Drawing.Point(12, 166);
            this.sliderWidth.Maximum = 20;
            this.sliderWidth.Minimum = 1;
            this.sliderWidth.Name = "sliderWidth";
            this.sliderWidth.Size = new System.Drawing.Size(127, 45);
            this.sliderWidth.TabIndex = 1;
            this.sliderWidth.Value = 5;
            this.sliderWidth.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // sliderDepth
            // 
            this.sliderDepth.Location = new System.Drawing.Point(12, 115);
            this.sliderDepth.Maximum = 101;
            this.sliderDepth.Minimum = -101;
            this.sliderDepth.Name = "sliderDepth";
            this.sliderDepth.Size = new System.Drawing.Size(260, 45);
            this.sliderDepth.SmallChange = 2;
            this.sliderDepth.TabIndex = 2;
            this.sliderDepth.TickFrequency = 2;
            this.sliderDepth.Value = 32;
            this.sliderDepth.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // chkDrawLines
            // 
            this.chkDrawLines.AutoSize = true;
            this.chkDrawLines.Location = new System.Drawing.Point(7, 21);
            this.chkDrawLines.Name = "chkDrawLines";
            this.chkDrawLines.Size = new System.Drawing.Size(94, 17);
            this.chkDrawLines.TabIndex = 12;
            this.chkDrawLines.Text = "Random Lines";
            this.chkDrawLines.UseVisualStyleBackColor = true;
            this.chkDrawLines.CheckedChanged += new System.EventHandler(this.chkDrawLines_CheckedChanged);
            // 
            // slider3dScale
            // 
            this.slider3dScale.Location = new System.Drawing.Point(12, 64);
            this.slider3dScale.Maximum = 16;
            this.slider3dScale.Minimum = -16;
            this.slider3dScale.Name = "slider3dScale";
            this.slider3dScale.Size = new System.Drawing.Size(260, 45);
            this.slider3dScale.SmallChange = 2;
            this.slider3dScale.TabIndex = 4;
            this.slider3dScale.TickFrequency = 2;
            this.slider3dScale.Scroll += new System.EventHandler(this.slider3dScale_Scroll);
            // 
            // sliderHeight
            // 
            this.sliderHeight.Location = new System.Drawing.Point(146, 166);
            this.sliderHeight.Maximum = 20;
            this.sliderHeight.Minimum = 1;
            this.sliderHeight.Name = "sliderHeight";
            this.sliderHeight.Size = new System.Drawing.Size(126, 45);
            this.sliderHeight.TabIndex = 6;
            this.sliderHeight.Value = 5;
            this.sliderHeight.Scroll += new System.EventHandler(this.sliderHeight_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "2D Scale";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "3D Scale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Depth";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Block Width";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(143, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Block Height";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Left-Right";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(143, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Up-Down";
            // 
            // sliderTranslateY
            // 
            this.sliderTranslateY.Location = new System.Drawing.Point(147, 217);
            this.sliderTranslateY.Maximum = 20;
            this.sliderTranslateY.Minimum = -20;
            this.sliderTranslateY.Name = "sliderTranslateY";
            this.sliderTranslateY.Size = new System.Drawing.Size(126, 45);
            this.sliderTranslateY.TabIndex = 13;
            this.sliderTranslateY.Scroll += new System.EventHandler(this.sliderTranslateY_Scroll);
            // 
            // sliderTranslateX
            // 
            this.sliderTranslateX.Location = new System.Drawing.Point(13, 217);
            this.sliderTranslateX.Maximum = 20;
            this.sliderTranslateX.Minimum = -20;
            this.sliderTranslateX.Name = "sliderTranslateX";
            this.sliderTranslateX.Size = new System.Drawing.Size(127, 45);
            this.sliderTranslateX.TabIndex = 12;
            this.sliderTranslateX.Scroll += new System.EventHandler(this.sliderTranslateX_Scroll);
            // 
            // lblDebugOutput
            // 
            this.lblDebugOutput.AutoSize = true;
            this.lblDebugOutput.Location = new System.Drawing.Point(645, 270);
            this.lblDebugOutput.Name = "lblDebugOutput";
            this.lblDebugOutput.Size = new System.Drawing.Size(11, 13);
            this.lblDebugOutput.TabIndex = 5;
            this.lblDebugOutput.Text = "*";
            // 
            // groupButtonMatrix
            // 
            this.groupButtonMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupButtonMatrix.Location = new System.Drawing.Point(12, 268);
            this.groupButtonMatrix.Name = "groupButtonMatrix";
            this.groupButtonMatrix.Size = new System.Drawing.Size(321, 190);
            this.groupButtonMatrix.TabIndex = 16;
            this.groupButtonMatrix.TabStop = false;
            this.groupButtonMatrix.Text = "Blocks to Render (Click My Blocks Please!)";
            // 
            // chkDrawLeft
            // 
            this.chkDrawLeft.AutoSize = true;
            this.chkDrawLeft.Checked = true;
            this.chkDrawLeft.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDrawLeft.Location = new System.Drawing.Point(135, 21);
            this.chkDrawLeft.Name = "chkDrawLeft";
            this.chkDrawLeft.Size = new System.Drawing.Size(44, 17);
            this.chkDrawLeft.TabIndex = 17;
            this.chkDrawLeft.Text = "Left";
            this.chkDrawLeft.UseVisualStyleBackColor = true;
            this.chkDrawLeft.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkDrawFront
            // 
            this.chkDrawFront.AutoSize = true;
            this.chkDrawFront.Checked = true;
            this.chkDrawFront.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDrawFront.Location = new System.Drawing.Point(185, 21);
            this.chkDrawFront.Name = "chkDrawFront";
            this.chkDrawFront.Size = new System.Drawing.Size(50, 17);
            this.chkDrawFront.TabIndex = 18;
            this.chkDrawFront.Text = "Front";
            this.chkDrawFront.UseVisualStyleBackColor = true;
            this.chkDrawFront.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkDrawRight
            // 
            this.chkDrawRight.AutoSize = true;
            this.chkDrawRight.Checked = true;
            this.chkDrawRight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDrawRight.Location = new System.Drawing.Point(241, 21);
            this.chkDrawRight.Name = "chkDrawRight";
            this.chkDrawRight.Size = new System.Drawing.Size(51, 17);
            this.chkDrawRight.TabIndex = 19;
            this.chkDrawRight.Text = "Right";
            this.chkDrawRight.UseVisualStyleBackColor = true;
            this.chkDrawRight.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // buttonReferencePic
            // 
            this.buttonReferencePic.Location = new System.Drawing.Point(135, 44);
            this.buttonReferencePic.Name = "buttonReferencePic";
            this.buttonReferencePic.Size = new System.Drawing.Size(139, 23);
            this.buttonReferencePic.TabIndex = 20;
            this.buttonReferencePic.Text = "Load Reference Picture";
            this.buttonReferencePic.UseVisualStyleBackColor = true;
            this.buttonReferencePic.Click += new System.EventHandler(this.buttonReferencePic_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.chkShade);
            this.groupBox1.Controls.Add(this.sliderProjectorWidth);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.chkRefPic);
            this.groupBox1.Controls.Add(this.sliderProjectorHeight);
            this.groupBox1.Controls.Add(this.buttonReferencePic);
            this.groupBox1.Controls.Add(this.chkDrawLeft);
            this.groupBox1.Controls.Add(this.chkDrawLines);
            this.groupBox1.Controls.Add(this.chkDrawFront);
            this.groupBox1.Controls.Add(this.chkDrawRight);
            this.groupBox1.Location = new System.Drawing.Point(339, 268);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 190);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Projector Controls";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(138, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Height";
            // 
            // chkShade
            // 
            this.chkShade.AutoSize = true;
            this.chkShade.Checked = true;
            this.chkShade.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShade.Location = new System.Drawing.Point(7, 71);
            this.chkShade.Name = "chkShade";
            this.chkShade.Size = new System.Drawing.Size(57, 17);
            this.chkShade.TabIndex = 22;
            this.chkShade.Text = "Shade";
            this.chkShade.UseVisualStyleBackColor = true;
            this.chkShade.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // sliderProjectorWidth
            // 
            this.sliderProjectorWidth.LargeChange = 32;
            this.sliderProjectorWidth.Location = new System.Drawing.Point(7, 103);
            this.sliderProjectorWidth.Maximum = 320;
            this.sliderProjectorWidth.Minimum = 32;
            this.sliderProjectorWidth.Name = "sliderProjectorWidth";
            this.sliderProjectorWidth.Size = new System.Drawing.Size(127, 45);
            this.sliderProjectorWidth.SmallChange = 8;
            this.sliderProjectorWidth.TabIndex = 18;
            this.sliderProjectorWidth.TickFrequency = 32;
            this.sliderProjectorWidth.Value = 120;
            this.sliderProjectorWidth.Scroll += new System.EventHandler(this.sliderProjectorWidth_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Width";
            // 
            // chkRefPic
            // 
            this.chkRefPic.AutoSize = true;
            this.chkRefPic.Checked = true;
            this.chkRefPic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRefPic.Location = new System.Drawing.Point(7, 48);
            this.chkRefPic.Name = "chkRefPic";
            this.chkRefPic.Size = new System.Drawing.Size(122, 17);
            this.chkRefPic.TabIndex = 21;
            this.chkRefPic.Text = "Draw Reference Pic";
            this.chkRefPic.UseVisualStyleBackColor = true;
            this.chkRefPic.CheckedChanged += new System.EventHandler(this.chkRefPic_CheckedChanged);
            // 
            // sliderProjectorHeight
            // 
            this.sliderProjectorHeight.LargeChange = 32;
            this.sliderProjectorHeight.Location = new System.Drawing.Point(141, 103);
            this.sliderProjectorHeight.Maximum = 320;
            this.sliderProjectorHeight.Minimum = 32;
            this.sliderProjectorHeight.Name = "sliderProjectorHeight";
            this.sliderProjectorHeight.Size = new System.Drawing.Size(126, 45);
            this.sliderProjectorHeight.SmallChange = 8;
            this.sliderProjectorHeight.TabIndex = 19;
            this.sliderProjectorHeight.TickFrequency = 32;
            this.sliderProjectorHeight.Value = 150;
            this.sliderProjectorHeight.Scroll += new System.EventHandler(this.sliderProjectorHeight_Scroll);
            // 
            // buttonSaveMatrixJson
            // 
            this.buttonSaveMatrixJson.Location = new System.Drawing.Point(500, 46);
            this.buttonSaveMatrixJson.Name = "buttonSaveMatrixJson";
            this.buttonSaveMatrixJson.Size = new System.Drawing.Size(139, 23);
            this.buttonSaveMatrixJson.TabIndex = 25;
            this.buttonSaveMatrixJson.Text = "Save matrix";
            this.buttonSaveMatrixJson.UseVisualStyleBackColor = true;
            this.buttonSaveMatrixJson.Click += new System.EventHandler(this.buttonSaveMatrixJson_Click);
            // 
            // buttonParseStringRequest
            // 
            this.buttonParseStringRequest.Location = new System.Drawing.Point(500, 17);
            this.buttonParseStringRequest.Name = "buttonParseStringRequest";
            this.buttonParseStringRequest.Size = new System.Drawing.Size(139, 23);
            this.buttonParseStringRequest.TabIndex = 24;
            this.buttonParseStringRequest.Text = "Load matrix from JSON";
            this.buttonParseStringRequest.UseVisualStyleBackColor = true;
            this.buttonParseStringRequest.Click += new System.EventHandler(this.buttonParseStringRequest_Click);
            // 
            // txtJsonRequests
            // 
            this.txtJsonRequests.Location = new System.Drawing.Point(332, 17);
            this.txtJsonRequests.Multiline = true;
            this.txtJsonRequests.Name = "txtJsonRequests";
            this.txtJsonRequests.Size = new System.Drawing.Size(162, 243);
            this.txtJsonRequests.TabIndex = 23;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 485);
            this.Controls.Add(this.buttonSaveMatrixJson);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonParseStringRequest);
            this.Controls.Add(this.groupButtonMatrix);
            this.Controls.Add(this.txtJsonRequests);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sliderTranslateY);
            this.Controls.Add(this.sliderTranslateX);
            this.Controls.Add(this.sliderHeight);
            this.Controls.Add(this.slider3dScale);
            this.Controls.Add(this.sliderDepth);
            this.Controls.Add(this.sliderWidth);
            this.Controls.Add(this.slider2dScale);
            this.Controls.Add(this.lblDebugOutput);
            this.Name = "MainForm";
            this.Text = "Perspective Generator";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.slider2dScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider3dScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTranslateY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTranslateX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderProjectorWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderProjectorHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar slider2dScale;
        private System.Windows.Forms.TrackBar sliderWidth;
        private System.Windows.Forms.TrackBar sliderDepth;
        private System.Windows.Forms.TrackBar slider3dScale;
        private System.Windows.Forms.TrackBar sliderHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.CheckBox chkDrawLines;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar sliderTranslateY;
        private System.Windows.Forms.TrackBar sliderTranslateX;
        private System.Windows.Forms.Label lblDebugOutput;
        private System.Windows.Forms.GroupBox groupButtonMatrix;
        public System.Windows.Forms.CheckBox chkDrawLeft;
        public System.Windows.Forms.CheckBox chkDrawFront;
        public System.Windows.Forms.CheckBox chkDrawRight;
        private System.Windows.Forms.Button buttonReferencePic;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.CheckBox chkRefPic;
        private System.Windows.Forms.CheckBox chkShade;
        private System.Windows.Forms.Button buttonParseStringRequest;
        private System.Windows.Forms.TextBox txtJsonRequests;
        private System.Windows.Forms.Button buttonSaveMatrixJson;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar sliderProjectorWidth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar sliderProjectorHeight;
    }
}

