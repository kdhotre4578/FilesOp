using System.Configuration;
using FilesOpBLayer;

namespace FilesOp
{
    public class ConfigMgr
    {
        private Validator validator;

        private const string DEFAULT_FOLDER_PATH = "C:";

        public ConfigMgr(Validator _validator)
        {
            validator = _validator;
        }

        public string InitialisePath(string pathName)
        {
            string path = ConfigurationManager.AppSettings[pathName];

            if (validator == null)
            {
                return string.IsNullOrWhiteSpace(path) ? DEFAULT_FOLDER_PATH : path.Trim();
            }

            if (!string.IsNullOrWhiteSpace(path) && validator.IsValidPath(path))
            {
                return validator.VerifyFolderSuffix(path);
            }

            return DEFAULT_FOLDER_PATH;
        }
    }
}
