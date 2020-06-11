using FilesOpBLayer.Enums;

namespace FilesOpBLayer
{
    internal class ProcessStatusMessage
    {
        #region Public Methods

        /// <summary>
        /// Gets the message to display on the system based on processing status
        /// </summary>
        /// <param name="copyProcessStatus">process status</param>
        /// <param name="copiedFileCount">processed file count (if needed to display)</param>
        /// <param name="failedMessage">failed message if system has failed to process copying</param>
        /// <returns>Copy Status Details</returns>
        public CopyStatusDetail Get(CopyProcessStatus copyProcessStatus, int copiedFileCount = 0, string failedMessage = "")
        {
            CopyStatusDetail copyStatusDetail = null;
            
            switch (copyProcessStatus)
            {
                case CopyProcessStatus.InvalidSourceFolderPath:
                    copyStatusDetail = new CopyStatusDetail("Invalid Source Folder",
                        "Invalid source folder path! please enter correct one...", CopyStatus.Failed);
                    break;

                case CopyProcessStatus.InvalidDestinationFolderPath:
                    copyStatusDetail = new CopyStatusDetail("Invalid Destination Folder",
                            "Invalid destination folder path! please enter correct one...", CopyStatus.Failed);
                    break;

                case CopyProcessStatus.SourceFolderEmpty:
                    copyStatusDetail = new CopyStatusDetail("Source Folder Empty",
                            "Source Folder empty... No files to copy...", CopyStatus.Failed);
                    break;

                case CopyProcessStatus.SourceDestinationSame:
                    copyStatusDetail = new CopyStatusDetail("Same Folders",
                        "Source and destination path should be different! please correct...", CopyStatus.Failed);
                    break;

                case CopyProcessStatus.CopySuccessful:
                    copyStatusDetail = new CopyStatusDetail("Copy Successful",
                        "File(s) copied successfully.. Total File(s) Copied : " + copiedFileCount, CopyStatus.Successful);
                    break;

                case CopyProcessStatus.CopyFailed:
                    string message = "Failed to copy file(s).. Total File(s) Copied : " + copiedFileCount;
                    if (failedMessage != string.Empty)
                    {
                        message += "\n Reason : " + failedMessage;
                    }

                    copyStatusDetail = new CopyStatusDetail("Copy Failed", message, CopyStatus.Failed);

                    break;
            }

            return copyStatusDetail;
        }
    }

    #endregion
}
