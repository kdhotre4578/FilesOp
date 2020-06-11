using System.Linq;
using System.IO;
using System;
using FilesOpBLayer.Enums;

namespace FilesOpBLayer
{
    public delegate void delFileCopyStatusEventArgs(FileCopyStatusEventArgs fileCopyStatusEventArgs);

    public class DirectoryOperations
    {
        #region Variable
        ProcessStatusMessage processStatus;
        #endregion
        
        #region Properties

        public int TotalFilesToProcess { get; private set; }

        public int ProcessedFileCount { get; private set; }

        public string ProcessingSourceFile { get; private set; }

        public string ProcessingDestinationFile { get; private set; }

        public string sourceFolder { get; set; }

        public string destinationFolder { get; set; }

        public CopyStatusDetail CopyStatusDetails { get; private set; }

        public Validator AttributeValidator { get; private set; }

        
        public event delFileCopyStatusEventArgs RaiseFileCopyStatus;

        #endregion

        #region Constructor
        
        public DirectoryOperations()
        {
            processStatus = new ProcessStatusMessage();
            this.AttributeValidator = new Validator();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Copies files and subfolders from source path to destination
        /// </summary>
        /// <param name="sourceFolder">Source Folder</param>
        /// <param name="destinationFolder">Destination Folder</param>
        /// <returns>Copy status via CopyStatusDetails attribute</returns>
        public void ProcessCopy(string sourceFolder, string destinationFolder)
        {
            this.sourceFolder = sourceFolder;
            this.destinationFolder = destinationFolder;

            ProcessCopyDirectory(sourceFolder, destinationFolder);
        }

        /// <summary>
        /// Copies files and subfolders from source path to destination. Both the paths needs to be provided explicitly.
        /// </summary>
        /// <param name="sourceFolder">Source Folder</param>
        /// <param name="destinationFolder">Destination Folder</param>
        /// <returns>Copy status via CopyStatusDetails attribute</returns>
        public void ProcessCopy()
        {
            ProcessCopyDirectory(this.sourceFolder, this.destinationFolder);
        }

        #endregion

        #region Private Methods

        private void ProcessCopyDirectory(string sourceFolder, string destinationFolder)
        {
            if (VerifyPathDetails())
            {
                try
                {
                    CopyDirectory(sourceFolder, destinationFolder);
                    SetCopyStatusDetails(this.processStatus.Get(CopyProcessStatus.CopySuccessful, this.ProcessedFileCount));
                }
                catch (Exception ex)
                {
                    SetCopyStatusDetails(this.processStatus.Get(CopyProcessStatus.CopyFailed, this.ProcessedFileCount, ex.Message));
                }
            }
        }

        private void SetCopyStatusDetails(CopyStatusDetail copyStatusDetail)
        {
            this.CopyStatusDetails = copyStatusDetail;
        }

        private bool VerifyPathDetails()
        {
            this.sourceFolder = this.AttributeValidator.VerifyFolderSuffix(this.sourceFolder);
            this.destinationFolder = this.AttributeValidator.VerifyFolderSuffix(this.destinationFolder);

            if (!this.AttributeValidator.IsValidPath(this.sourceFolder))
            {
                SetCopyStatusDetails(this.processStatus.Get(CopyProcessStatus.InvalidSourceFolderPath));
                return false;
            }
            else if (!this.AttributeValidator.IsValidPath(this.destinationFolder))
            {
                SetCopyStatusDetails(this.processStatus.Get(CopyProcessStatus.InvalidDestinationFolderPath));
                return false;
            }
            else if (this.AttributeValidator.ArePathSame(this.sourceFolder, this.destinationFolder))
            {
                SetCopyStatusDetails(this.processStatus.Get(CopyProcessStatus.SourceDestinationSame));
                return false;
            }

            GetFileCount(this.sourceFolder);

            if (this.TotalFilesToProcess == 0)
            {
                SetCopyStatusDetails(this.processStatus.Get(CopyProcessStatus.SourceFolderEmpty));
                return false;
            }

            return true;
        }

        private void CopyDirectory(string sourceFolder, string destinationFolder)
        {
            CopyFiles(sourceFolder, destinationFolder);

            var directories = Directory.GetDirectories(sourceFolder);

            if ((directories != null) && (directories.Length > 0))
            {
                foreach (var directory in directories)
                {
                    CopyDirectory(directory, destinationFolder + "\\" + GetName(directory));
                }
            }
        }

        private void CopyFiles(string sourceFolder, string destinationFolder)
        {
            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }

            var files = Directory.GetFiles(sourceFolder);

            foreach (var sourceFile in files)
            {
                string destinationFile = destinationFolder + "\\" + GetName(sourceFile);

                if (!File.Exists(destinationFile))
                {
                    File.Copy(sourceFile, destinationFolder + "\\" + GetName(sourceFile));
                }
                else
                {
                    // As of now, added the replace functionality for testing purpose only. 
                    // Here in future, functionality can be added to ask user to replace file or no.

                    File.Delete(destinationFolder + "\\" + GetName(sourceFile));
                    File.Copy(sourceFile, destinationFolder + "\\" + GetName(sourceFile));
                }

                SetFileCopyStatus(sourceFile, destinationFile);
            }
        }

        /// <summary>
        /// Provides count of file(s) available for copying in source folder
        /// </summary>
        /// <param name="sourceFolder">Source Folder</param>
        /// <returns>Count of files for copying</returns>
        public int GetFileCount(string sourceFolder)
        {
            if (this.AttributeValidator.IsValidPath(sourceFolder))
            {
                ResetCounters();
                GetFileCountInDirectory(sourceFolder);
            }

            return TotalFilesToProcess;
        }

        private void GetFileCountInDirectory(string sourcePath)
        {
            TotalFilesToProcess += Directory.GetFiles(sourcePath).Count();

            var directories = Directory.GetDirectories(sourcePath);

            if ((directories != null) && (directories.Length > 0))
            {
                foreach (var directory in directories)
                {
                    GetFileCountInDirectory(directory);
                }
            }
        }

        private string GetName(string path)
        {
            string[] folders = path.Split('\\');
            return folders[folders.Length - 1];
        }

        private void ResetCounters()
        {
            TotalFilesToProcess = 0;
            ProcessedFileCount = 0;
        }

        private void SetFileCopyStatus(string sourceFile, string destinationFile)
        {
            ProcessedFileCount++;
            ProcessingSourceFile = sourceFile;
            ProcessingDestinationFile = destinationFile;

            RaiseFileCopyStatus?.Invoke(new FileCopyStatusEventArgs()
            {
                ProcessedFileCount = this.ProcessedFileCount,
                ProcessingSourceFile = this.ProcessingSourceFile,
                ProcessingDestinationFile = this.ProcessingDestinationFile
            });
        }

        #endregion
    }
}