﻿namespace NAudioDemo
{
    partial class MP3StreamingForm
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
            this.components = new System.ComponentModel.Container();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.textBoxStreamingUrl = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.progressBarBuffer = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(12, 98);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // textBoxStreamingUrl
            // 
            this.textBoxStreamingUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStreamingUrl.Location = new System.Drawing.Point(97, 12);
            this.textBoxStreamingUrl.Name = "textBoxStreamingUrl";
            this.textBoxStreamingUrl.Size = new System.Drawing.Size(228, 20);
            this.textBoxStreamingUrl.TabIndex = 1;
            this.textBoxStreamingUrl.Text = "http://radio.reaper.fm/stream/";
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Streaming URL:";
            // 
            // progressBarBuffer
            // 
            this.progressBarBuffer.Location = new System.Drawing.Point(97, 39);
            this.progressBarBuffer.Name = "progressBarBuffer";
            this.progressBarBuffer.Size = new System.Drawing.Size(228, 23);
            this.progressBarBuffer.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Buffered:";
            // 
            // MP3StreamingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 133);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBarBuffer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxStreamingUrl);
            this.Controls.Add(this.buttonPlay);
            this.Name = "MP3StreamingForm";
            this.Text = "MP3 Streaming";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MP3StreamingForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.TextBox textBoxStreamingUrl;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBarBuffer;
        private System.Windows.Forms.Label label2;
    }
}