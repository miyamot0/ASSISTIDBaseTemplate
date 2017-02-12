using ASSISTIDBaseTemplate.Interfaces;
using ASSISTIDBaseTemplate.iOS.Implementation;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImplementationFileHelper))]
namespace ASSISTIDBaseTemplate.iOS.Implementation
{
    public class ImplementationFileHelper : InterfaceFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}