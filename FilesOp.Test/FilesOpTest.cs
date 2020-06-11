using NUnit.Framework;
using FilesOpBLayer;

namespace FilesOp.Test
{
    [TestFixture]
    public class FilesOpTest
    {
        public DirectoryOperations GetDirOpsInstance()
        {
            return new DirectoryOperations();
        }

        [TestCase("C:\\Users\\Vicky\\Documents\\Test\\source\\T1")]
        [TestCase("C:\\Users\\Vicky\\Documents\\Test\\source\\")]
        public void VerifyPathValid_FolderPath_Returns_Valid(string folderPath)
        {
            Assert.IsTrue(GetDirOpsInstance().AttributeValidator.IsValidPath(folderPath));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("C:\\Users\\Vicky\\Documents\\Test\\source\\InvalidFolder")]
        [TestCase("C:\\Users \\Vicky\\Documents\\Test\\source\\")]
        public void VerifyPathInvalid_FolderPath_Returns_Invalid(string folderPath)
        {
            Assert.IsFalse(GetDirOpsInstance().AttributeValidator.IsValidPath(folderPath));
        }

        [TestCase("C:\\Users\\Vicky\\Documents\\Test\\source\\T1")]
        public void VerifyFileCountPresent_FolderPath_Returns_Count(string folderPath)
        {
            int expectedTotalFileCount = 3;
            Assert.AreEqual(expectedTotalFileCount, GetDirOpsInstance().GetFileCount(folderPath));
        }

        [TestCase("", "")]
        [TestCase("C:\\Users\\Vicky\\Documents\\Test\\source\\T1", "")]
        [TestCase("", "C:\\Users\\Vicky\\Documents\\Test\\destination")]
        [TestCase("C:\\Users\\Vicky\\Documents\\Test\\source\\T1", "C:\\Users\\Vicky\\Documents\\Test\\source\\T1")]
        [TestCase("C:\\Users\\Vicky\\Documents\\Test\\\\source\\T1", "C:\\Users\\Vicky\\Documents\\Test\\destination")]
        [TestCase("C:\\Users\\Vicky\\Documents\\Test\\source\\T1\\", "C:\\Users\\Vicky\\Documents\\Test\\source\\T1")]
        [TestCase("C:\\Users\\Vicky\\Documents\\Test\\source\\T1\\\\\\", "C:\\Users\\Vicky\\Documents\\Test\\source\\T1")]
        [TestCase("C:\\Users\\Vicky\\Documents\\Test\\source\\InvalidFolder", "C:\\Users\\Vicky\\Documents\\Test\\destination")]
        public void VerifyFileCopy_Inputs_InvalidPaths_Returns_ZeroCopiedCount(string sourceFolderPath, string destinationFolderPath)
        {
            DirectoryOperations directoryOperations = GetDirOpsInstance();

            directoryOperations.ProcessCopy(sourceFolderPath, destinationFolderPath);

            Assert.IsTrue(directoryOperations.ProcessedFileCount == 0);
        }
    }

    [TestFixture]
    public class ClsDirTestWithSetup
    {
        public DirectoryOperations GetDirOpsInstance()
        {
            return new DirectoryOperations();
        }

        [SetUp]
        public void Initialise_Destination_Folder()
        {
            this.ClearDestinationFolder();
        }

        [TestCase("C:\\Users\\Vicky\\Documents\\Test\\source\\T1", "C:\\Users\\Vicky\\Documents\\Test\\destination")]
        [TestCase("C:\\Users\\Vicky\\Documents\\Test\\source\\T1\\", "C:\\Users\\Vicky\\Documents\\Test\\destination")]
        [TestCase("C:\\Users\\Vicky\\Documents\\Test\\source\\", "C:\\Users\\Vicky\\Documents\\Test\\destination")]
        public void VerifyFilesCopied_SourceFolderPath_DestFolderPath_Returns_FolderNFilesCopiedStatus(string sourceFolderPath, string destFolderPath)
        {
            DirectoryOperations directoryOperations = GetDirOpsInstance();

            int sourceFileCount = directoryOperations.GetFileCount(sourceFolderPath);
            directoryOperations.ProcessCopy(sourceFolderPath, destFolderPath);
            int copiedFileCount = directoryOperations.ProcessedFileCount;

            Assert.IsTrue(sourceFileCount == copiedFileCount);
        }

        [TearDown]
        public void Clear_Destination_Folder()
        {
            this.ClearDestinationFolder();
        }

        public void ClearDestinationFolder()
        {
            string destinationPath = "C:\\Users\\Vicky\\Documents\\Test\\destination";
            new DirClearOps().ClearDirectory(destinationPath);
        }
    }
}
