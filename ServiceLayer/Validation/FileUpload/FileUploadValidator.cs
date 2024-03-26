using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Validation.FileUpload
{
    public static class FileUploadValidator
    {
        public static bool HasImageExtension(this string? source)
        {
            if (source == null)
            {
                return false;
            }

            return (source.EndsWith(".png")
                || source.EndsWith(".jpg")
                || source.EndsWith(".jpeg")
                || source.EndsWith(".gif")
                || source.EndsWith(".webp")
                || source.EndsWith(".tiff")
                || source.EndsWith(".jpeg 2000")
                || source.EndsWith(".raw")
                || source.EndsWith(".psd")
                || source.EndsWith(".bmp")
                || source.EndsWith(".heif")
                || source.EndsWith(".docx")
                || source.EndsWith(".pdf")
                || source.EndsWith(".indd"));
        }
    }
}
