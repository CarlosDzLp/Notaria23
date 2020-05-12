using System;
using System.IO;
using System.Web;

namespace Notaria23Api.Helpers
{
    public static class Upload
    {
        private static bool WriteFile(MemoryStream stream, string folder, string name)
        {
            try
            {
                stream.Position = 0;
                var path = Path.Combine(folder, name);
                File.WriteAllBytes(path, stream.ToArray());
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static string ImagePath(byte[] fileArray)
        {
            try
            {
                var stream = new MemoryStream(fileArray);
                var guid = Guid.NewGuid().ToString();
                var file = $"{guid}.png";
                var folder = $"~/Images/";
                var folderFull = HttpContext.Current.Server.MapPath(folder);
                var response = WriteFile(stream, folderFull, file);
                if (response)
                {
                    return $"/Images/{file}";
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
