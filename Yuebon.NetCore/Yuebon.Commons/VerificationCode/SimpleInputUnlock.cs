using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Yuebon.Commons.VerificationCode
{
    /// <summary>
    /// 简易式验证码
    /// </summary>
    class SimpleInputUnlock
    {
        public static KeyValuePair<CaptchaModel, CaptchaStateModel> Create(int codeLength = 4, bool isNumber = false, bool isGradient = false, bool isZao = true, bool isLine = true, bool isWavy = true)
        {
            var code = isNumber ? GenCaptchaNum(codeLength) : GenCaptchaWord(codeLength);
            var image = GenCaptchaImage(code, isGradient, isZao, isLine, isWavy);

            var img1 = "data:image/png;base64," + Convert.ToBase64String(image);
            var imgId = Guid.NewGuid().ToString();

            return new KeyValuePair<CaptchaModel, CaptchaStateModel>(new CaptchaModel
            {
                Id = imgId,
                Image_Base64 = img1
            }, new CaptchaStateModel
            {
                Id = imgId,
                DataCode = code,
                IsSuccess = false
            });
        }
        public static MsgModel Verify(CaptchaStateModel sItem, CaptchaVerifyModel vItem)
        {
            if (vItem.DataCode == sItem.DataCode)
            {
                return new MsgModel { MsgCode = "200", MsgData = "验证通过", MsgError = null };
            }
            else
            {
                return new MsgModel { MsgCode = "700", MsgData = null, MsgError = "验证失败" };
            }
        }


        /// <summary>
        /// 预定字符(数字)
        /// </summary>
        private static readonly char[] CharactersNum = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        /// <summary>
        /// 预定字符(数字+字母)
        /// </summary>
        private static readonly char[] CharactersNumAndWord = new[] { 'a', 'b', '0', 'c', 'd', 'e', 'f', '2', 'g', 'h', '3', 'i', 'j', '4', 'k', '5', 'm', 'n', '6', 'o', 'p', '7', 'q', 'r', '8', 's', 't', '9', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        /// <summary>
        /// 预设定颜色
        /// </summary>
        private static readonly SKColor[] Colors = new[]
        {
            SKColors.DeepSkyBlue,SKColors.DodgerBlue,SKColors.CornflowerBlue,SKColors.Aqua,SKColors.Aquamarine,SKColors.Cyan,SKColors.LightGreen,
            SKColors.SteelBlue,SKColors.DodgerBlue,SKColors.Black, SKColors.Red, SKColors.DarkBlue, SKColors.Green, SKColors.Orange, SKColors.Brown,
            SKColors.BlueViolet,SKColors.Turquoise,SKColors.CadetBlue,SKColors.Violet,SKColors.Tomato,SKColors.Tan,SKColors.MediumSeaGreen
        };
        /// <summary>
        /// 预设定字体
        /// </summary>
        private static readonly string[] Fonts = new[] { "Arial", "宋体", "微软雅黑" };
        /// <summary>
        /// 获取指定长度的验证码字符串
        /// </summary>
        /// <param name="length">验证码长度</param>
        /// <returns></returns>
        private static string GenCaptchaNum(int length = 4)
        {
            //用于存放随机产生的字符
            var selected = new char[length];
            //对指定长度的字符逐个赋值
            for (var i = 0; i < length; i++)
            {
                //随机获取字符
                selected[i] = CharactersNum[CaptchaHelper.Random.Next(0, CharactersNum.Length)];
            }
            //将Char[]转换为字符串
            return new string(selected);
        }
        /// <summary>
        /// 获取指定长度的验证码字符串
        /// </summary>
        /// <param name="length">验证码长度</param>
        /// <returns></returns>
        private static string GenCaptchaWord(int length = 4)
        {
            //用于存放随机产生的字符
            var selected = new char[length];
            //对指定长度的字符逐个赋值
            for (var i = 0; i < length; i++)
            {
                //随机获取字符
                selected[i] = CharactersNumAndWord[CaptchaHelper.Random.Next(0, CharactersNumAndWord.Length)];
            }
            //将Char[]转换为字符串
            return new string(selected);
        }
        /// <summary>
        /// 生成验证码图片
        /// </summary>
        /// <param name="code">验证码</param>
        /// <param name="isGradient">渐变颜色</param>
        /// <param name="isZao">添加噪点</param>
        /// <param name="isLine">添加噪线</param>
        /// <param name="isWavy">添加波浪线</param>
        /// <returns></returns>
        private static byte[] GenCaptchaImage(string code, bool isGradient = true, bool isZao = true, bool isLine = true, bool isWavy = true)
        {
            var length = code.Length;       //字符长度
            var width = length * 30;        //图像的宽度
            const int height = 30;          //图像的高度
            var zaos = length * 30;        //噪点数
            var lines = length * 3;         //噪线数
            var wavy = length - 1;          //波浪线

            var bitMap = new SKBitmap(width, height); //创建画布
            var canvas = new SKCanvas(bitMap);//创建画笔
            canvas.Clear(SKColors.Transparent);//透明背景

            if (isZao)
            {
                //画噪点
                for (var i = 0; i < zaos; i++)
                {
                    var x = CaptchaHelper.Random.Next(bitMap.Width);  //X轴坐标为画布宽度最大值内的随机点
                    var y = CaptchaHelper.Random.Next(bitMap.Height);//Y轴坐标为画布高度最大值内的随机点
                    var color = Colors[CaptchaHelper.Random.Next(Colors.Length)];  //预设定颜色的随机值
                    bitMap.SetPixel(x, y, color);                    //设置随机点的颜色
                }
            }
            if (isLine)
            {
                //画噪线
                for (var i = 0; i < lines; i++)
                {
                    var x1 = CaptchaHelper.Random.Next(width);
                    var y1 = CaptchaHelper.Random.Next(height);
                    var x2 = CaptchaHelper.Random.Next(width);
                    var y2 = CaptchaHelper.Random.Next(height);
                    var color = Colors[CaptchaHelper.Random.Next(Colors.Length)];  //预设定颜色的随机值
                    using (var paint = new SKPaint())
                    {
                        paint.IsAntialias = true;//消锯齿
                        paint.FilterQuality = SKFilterQuality.High;//高质量
                        paint.Style = SKPaintStyle.Stroke;
                        paint.StrokeWidth = 1;
                        paint.Color = color;

                        canvas.DrawLine(x1, y1, x2, y2, paint);      //画随机颜色的噪线
                    }
                }
            }
            if (isWavy)
            {
                //画波浪线
                for (var i = 0; i < wavy; i++)
                {
                    var x1 = new SKPoint(CaptchaHelper.Random.Next(width), CaptchaHelper.Random.Next(height));
                    var x2 = new SKPoint(CaptchaHelper.Random.Next(width), CaptchaHelper.Random.Next(height));
                    var x3 = new SKPoint(CaptchaHelper.Random.Next(width), CaptchaHelper.Random.Next(height));
                    var x4 = new SKPoint(CaptchaHelper.Random.Next(width), CaptchaHelper.Random.Next(height));
                    using (var path = new SKPath())
                    {
                        path.MoveTo(x1);
                        path.LineTo(x2);
                        path.LineTo(x3);
                        path.LineTo(x4);

                        var color = Colors[CaptchaHelper.Random.Next(Colors.Length)];  //预设定颜色的随机值
                        var paint = new SKPaint();
                        paint.IsAntialias = true;//消锯齿
                        paint.FilterQuality = SKFilterQuality.High;//高质量
                        paint.Style = SKPaintStyle.Stroke;
                        paint.StrokeWidth = 1;
                        paint.Color = color;

                        canvas.DrawPath(path, paint);
                    }
                }
            }

            //画字符
            var drawWidth = 2.0f;
            for (var i = 0; i < code.Length; i++)
            {
                var charCode = code.Substring(i, 1);

                var font = Fonts[CaptchaHelper.Random.Next(Fonts.Length)];       //随机字体
                var color = Colors[CaptchaHelper.Random.Next(Colors.Length)];    //随机颜色
                if (isGradient) //渐变验证码
                {
                    var color2 = Colors[CaptchaHelper.Random.Next(Colors.Length)];    //随机颜色
                    using (var paint = new SKPaint())
                    {
                        paint.Typeface = SKTypeface.FromFamilyName(font);
                        paint.TextEncoding = SKTextEncoding.Utf8;
                        paint.IsAntialias = true;//消锯齿
                        paint.FilterQuality = SKFilterQuality.High;//高质量
                        paint.Style = SKPaintStyle.Stroke;
                        paint.StrokeWidth = 1;
                        paint.Color = color;
                        paint.FakeBoldText = true;
                        paint.TextSize = 24;
                        paint.Shader = SKShader.CreateLinearGradient(new SKPoint(6.0f + i *5, 0), new SKPoint(6.0f + i * 15, 30), new SKColor[] { color, color2 }, SKShaderTileMode.Clamp);

                        var drawX = drawWidth;
                        var charWidth = paint.MeasureText(charCode);
                        drawWidth += (charWidth > 24) ? charWidth : 24;
                        drawWidth += 2;

                        SKRect textBounds = new SKRect();
                        paint.MeasureText(charCode, ref textBounds);
                        Console.WriteLine($"字体：{font}---------字符宽度：{charWidth}---------画笔坐标：{drawX}");
                        canvas.DrawText(charCode, new SKPoint(drawX, 20), paint);
                    }
                }
                else
                {
                    using (var paint = new SKPaint())
                    {
                        paint.Typeface = SKTypeface.FromFamilyName(font);
                        paint.TextEncoding = SKTextEncoding.Utf8;
                        paint.IsAntialias = true;//消锯齿
                        paint.FilterQuality = SKFilterQuality.High;//高质量
                        paint.Style = SKPaintStyle.Stroke;
                        paint.StrokeWidth = 1;
                        paint.Color = color;
                        paint.FakeBoldText = true;
                        paint.TextSize = 24;

                        var drawX = drawWidth;
                        var charWidth = paint.MeasureText(charCode);
                        drawWidth += (charWidth > 24) ? charWidth : 24;
                        drawWidth += 2;

                        SKRect textBounds = new SKRect();
                        paint.MeasureText(charCode, ref textBounds);
                        Console.WriteLine($"字体：{font}---------字符宽度：{charWidth}---------画笔坐标：{drawX}");
                        canvas.DrawText(charCode, new SKPoint(drawX, 20), paint);
                    }
                }
            }

            //输出结果
            var image = SKImage.FromBitmap(bitMap);
            return image.Encode(SKEncodedImageFormat.Png, 100).ToArray();
        }
    }
}
