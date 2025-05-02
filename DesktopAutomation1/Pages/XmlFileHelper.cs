using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesktopAutomation1.Pages
{
    public static class XmlFileHelper
    {
        public static string GetLatestXmlFileId(string basePath)
        {
            // Get all XML files under all date folders recursively
            var xmlFiles = Directory.GetFiles(basePath, "*.xml", SearchOption.AllDirectories);

            if (xmlFiles.Length == 0)
                throw new FileNotFoundException("No XML files found.");

            // Get the latest file based on creation time
            var latestFile = xmlFiles
                .Select(f => new FileInfo(f))
                .OrderByDescending(f => f.CreationTime)
                .First();

            // Extract ID from filename using Regex
            var match = Regex.Match(latestFile.Name, @"ID-(\d+)\.xml$");
            if (!match.Success)
                throw new InvalidOperationException("ID not found in filename.");

            string id = match.Groups[1].Value;
            return id;
        }
    }
}
