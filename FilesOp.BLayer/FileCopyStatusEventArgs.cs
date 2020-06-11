using System;

namespace FilesOpBLayer
{
    public class FileCopyStatusEventArgs : EventArgs
    {
        public int ProcessedFileCount { get; set; }

        public string ProcessingSourceFile { get; set; }

        public string ProcessingDestinationFile { get; set; }
    }
}
