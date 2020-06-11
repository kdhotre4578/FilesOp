using FilesOpBLayer.Enums;

namespace FilesOpBLayer
{
    public class CopyStatusDetail
    {
        public CopyStatusDetail(string title, string message, CopyStatus copyStatus)
        {
            this.Title = title;
            this.Message = message;
            this.CopyStatus = copyStatus;
        }

        public string Title { get; set; }

        public string Message { get; }

        public CopyStatus CopyStatus { get; }
    }
}
