using Xamarin.Forms;
using ASSISTIDBaseTemplate.Droid.Implementation;
using ASSISTIDBaseTemplate.Interfaces;
using System.IO;

[assembly: Dependency(typeof(ImplementationFileHelper))]
namespace ASSISTIDBaseTemplate.Droid.Implementation
{
    public class ImplementationFileHelper : InterfaceFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}