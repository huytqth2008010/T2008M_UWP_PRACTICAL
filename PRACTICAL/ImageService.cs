using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PRACTICAL
{
    class ImageService
    {
        public static async Task<IEnumerable<string>> GetAssetFiles(string rootPath)
        {
            string folderPath = System.IO.Path.Combine(
                Windows.ApplicationModel.Package.Current.InstalledLocation.Path,
                rootPath.Replace('/', '\\').TrimStart('\\')
            );
            var folder = await StorageFolder.GetFolderFromPathAsync(folderPath);
            var files = await folder.GetFilesAsync();
            var relativePaths = from file in files select (rootPath + "/" + file.Name);
            return relativePaths;
        }
    }
}
