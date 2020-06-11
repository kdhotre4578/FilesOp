using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesOp.Test
{
    public class DirClearOps
    {
        public void ClearDirectory(string path)
        {
            string[] fileNames = Directory.GetFiles(path);

            foreach (string file in fileNames)
            {
                File.Delete(file);
            }

            string[] directories = Directory.GetDirectories(path);

            foreach (string directory in directories)
            {
                ClearDirectory(directory);
                Directory.Delete(directory);
            }
        }
    }
}
