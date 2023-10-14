using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace SanskarHospital.Helpers
{
    public class HelperFunctions
    {
        // folder for the upload
        public static string ItemUploadFolderPath = "";
        public static string FullFileLocation;
        public static string FullThumbFileLocation;
        public static int FileSize;

        public static string renameUploadFile(HttpPostedFileBase file, string ItmUpldFlPth, Int32 counter = 0)
        {
            ItemUploadFolderPath = ItmUpldFlPth;
            var fileName = Path.GetFileName(file.FileName);

            string append = "item_";
            string finalFileName = append + ((counter).ToString()) + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(file.FileName);//fileName;
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(ItemUploadFolderPath + finalFileName)))
            {
                //file exists 
                return renameUploadFile(file, ItmUpldFlPth, ++counter);
            }
            //file doesn't exist, upload item but validate first
            return uploadFile(file, finalFileName);
        }

        private static string uploadFile(HttpPostedFileBase file, string fileName)
        {
            var path =
          Path.Combine(HttpContext.Current.Server.MapPath(ItemUploadFolderPath), fileName);
            string extension = Path.GetExtension(file.FileName);

            //make sure the file is valid
            if (!validateExtension(extension))
            {
                return FullFileLocation;
            }

            try
            {
                file.SaveAs(path);
                FullFileLocation = ItemUploadFolderPath + fileName;
                return FullFileLocation;
            }
            catch (Exception)
            {
                FullFileLocation = "~/images/logo-inked.png";
                return FullFileLocation;
            }
        }

        private static bool validateExtension(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {
                case ".jpg":
                    return true;
                case ".png":
                    return true;
                case ".gif":
                    return true;
                case ".jpeg":
                    return true;
                case ".mp4":
                    return true;
                case ".wmv":
                    return true;
                case ".3gp":
                    return true;
                case ".avi":
                    return true;
                case ".webm":
                    return true;
                case ".ogg":
                    return true;
                case ".wav":
                    return true;
                default:
                    return false;
            }
        }


        ///#################################################### Thumb Image Uploading ##################################################################

        public static string ThumbrenameUploadFile(HttpPostedFileBase file, string ItmUpldFlPth, int size, Int32 counter = 0)
        {
            FileSize = size;
            ItemUploadFolderPath = ItmUpldFlPth;
            var fileName = Path.GetFileName(file.FileName);

            string append = "item_";
            string finalFileName = append + ((counter).ToString()) + "_" + fileName;
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(ItemUploadFolderPath + finalFileName)))
            {
                //file exists 
                return ThumbrenameUploadFile(file, ItmUpldFlPth, size, ++counter);
            }
            //file doesn't exist, upload item but validate first
            return ThumbuploadFile(file, finalFileName);
        }

        private static string ThumbuploadFile(HttpPostedFileBase file, string fileName)
        {
            var path =
          Path.Combine(HttpContext.Current.Server.MapPath(ItemUploadFolderPath), fileName);
            string extension = Path.GetExtension(file.FileName);

            //make sure the file is valid
            if (!ThumbvalidateExtension(extension))
            {
                return FullThumbFileLocation;
            }


            try
            {
                file.SaveAs(path);
                FullThumbFileLocation = ItemUploadFolderPath + fileName;

                Image imgOriginal = Image.FromFile(path);

                //pass in whatever value you want 
                Image imgActual = ScaleBySize(imgOriginal, FileSize);
                imgOriginal.Dispose();
                imgActual.Save(path);
                imgActual.Dispose();

                return FullThumbFileLocation;
            }
            catch (Exception)
            {
                return FullThumbFileLocation;
            }
        }

        private static bool ThumbvalidateExtension(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {
                case ".jpg":
                    return true;
                case ".png":
                    return true;
                case ".gif":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }

        public static Image ScaleBySize(Image imgPhoto, int size)
        {

            float sourceWidth = imgPhoto.Width;
            float sourceHeight = imgPhoto.Height;
            float destHeight = 0;
            float destWidth = 0;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            if (size == 1)//Small Thumb size //2 for medium size
            {
                destWidth = 300;
                destHeight = 300;
            }
            if (size == 2)//Small Thumb size //2 for medium size
            {
                destWidth = 278;
                destHeight = 278;
            }
            if (size == 6)//Small Thumb size //2 for medium size
            {
                destWidth = 180;
                destHeight = 180;
            }
            if (size == 3)//Small Thumb size //2 for medium size
            {
                destWidth = 216;
                destHeight = 112;
            }
            if (size == 4)//Small Thumb size //2 for medium size
            {
                destWidth = 75;
                destHeight = 75;
            }
            if (size == 5)//Small Thumb size //2 for medium size
            {
                destWidth = 374;
                destHeight = 327;
            }
            // Width is greater than height, set Width = logoSize and resize height accordingly

            Bitmap bmPhoto = new Bitmap((int)destWidth, (int)destHeight,
                                        PixelFormat.Format32bppPArgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, (int)destWidth, (int)destHeight),
                new Rectangle(sourceX, sourceY, (int)sourceWidth, (int)sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();

            return bmPhoto;
        }

        ///#################################################### Resume Uploading ##################################################################
        ///
        public static string renameUploadFileResume(HttpPostedFileBase file, string ItmUpldFlPth, Int32 counter = 0)
        {
            ItemUploadFolderPath = ItmUpldFlPth;
            var fileName = Path.GetFileName(file.FileName);

           // string append = "get-savvy-digital_";
           // string finalFileName = append + ((counter).ToString()) + "_" + fileName;
            string finalFileName =  fileName;
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(ItemUploadFolderPath + finalFileName)))
            {
                //file exists 
                return renameUploadFileResume(file, ItmUpldFlPth, ++counter);
            }
            //file doesn't exist, upload item but validate first
            return uploadFileResume(file, finalFileName);
        }

        private static string uploadFileResume(HttpPostedFileBase file, string fileName)
        {
            var path =
          Path.Combine(HttpContext.Current.Server.MapPath(ItemUploadFolderPath), fileName);
            string extension = Path.GetExtension(file.FileName);

            //make sure the file is valid
            if (!validateExtensionResume(extension))
            {
                return FullFileLocation;
            }

            try
            {
                file.SaveAs(path);
                FullFileLocation = ItemUploadFolderPath + fileName;
                return FullFileLocation;
            }
            catch (Exception)
            {
                FullFileLocation = "~/images/file-not-found.jpg";
                return FullFileLocation;
            }
        }

        private static bool validateExtensionResume(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {
                case ".doc":
                    return true;
                case ".docx":
                    return true;
                case ".pdf":
                    return true;
                case ".jpg":
                    return true;
                case ".png":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }


    }
}