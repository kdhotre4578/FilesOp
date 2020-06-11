namespace FilesOpBLayer.Enums
{
    class ClsEnums
    {
    }

    internal enum CopyProcessStatus
    {
        InvalidSourceFolderPath,
        InvalidDestinationFolderPath,
        SourceFolderEmpty,
        SourceDestinationSame,
        CopySuccessful,
        CopyFailed
    }

    public enum CopyStatus
    {
        Successful,
        Failed,
    }
}
