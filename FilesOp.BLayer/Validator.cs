using System.IO;

namespace FilesOpBLayer
{
    public class Validator
    {
        #region Public Methods
        /// <summary>
        /// Verifies and removes the '\' if present at the end of path mentioned
        /// </summary>
        /// <param name="path">folder path</param>
        /// <returns>verified path</returns>
        public string VerifyFolderSuffix(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return path;
            }

            while (path.Substring(path.Length - 1) == "\\")
            {
                path = path.Substring(0, path.Length - 1);
            }

            return path;
        }

        /// <summary>
        /// Verifies wether the path is valid
        /// </summary>
        /// <param name="path">folder path</param>
        /// <returns>validity of path</returns>
        public bool IsValidPath(string path)
        {
            return !string.IsNullOrWhiteSpace(path) && VerifyPathFormat(path) && Directory.Exists(path);
        }

        /// <summary>
        /// Verifies whether path is in correct format
        /// </summary>
        /// <param name="path">folder path</param>
        /// <returns>if correct then true else false</returns>
        public bool VerifyPathFormat(string path)
        {
            bool isValid = true;

            string[] folders = path.Split('\\');

            for (int i = 0; i < folders.Length - 1; i++)
            {
                if (folders[i] == string.Empty)
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        /// <summary>
        /// Verifies and returns if the folder paths given are same
        /// </summary>
        /// <param name="path1">folder path1</param>
        /// <param name="path2">folder path2</param>
        /// <returns>if same true else false</returns>
        public bool ArePathSame(string path1, string path2)
        {
            return path1.Equals(path2);
        }

        #endregion
    }
}
