using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FaceApiFresh.Util
{
    public static class ImageStream
    {
        // Returns the contents of the specified file as a byte array.
        public static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (FileStream fileStream =
                new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }
    }
}