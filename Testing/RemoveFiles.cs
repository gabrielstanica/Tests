using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class RemoveFiles
    {
        public static void DeleteFiles(string testPath, params string[] deletePattern)
        {
            DirectoryInfo directory = new DirectoryInfo(testPath);
            DirectoryInfo[] subdirectories = directory.GetDirectories();

            IEnumerable list = directory.GetFiles().AsEnumerable();

            IEnumerable delete = deletePattern.AsEnumerable();

            foreach (var pattern in deletePattern)
            {
                foreach (FileInfo file in directory.GetFiles())
                    if (file.Name.Contains(pattern))
                        file.Delete();

                if (Directory.EnumerateDirectories(testPath).Any())
                {
                    foreach (FileInfo file in directory.GetFiles())
                        if (file.Name.Contains(pattern))
                            file.Delete();

                    foreach (DirectoryInfo dir in subdirectories)
                        foreach (FileInfo file in dir.GetFiles())
                            if (file.Name.Contains(pattern))
                                file.Delete();
                }
            }
        }
    }
}
