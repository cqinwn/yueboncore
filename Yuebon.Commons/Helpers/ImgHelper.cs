using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using Yuebon.Commons.Log;

namespace Yuebon.Commons.Helpers
{
    /// <summary>
    /// 图片处理
    /// </summary>
    public class ImgHelper
    {        
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源文件</param>
        /// <param name="thumbnailPath">缩略图</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="mode"></param>
        public static void MakeThumbnail(string originalImagePath,
            string thumbnailPath,
            int width = 120, int height = 90, string mode = "H")
        {
            Image image = Image.FromFile(originalImagePath);
            if (image.Width <= width && image.Height <= height)
            {
                File.Copy(originalImagePath, thumbnailPath, true);
                image.Dispose();
            }
            else
            {
                int width2 = image.Width;
                int height2 = image.Height;
                float num = (float)height / (float)height2;
                if ((float)width / (float)width2 < num)
                {
                    num = (float)width / (float)width2;
                }
                width = (int)((float)width2 * num);
                height = (int)((float)height2 * num);
                Image image2 = new Bitmap(width, height);
                Graphics graphics = Graphics.FromImage(image2);
                graphics.Clear(Color.White);
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, new Rectangle(0, 0, width, height), new Rectangle(0, 0, width2, height2), GraphicsUnit.Pixel);
                EncoderParameters encoderParameters = new EncoderParameters();
                EncoderParameter encoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                encoderParameters.Param[0] = encoderParameter;
                ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo encoder = null;
                int num2 = 0;
                while (num2 < imageEncoders.Length)
                {
                    if (!imageEncoders[num2].FormatDescription.Equals("JPEG"))
                    {
                        num2++;
                        continue;
                    }
                    encoder = imageEncoders[num2];
                    break;
                }
                image2.Save(thumbnailPath, encoder, encoderParameters);
                encoderParameters.Dispose();
                encoderParameter.Dispose();
                image.Dispose();
                image2.Dispose();
                graphics.Dispose();
            }
        }
        /// <summary>
        /// 获取网络图片
        /// </summary>
        /// <param name="imgUrl"></param>
        /// <returns></returns>
        public static Bitmap GetNetImg(string imgUrl)
        {
            try
            {
                Random random = new Random();
                imgUrl = ((!imgUrl.Contains("?")) ? (imgUrl + "?aid=" + random.NextDouble()) : (imgUrl + "&aid=" + random.NextDouble()));
                WebRequest webRequest = WebRequest.Create(imgUrl);
                WebResponse response = webRequest.GetResponse();
                Stream responseStream = response.GetResponseStream();
                Image image = Image.FromStream(responseStream);
                responseStream.Close();
                responseStream.Dispose();
                webRequest = null;
                response = null;
                return (Bitmap)image;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("获取网络图片错误", ex); 
                return new Bitmap(100, 100);
            }
        }
        /// <summary>
        /// 将图片裁剪成圆形
        /// </summary>
        /// <param name="img"></param>
        /// <param name="rec"></param>
        /// <param name="size"></param>
        /// <param name="imgSavePath"></param>
        /// <returns></returns>
        public static Image CutEllipse(Image img, Rectangle rec, Size size, string imgSavePath)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (TextureBrush br = new TextureBrush(img, System.Drawing.Drawing2D.WrapMode.Clamp, rec))
                {
                    br.ScaleTransform(bitmap.Width / (float)rec.Width, bitmap.Height / (float)rec.Height);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.FillEllipse(br, new Rectangle(Point.Empty, size));
                }
            }
            bitmap.Save(imgSavePath, System.Drawing.Imaging.ImageFormat.Png);
            return bitmap;
        }

        /// <summary>
        /// 将图片裁剪成圆形
        /// </summary>
        /// <param name="img"></param>
        /// <param name="rec"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Bitmap CutEllipse(Image img, Rectangle rec, Size size)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (TextureBrush br = new TextureBrush(img, System.Drawing.Drawing2D.WrapMode.Clamp, rec))
                {
                    br.ScaleTransform(bitmap.Width / (float)rec.Width, bitmap.Height / (float)rec.Height);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.FillEllipse(br, new Rectangle(Point.Empty, size));
                }
            }
            return bitmap;
        }
    }
}
