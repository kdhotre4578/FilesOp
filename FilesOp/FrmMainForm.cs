using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilesOpBLayer;
using FilesOpBLayer.Enums;

namespace FilesOp
{
    public partial class FrmMainForm : Form
    {
        #region Variables

        private DirectoryOperations directoryOperations;

        private const string DEFAULT_SOURCE_PATH_STRING = "defaultSourcePath";

        private const string DEFAULT_DESTINATION_PATH_STRING = "defaultDestinationPath";

        #endregion

        #region Constructor

        public FrmMainForm()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            directoryOperations = new DirectoryOperations();

            directoryOperations.RaiseFileCopyStatus += DirectoryOperations_RaiseFileCopyStatus;
        }

        #endregion

        #region Form & control events

        private void FrmMainForm_Load(object sender, EventArgs e)
        {
            this.ResetProgressBar();
            this.InitialiseFolderPaths();
        }

        private void BtnOpenSourceFolder_Click(object sender, EventArgs e)
        {
            TrySetTextPath(txtSourcePath.Text);    

            if (commonfolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtSourcePath.Text = commonfolderBrowserDialog.SelectedPath;
            }
        }

        private void BtnOpenDestinationFolder_Click(object sender, EventArgs e)
        {
            TrySetTextPath(txtDestinationPath.Text);

            if (commonfolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtDestinationPath.Text = commonfolderBrowserDialog.SelectedPath;
            }
        }
        
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            this.ResetProgressBar();

            string sourcePath = txtSourcePath.Text.Trim();
            string destinationPath = txtDestinationPath.Text.Trim();

            this.ProcessCopy(sourcePath, destinationPath);
        }

        #endregion

        #region Private Methods

        private void InitialiseFolderPaths()
        {
            ConfigMgr configManager = new ConfigMgr(directoryOperations.AttributeValidator);

            this.txtSourcePath.Text = configManager.InitialisePath(DEFAULT_SOURCE_PATH_STRING);
            this.txtDestinationPath.Text = configManager.InitialisePath(DEFAULT_DESTINATION_PATH_STRING);

            this.commonfolderBrowserDialog.SelectedPath = this.txtSourcePath.Text;
        }

        private void ProcessCopy(string sourcePath, string destinationPath)
        {
            try
            {
                progressBarCompletion.Maximum = directoryOperations.GetFileCount(sourcePath);

                // Execute the copying process
                this.ProcessCopyAsync(sourcePath, destinationPath);

            }
            catch (Exception ex)
            {
                DisplayMessage("Issue appeared while copying. \n\n Reason : " + ex.Message, MessageBoxIcon.Error);
            }
        }

        private async void ProcessCopyAsync(string sourcePath, string destinationPath)
        {
            btnCopy.Enabled = false;

            await Task.Run(() => directoryOperations.ProcessCopy(sourcePath, destinationPath));

            DisplayMessage(directoryOperations.CopyStatusDetails);

            btnCopy.Enabled = true;
            btnCopy.Focus();
        }

        private void TrySetTextPath(string path)
        {
            if (path != string.Empty && this.directoryOperations.AttributeValidator.IsValidPath(path))
            {
                string temp = commonfolderBrowserDialog.SelectedPath;
                try
                {
                    commonfolderBrowserDialog.SelectedPath = path;
                }
                catch
                {
                    commonfolderBrowserDialog.SelectedPath = temp;
                }
            }
        }

        private delegate void SafeTextCallBackDelegate(string text);

        private delegate void SafeValueCallBackDelegate(int value);

        private void DirectoryOperations_RaiseFileCopyStatus(FileCopyStatusEventArgs fileCopyStatusEventArgs)
        {
            labelFromTextSafely(fileCopyStatusEventArgs.ProcessingSourceFile);
            labelToTextSafely(fileCopyStatusEventArgs.ProcessingDestinationFile);
            SetValueSafely(fileCopyStatusEventArgs.ProcessedFileCount);
        }

        private void SetValueSafely(int value)
        {
            if (progressBarCompletion.InvokeRequired)
            {
                var del = new SafeValueCallBackDelegate(SetValueSafely);
                progressBarCompletion.Invoke(del, new object[] { value });
            }
            else
            {
                progressBarCompletion.Value = value;
            }
        }

        private void labelFromTextSafely(string text)
        {
            if (lblFrom.InvokeRequired)
            {
                var d = new SafeTextCallBackDelegate(labelFromTextSafely);
                lblFrom.Invoke(d, new object[] { text });
            }
            else
            {
                lblFrom.Text = text;
            }
        }

        private void labelToTextSafely(string text)
        {
            if (lblTo.InvokeRequired)
            {
                var d = new SafeTextCallBackDelegate(labelToTextSafely);
                lblTo.Invoke(d, new object[] { text });
            }
            else
            {
                lblTo.Text = text;
            }
        }

        private void DisplayMessage(string text, MessageBoxIcon messageBoxIcon, string title = "")
        {
            MessageBox.Show(text, title == string.Empty ? this.Text : title, MessageBoxButtons.OK, messageBoxIcon);
        }

        private void DisplayMessage(CopyStatusDetail copyStatusDetail)
        {
            MessageBox.Show(copyStatusDetail.Message, 
                                copyStatusDetail.Title, 
                                MessageBoxButtons.OK,
                                copyStatusDetail.CopyStatus == CopyStatus.Successful ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        private void ResetProgressBar()
        {
            progressBarCompletion.Value = 0;
            progressBarCompletion.Maximum = 0;

            lblFrom.Text = "";
            lblTo.Text = "";
        }
        
        #endregion
    }
}
