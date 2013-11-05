namespace musicalFloppy3_client
{
    partial class Form1
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstBxOutput = new System.Windows.Forms.ListBox();
            this.tbCtrl = new System.Windows.Forms.TabControl();
            this.tbPgDebug = new System.Windows.Forms.TabPage();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cmbBoxPorts = new System.Windows.Forms.ComboBox();
            this.btnBackToZero = new System.Windows.Forms.Button();
            this.btnSetFrequency = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtBxFreq = new System.Windows.Forms.TextBox();
            this.tbPgMidiDebug = new System.Windows.Forms.TabPage();
            this.grpBxInfo = new System.Windows.Forms.GroupBox();
            this.lblQuarterNoteDelta = new System.Windows.Forms.Label();
            this.lblTracks = new System.Windows.Forms.Label();
            this.lblFormat = new System.Windows.Forms.Label();
            this.lstMidiHexView = new System.Windows.Forms.ListBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtMidiPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnPauseMidi = new System.Windows.Forms.Button();
            this.btnContinueMidi = new System.Windows.Forms.Button();
            this.tbCtrl.SuspendLayout();
            this.tbPgDebug.SuspendLayout();
            this.tbPgMidiDebug.SuspendLayout();
            this.grpBxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstBxOutput
            // 
            this.lstBxOutput.FormattingEnabled = true;
            this.lstBxOutput.Location = new System.Drawing.Point(333, 2);
            this.lstBxOutput.Name = "lstBxOutput";
            this.lstBxOutput.Size = new System.Drawing.Size(304, 381);
            this.lstBxOutput.TabIndex = 4;
            // 
            // tbCtrl
            // 
            this.tbCtrl.Controls.Add(this.tbPgDebug);
            this.tbCtrl.Controls.Add(this.tbPgMidiDebug);
            this.tbCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCtrl.Location = new System.Drawing.Point(0, 0);
            this.tbCtrl.Name = "tbCtrl";
            this.tbCtrl.SelectedIndex = 0;
            this.tbCtrl.Size = new System.Drawing.Size(651, 415);
            this.tbCtrl.TabIndex = 11;
            // 
            // tbPgDebug
            // 
            this.tbPgDebug.Controls.Add(this.lstBxOutput);
            this.tbPgDebug.Controls.Add(this.btnConnect);
            this.tbPgDebug.Controls.Add(this.cmbBoxPorts);
            this.tbPgDebug.Controls.Add(this.btnBackToZero);
            this.tbPgDebug.Controls.Add(this.btnSetFrequency);
            this.tbPgDebug.Controls.Add(this.btnTest);
            this.tbPgDebug.Controls.Add(this.txtBxFreq);
            this.tbPgDebug.Location = new System.Drawing.Point(4, 22);
            this.tbPgDebug.Name = "tbPgDebug";
            this.tbPgDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tbPgDebug.Size = new System.Drawing.Size(643, 389);
            this.tbPgDebug.TabIndex = 0;
            this.tbPgDebug.Text = "Debug";
            this.tbPgDebug.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(8, 6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect to";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cmbBoxPorts
            // 
            this.cmbBoxPorts.FormattingEnabled = true;
            this.cmbBoxPorts.Location = new System.Drawing.Point(87, 8);
            this.cmbBoxPorts.Name = "cmbBoxPorts";
            this.cmbBoxPorts.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxPorts.TabIndex = 1;
            // 
            // btnBackToZero
            // 
            this.btnBackToZero.Location = new System.Drawing.Point(6, 214);
            this.btnBackToZero.Name = "btnBackToZero";
            this.btnBackToZero.Size = new System.Drawing.Size(75, 23);
            this.btnBackToZero.TabIndex = 10;
            this.btnBackToZero.Text = "Back to zero";
            this.btnBackToZero.UseVisualStyleBackColor = true;
            this.btnBackToZero.Click += new System.EventHandler(this.btnBackToZero_Click);
            // 
            // btnSetFrequency
            // 
            this.btnSetFrequency.Location = new System.Drawing.Point(8, 291);
            this.btnSetFrequency.Name = "btnSetFrequency";
            this.btnSetFrequency.Size = new System.Drawing.Size(75, 23);
            this.btnSetFrequency.TabIndex = 2;
            this.btnSetFrequency.Text = "Set";
            this.btnSetFrequency.UseVisualStyleBackColor = true;
            this.btnSetFrequency.Click += new System.EventHandler(this.btnSetFrequency_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(6, 185);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 9;
            this.btnTest.Text = "test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtBxFreq
            // 
            this.txtBxFreq.Location = new System.Drawing.Point(87, 293);
            this.txtBxFreq.Name = "txtBxFreq";
            this.txtBxFreq.Size = new System.Drawing.Size(100, 20);
            this.txtBxFreq.TabIndex = 3;
            // 
            // tbPgMidiDebug
            // 
            this.tbPgMidiDebug.Controls.Add(this.btnContinueMidi);
            this.tbPgMidiDebug.Controls.Add(this.btnPauseMidi);
            this.tbPgMidiDebug.Controls.Add(this.grpBxInfo);
            this.tbPgMidiDebug.Controls.Add(this.lstMidiHexView);
            this.tbPgMidiDebug.Controls.Add(this.btnLoad);
            this.tbPgMidiDebug.Controls.Add(this.txtMidiPath);
            this.tbPgMidiDebug.Controls.Add(this.btnBrowse);
            this.tbPgMidiDebug.Location = new System.Drawing.Point(4, 22);
            this.tbPgMidiDebug.Name = "tbPgMidiDebug";
            this.tbPgMidiDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tbPgMidiDebug.Size = new System.Drawing.Size(643, 389);
            this.tbPgMidiDebug.TabIndex = 1;
            this.tbPgMidiDebug.Text = "Midi Debug";
            this.tbPgMidiDebug.UseVisualStyleBackColor = true;
            // 
            // grpBxInfo
            // 
            this.grpBxInfo.Controls.Add(this.lblQuarterNoteDelta);
            this.grpBxInfo.Controls.Add(this.lblTracks);
            this.grpBxInfo.Controls.Add(this.lblFormat);
            this.grpBxInfo.Location = new System.Drawing.Point(311, 34);
            this.grpBxInfo.Name = "grpBxInfo";
            this.grpBxInfo.Size = new System.Drawing.Size(200, 347);
            this.grpBxInfo.TabIndex = 4;
            this.grpBxInfo.TabStop = false;
            this.grpBxInfo.Text = "Info";
            // 
            // lblQuarterNoteDelta
            // 
            this.lblQuarterNoteDelta.AutoSize = true;
            this.lblQuarterNoteDelta.Location = new System.Drawing.Point(7, 78);
            this.lblQuarterNoteDelta.Name = "lblQuarterNoteDelta";
            this.lblQuarterNoteDelta.Size = new System.Drawing.Size(128, 13);
            this.lblQuarterNoteDelta.TabIndex = 2;
            this.lblQuarterNoteDelta.Text = "Quarter Note Delta Ticks:";
            // 
            // lblTracks
            // 
            this.lblTracks.AutoSize = true;
            this.lblTracks.Location = new System.Drawing.Point(7, 49);
            this.lblTracks.Name = "lblTracks";
            this.lblTracks.Size = new System.Drawing.Size(40, 13);
            this.lblTracks.TabIndex = 1;
            this.lblTracks.Text = "Tracks";
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(7, 20);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(42, 13);
            this.lblFormat.TabIndex = 0;
            this.lblFormat.Text = "Format:";
            // 
            // lstMidiHexView
            // 
            this.lstMidiHexView.FormattingEnabled = true;
            this.lstMidiHexView.Location = new System.Drawing.Point(517, 39);
            this.lstMidiHexView.Name = "lstMidiHexView";
            this.lstMidiHexView.Size = new System.Drawing.Size(120, 342);
            this.lstMidiHexView.TabIndex = 3;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(3, 35);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtMidiPath
            // 
            this.txtMidiPath.Location = new System.Drawing.Point(84, 8);
            this.txtMidiPath.Name = "txtMidiPath";
            this.txtMidiPath.Size = new System.Drawing.Size(553, 20);
            this.txtMidiPath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(3, 6);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnPauseMidi
            // 
            this.btnPauseMidi.Location = new System.Drawing.Point(3, 64);
            this.btnPauseMidi.Name = "btnPauseMidi";
            this.btnPauseMidi.Size = new System.Drawing.Size(75, 23);
            this.btnPauseMidi.TabIndex = 5;
            this.btnPauseMidi.Text = "Pause";
            this.btnPauseMidi.UseVisualStyleBackColor = true;
            this.btnPauseMidi.Click += new System.EventHandler(this.btnPauseMidi_Click);
            // 
            // btnContinueMidi
            // 
            this.btnContinueMidi.Location = new System.Drawing.Point(84, 64);
            this.btnContinueMidi.Name = "btnContinueMidi";
            this.btnContinueMidi.Size = new System.Drawing.Size(75, 23);
            this.btnContinueMidi.TabIndex = 6;
            this.btnContinueMidi.Text = "Continue";
            this.btnContinueMidi.UseVisualStyleBackColor = true;
            this.btnContinueMidi.Click += new System.EventHandler(this.btnContinueMidi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 415);
            this.Controls.Add(this.tbCtrl);
            this.Name = "Form1";
            this.Text = "MusicalFloppyControlCenter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tbCtrl.ResumeLayout(false);
            this.tbPgDebug.ResumeLayout(false);
            this.tbPgDebug.PerformLayout();
            this.tbPgMidiDebug.ResumeLayout(false);
            this.tbPgMidiDebug.PerformLayout();
            this.grpBxInfo.ResumeLayout(false);
            this.grpBxInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstBxOutput;
        private System.Windows.Forms.TabControl tbCtrl;
        private System.Windows.Forms.TabPage tbPgDebug;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cmbBoxPorts;
        private System.Windows.Forms.Button btnBackToZero;
        private System.Windows.Forms.Button btnSetFrequency;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtBxFreq;
        private System.Windows.Forms.TabPage tbPgMidiDebug;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtMidiPath;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ListBox lstMidiHexView;
        private System.Windows.Forms.GroupBox grpBxInfo;
        private System.Windows.Forms.Label lblQuarterNoteDelta;
        private System.Windows.Forms.Label lblTracks;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.Button btnPauseMidi;
        private System.Windows.Forms.Button btnContinueMidi;
    }
}

