using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Workshop01.Services
{
    public class IsolatedStorageService
    {
        public void SaveImage(Stream stream, int id, string fileName)
        {
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();
            if (!isoStore.DirectoryExists("Pictures"))
            {
                isoStore.CreateDirectory("Pictures");
            }

            var path = "/Pictures/" + id + ".jpg" ;
            var Isostream = isoStore.CreateFile(path);
            CopyStream(stream, Isostream);
            Isostream.Flush();
            Isostream.Close();
            Isostream.Dispose();
        }

        public ImageSource GetImage(int id)
        {
            var path = "/Pictures/" + id + ".jpg";

            BitmapImage bi = new BitmapImage();

            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!myIsolatedStorage.FileExists(path))
                    return null; 

                using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(path, FileMode.Open, FileAccess.Read))
                {
                    fileStream.Seek(0, SeekOrigin.Begin);
                    bi.SetSource(fileStream);
                }
            }

            return bi;
        }

        private void CopyStream(Stream Input, IsolatedStorageFileStream Output)
        {
            Byte[] Buffer = new Byte[5120];
            Input.Seek(0, SeekOrigin.Begin);
            Int32 ReadCount = Input.Read(Buffer, 0, Buffer.Length);
            while (ReadCount > 0)
            {
                Output.Write(Buffer, 0, ReadCount);
                ReadCount = Input.Read(Buffer, 0, Buffer.Length);
            }
        }
    }
}
