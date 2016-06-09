using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(TrueOrFalse.iOS.Config))]

namespace TrueOrFalse.iOS
{
    public class Config : IConfig
    {
        private string _dbdirectory;
        public string DBDirectory
        {
            get
            {
                if (string.IsNullOrEmpty(_dbdirectory))
                {
                    var directory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    _dbdirectory = System.IO.Path.Combine(directory, "..", "Library");
                }
                return _dbdirectory;
            }
        }
    }
}
