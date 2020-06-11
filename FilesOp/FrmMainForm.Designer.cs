namespace FilesOp
{
    partial class FrmMainForm
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
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.lblSourceFolderPath = new System.Windows.Forms.Label();
            this.btnOpenSourceFolder = new System.Windows.Forms.Button();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.gbDestination = new System.Windows.Forms.GroupBox();
            this.lblDestFolderPath = new System.Windows.Forms.Label();
            this.btnOpenDestinationFolder = new System.Windows.Forms.Button();
            this.txtDestinationPath = new System.Windows.Forms.TextBox();
            this.commonfolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBarCompletion = new System.Windows.Forms.ProgressBar();
            this.btnCopy = new System.Windows.Forms.Button();
            this.gbCopy = new System.Windows.Forms.GroupBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.gbProgress = new System.Windows.Forms.GroupBox();
            this.gbSource.SuspendLayout();
            this.gbDestination.SuspendLayout();
            this.gbCopy.SuspendLayout();
            this.gbProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSource
            // 
            this.gbSource.Controls.Add(this.lblSourceFolderPath);
            this.gbSource.Controls.Add(this.btnOpenSourceFolder);
            this.gbSource.Controls.Add(this.txtSourcePath);
            this.gbSource.Location = new System.Drawing.Point(12, 12);
            this.gbSource.Name = "gbSource";
            this.gbSource.Size = new System.Drawing.Size(552, 114);
            this.gbSource.TabIndex = 0;
            this.gbSource.TabStop = false;
            this.gbSource.Text = "Source";
            // 
            // lblSourceFolderPath
            // 
            this.lblSourceFolderPath.AutoSize = true;
            this.lblSourceFolderPath.Location = new System.Drawing.Point(53, 48);
            this.lblSourceFolderPath.Name = "lblSourceFolderPath";
            this.lblSourceFolderPath.Size = new System.Drawing.Size(93, 17);
            this.lblSourceFolderPath.TabIndex = 3;
            this.lblSourceFolderPath.Text = "Folder Path : ";
            // 
            // btnOpenSourceFolder
            // 
            this.btnOpenSourceFolder.Location = new System.Drawing.Point(428, 41);
            this.btnOpenSourceFolder.Name = "btnOpenSourceFolder";
            this.btnOpenSourceFolder.Size = new System.Drawing.Size(99, 33);
            this.btnOpenSourceFolder.TabIndex = 1;
            this.btnOpenSourceFolder.Text = "Open Folder";
            this.btnOpenSourceFolder.UseVisualStyleBackColor = true;
            this.btnOpenSourceFolder.Click += new System.EventHandler(this.BtnOpenSourceFolder_Click);
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Location = new System.Drawing.Point(152, 46);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(249, 22);
            this.txtSourcePath.TabIndex = 0;
            // 
            // gbDestination
            // 
            this.gbDestination.Controls.Add(this.lblDestFolderPath);
            this.gbDestination.Controls.Add(this.btnOpenDestinationFolder);
            this.gbDestination.Controls.Add(this.txtDestinationPath);
            this.gbDestination.Location = new System.Drawing.Point(12, 147);
            this.gbDestination.Name = "gbDestination";
            this.gbDestination.Size = new System.Drawing.Size(552, 114);
            this.gbDestination.TabIndex = 3;
            this.gbDestination.TabStop = false;
            this.gbDestination.Text = "Destination";
            // 
            // lblDestFolderPath
            // 
            this.lblDestFolderPath.AutoSize = true;
            this.lblDestFolderPath.Location = new System.Drawing.Point(53, 50);
            this.lblDestFolderPath.Name = "lblDestFolderPath";
            this.lblDestFolderPath.Size = new System.Drawing.Size(93, 17);
            this.lblDestFolderPath.TabIndex = 4;
            this.lblDestFolderPath.Text = "Folder Path : ";
            // 
            // btnOpenDestinationFolder
            // 
            this.btnOpenDestinationFolder.Location = new System.Drawing.Point(428, 43);
            this.btnOpenDestinationFolder.Name = "btnOpenDestinationFolder";
            this.btnOpenDestinationFolder.Size = new System.Drawing.Size(99, 33);
            this.btnOpenDestinationFolder.TabIndex = 1;
            this.btnOpenDestinationFolder.Text = "Open Folder";
            this.btnOpenDestinationFolder.UseVisualStyleBackColor = true;
            this.btnOpenDestinationFolder.Click += new System.EventHandler(this.BtnOpenDestinationFolder_Click);
            // 
            // txtDestinationPath
            // 
            this.txtDestinationPath.Location = new System.Drawing.Point(152, 48);
            this.txtDestinationPath.Name = "txtDestinationPath";
            this.txtDestinationPath.Size = new System.Drawing.Size(251, 22);
            this.txtDestinationPath.TabIndex = 0;
            // 
            // progressBarCompletion
            // 
            this.progressBarCompletion.Location = new System.Drawing.Point(13, 30);
            this.progressBarCompletion.Name = "progressBarCompletion";
            this.progressBarCompletion.Size = new System.Drawing.Size(697, 23);
            this.progressBarCompletion.TabIndex = 4;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(40, 28);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(86, 33);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // gbCopy
            // 
            this.gbCopy.Controls.Add(this.btnCopy);
            this.gbCopy.Location = new System.Drawing.Point(581, 108);
            this.gbCopy.Name = "gbCopy";
            this.gbCopy.Size = new System.Drawing.Size(161, 84);
            this.gbCopy.TabIndex = 6;
            this.gbCopy.TabStop = false;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(10, 72);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(52, 17);
            this.lblFrom.TabIndex = 8;
            this.lblFrom.Text = "From : ";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(10, 102);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(37, 17);
            this.lblTo.TabIndex = 9;
            this.lblTo.Text = "To : ";
            // 
            // gbProgress
            // 
            this.gbProgress.Controls.Add(this.progressBarCompletion);
            this.gbProgress.Controls.Add(this.lblTo);
            this.gbProgress.Controls.Add(this.lblFrom);
            this.gbProgress.Location = new System.Drawing.Point(12, 281);
            this.gbProgress.Name = "gbProgress";
            this.gbProgress.Size = new System.Drawing.Size(730, 136);
            this.gbProgress.TabIndex = 10;
            this.gbProgress.TabStop = false;
            this.gbProgress.Text = "Progress";
            // 
            // FrmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 431);
            this.Controls.Add(this.gbProgress);
            this.Controls.Add(this.gbCopy);
            this.Controls.Add(this.gbDestination);
            this.Controls.Add(this.gbSource);
            this.Name = "FrmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = this.ProductName;
            this.Load += new System.EventHandler(this.FrmMainForm_Load);
            this.gbSource.ResumeLayout(false);
            this.gbSource.PerformLayout();
            this.gbDestination.ResumeLayout(false);
            this.gbDestination.PerformLayout();
            this.gbCopy.ResumeLayout(false);
            this.gbProgress.ResumeLayout(false);
            this.gbProgress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.Button btnOpenSourceFolder;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.GroupBox gbDestination;
        private System.Windows.Forms.Button btnOpenDestinationFolder;
        private System.Windows.Forms.TextBox txtDestinationPath;
        private System.Windows.Forms.FolderBrowserDialog commonfolderBrowserDialog;
        private System.Windows.Forms.ProgressBar progressBarCompletion;
        private System.Windows.Forms.Label lblSourceFolderPath;
        private System.Windows.Forms.Label lblDestFolderPath;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.GroupBox gbCopy;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.GroupBox gbProgress;
    }
}

