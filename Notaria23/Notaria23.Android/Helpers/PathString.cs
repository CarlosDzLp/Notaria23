using System;
using Notaria23.DataBase;
using Notaria23.Droid.Helpers;
using Xamarin.Forms;

[assembly:Dependency(typeof(PathString))]
namespace Notaria23.Droid.Helpers
{
    public class PathString : IPathBase
    {

        public string PathFile()
        {
            try
            {
                var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                return System.IO.Path.Combine(path, "notaria23.db3");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
