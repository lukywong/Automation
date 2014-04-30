using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weway.Automation.Publish.Utils
{
    public static class DirectoryHelper
    {
        /// <summary>
        /// Copies an existing directory(including sub-directories) to a new directory.
        /// Overwritting a directory of the same name if allowed.
        /// </summary>
        /// <param name="srcPath">The directory to copy</param>
        /// <param name="desPath">The destination path to copy to</param>
        /// <param name="overwrite">true if the destination directory can be overwritten; otherwise false; true is default</param>
        /// <Author>Bo Wang</Author>
        /// <Date>11:13 2014/3/25</Date>
        public static void Copy(string srcPath, string desPath, bool overwrite = true)
        {
            if (string.IsNullOrEmpty(srcPath) ||
                string.IsNullOrEmpty(desPath))
            {
                throw new ArgumentNullException();
            }
            try
            {
                if (!Directory.Exists(srcPath))
                {
                    throw new DirectoryNotFoundException();
                }

                if (!Directory.Exists(desPath))
                {
                    Directory.CreateDirectory(desPath);
                }

                foreach (var filePath in Directory.GetFiles(srcPath))
                {
                    File.Copy(
                        filePath,
                        Path.Combine(desPath, Path.GetFileName(filePath) ?? ""),
                        overwrite);
                }

                foreach (string dirPath in Directory.GetDirectories(srcPath))
                {
                    Copy(
                        dirPath,
                        Path.Combine(desPath, Path.GetFileName(dirPath) ?? ""),
                        overwrite);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
