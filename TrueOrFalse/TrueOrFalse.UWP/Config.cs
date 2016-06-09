using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(TrueOrFalse.UWP.Config))]
namespace TrueOrFalse.UWP
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
                    _dbdirectory = Windows.Storage.ApplicationData.Current.LocalFolder.Path.ToString();
                        
                        //GetFolderPath(Environment.SpecialFolder.Personal);
                }
                return _dbdirectory;
            }
        }
    }
}