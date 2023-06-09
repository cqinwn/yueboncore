using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Commons.VerificationCode
{
    /// <summary>
    /// 计算式验证码
    /// </summary>
    class SimpleCalculateUnlock
    {
        public static KeyValuePair<CaptchaModel, CaptchaStateModel> Create()
        {
            var exp = GenExpression();
            var img = GenCaptchaImage(exp);

            var img1 = "data:image/png;base64," + Convert.ToBase64String(img);
            var imgId = Guid.NewGuid().ToString();

            return new KeyValuePair<CaptchaModel, CaptchaStateModel>(new CaptchaModel
            {
                Id = imgId,
                Image_Base64 = img1
            }, new CaptchaStateModel
            {
                Id = imgId,
                DataCode = exp.Key.ToString(),
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
        private static KeyValuePair<int, List<string>> GenExpression()
        {
            var num1 = CaptchaHelper.Random.Next(0, 9);
            var num2 = CaptchaHelper.Random.Next(0, 9);
            var num3 = CaptchaHelper.Random.Next(0, 9);
            var dataCode = 0;

            var charList = new List<string>();
            switch (CaptchaHelper.Random.Next(0, 11))
            {
                case 0:
                    charList.Add(num1.ToString());
                    charList.Add("+");
                    charList.Add(num2.ToString());
                    charList.Add("+");
                    charList.Add(num3.ToString());
                    charList.Add("=");
                    charList.Add("?");
                    dataCode = num1 + num2 + num3;
                    break;
                case 1:
                    charList.Add(num1.ToString());
                    charList.Add("×");
                    charList.Add(num2.ToString());
                    charList.Add("+");
                    charList.Add(num3.ToString());
                    charList.Add("=");
                    charList.Add("?");
                    dataCode = num1 * num2 + num3;
                    break;
                case 2:
                    charList.Add(num1.ToString());
                    charList.Add("+");
                    charList.Add(num2.ToString());
                    charList.Add("×");
                    charList.Add(num3.ToString());
                    charList.Add("=");
                    charList.Add("?");
                    dataCode = num1 + num2 * num3;
                    break;
                case 3:
                    charList.Add(num1.ToString());
                    charList.Add("×");
                    charList.Add(num2.ToString());
                    charList.Add("×");
                    charList.Add(num3.ToString());
                    charList.Add("=");
                    charList.Add("?");
                    dataCode = num1 * num2 * num3;
                    break;
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    if (num1 > num2)
                    {
                        if (CaptchaHelper.Random.Next(0, 2) == 1)
                        {
                            charList.Add(num1.ToString());
                            charList.Add("-");
                            charList.Add(num2.ToString());
                            charList.Add("×");
                            charList.Add(num3.ToString());
                            charList.Add("=");
                            charList.Add("?");
                            dataCode = num1 - num2 * num3;
                        }
                        else
                        {
                            charList.Add(num1.ToString());
                            charList.Add("-");
                            charList.Add(num2.ToString());
                            charList.Add("+");
                            charList.Add(num3.ToString());
                            charList.Add("=");
                            charList.Add("?");
                            dataCode = num1 - num2 + num3;
                        }
                    }
                    else if (num2 > num3)
                    {
                        if (CaptchaHelper.Random.Next(0, 2) == 1 && num1 > 0)
                        {
                            charList.Add(num1.ToString());
                            charList.Add("×");
                            charList.Add(num2.ToString());
                            charList.Add("-");
                            charList.Add(num3.ToString());
                            charList.Add("=");
                            charList.Add("?");
                            dataCode = num1 * num2 - num3;
                        }
                        else
                        {
                            charList.Add(num1.ToString());
                            charList.Add("+");
                            charList.Add(num2.ToString());
                            charList.Add("-");
                            charList.Add(num3.ToString());
                            charList.Add("=");
                            charList.Add("?");
                            dataCode = num1 + num2 - num3;
                        }
                    }
                    else if ((num1 + num2) > num3)
                    {
                        charList.Add(num1.ToString());
                        charList.Add("+");
                        charList.Add(num2.ToString());
                        charList.Add("-");
                        charList.Add(num3.ToString());
                        charList.Add("=");
                        charList.Add("?");
                        dataCode = num1 + num2 - num3;
                    }
                    else if ((num1 + num3) > num2)
                    {
                        charList.Add(num1.ToString());
                        charList.Add("-");
                        charList.Add(num2.ToString());
                        charList.Add("+");
                        charList.Add(num3.ToString());
                        charList.Add("=");
                        charList.Add("?");
                        dataCode = num1 - num2 + num3;
                    }
                    else
                    {
                        charList.Add(num1.ToString());
                        charList.Add("+");
                        charList.Add(num2.ToString());
                        charList.Add("+");
                        charList.Add(num3.ToString());
                        charList.Add("=");
                        charList.Add("?");
                        dataCode = num1 + num2 + num3;
                    }
                    break;
            }
            return new KeyValuePair<int, List<string>>(dataCode, charList);
        }
        private static byte[] GenCaptchaImage(KeyValuePair<int, List<string>> exp)
        {
            var length = exp.Value.Count;    //字符长度
            var width = length * 35;        //图像的宽度
            const int height = 60;          //图像的高度

            var bitMap = new SKBitmap(width, height); //创建画布
            var canvas = new SKCanvas(bitMap);//创建画笔
            canvas.Clear(SKColors.Transparent);//透明背景

            //画字符
            var drawWidth = 5.0f;
            for (var i = 0; i < length; i++)
            {
                var charCode = exp.Value[i];
                var font = Fonts[CaptchaHelper.Random.Next(Fonts.Length)];       //随机字体
                var color = Colors[CaptchaHelper.Random.Next(Colors.Length)];    //随机颜色

                var isGradient = CaptchaHelper.Random.Next(0, 2);
                if (isGradient == 1) //渐变验证码
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
                        paint.TextSize = 44;
                        paint.Shader = SKShader.CreateLinearGradient(new SKPoint(5 + i * 5, 0), new SKPoint(5 + i * 25, height), new SKColor[] { color, color2 }, SKShaderTileMode.Clamp);

                        var drawX = drawWidth;
                        var charWidth = paint.MeasureText(charCode);
                        drawWidth += (charWidth > 24) ? charWidth : 24;
                        drawWidth += 5;

                        Console.WriteLine($"字体：{font}---------字符宽度：{charWidth}---------画笔坐标：{drawX}");
                        canvas.DrawText(charCode, new SKPoint(drawX, 44), paint);
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
                        paint.TextSize = 44;

                        var drawX = drawWidth;
                        var charWidth = paint.MeasureText(charCode);
                        drawWidth += (charWidth > 24) ? charWidth : 24;
                        drawWidth += 5;

                        Console.WriteLine($"字体：{font}---------字符宽度：{charWidth}---------画笔坐标：{drawX}");
                        canvas.DrawText(charCode, new SKPoint(drawX, 44), paint);
                    }
                }
            }

            //输出结果
            var image = SKImage.FromBitmap(bitMap);
            return image.Encode(SKEncodedImageFormat.Png, 100).ToArray();
        }
    }
}
