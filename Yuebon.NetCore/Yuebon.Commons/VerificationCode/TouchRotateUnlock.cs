using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Commons.VerificationCode
{
    internal class TouchRotateUnlock
    {
        public static KeyValuePair<CaptchaImageModel, CaptchaStateModel> Create(List<byte[]> btList)
        {
            /*
             * 默认所有图片方向正确，随机改变图片方向，然后输出
             */
            //1.依据原始图片生产新图片
            var height = 80;
            var width = 80;
            var imgDict = new Dictionary<int, int>();
            List<KeyValuePair<SKBitmap, SKCanvas>> imgList = new List<KeyValuePair<SKBitmap, SKCanvas>>();
            for (int i = 0; i < btList.Count; i++)
            {
                var btImage = new SKBitmap(width, height);
                var btCanvas = new SKCanvas(btImage);//创建画笔
                using (var paint = new SKPaint())
                {
                    paint.IsAntialias = true;//消锯齿
                    paint.FilterQuality = SKFilterQuality.High;//高质量
                    paint.Style = SKPaintStyle.StrokeAndFill;
                    paint.StrokeWidth = 1;
                    paint.IsDither = true;//抖动
                    btCanvas.DrawBitmap(SKBitmap.Decode(btList[i]), new SKRect(0, 0, width, height), paint);
                }

                imgList.Add(new KeyValuePair<SKBitmap, SKCanvas>(btImage, btCanvas));
                imgDict.Add(i, btImage.GetHashCode());
            }

            //2.对新生成的图片进行随机挑选，选中后随机旋转方向至非正确方向
            var rotateList = new List<CaptchaRotateModel>();
            var numCount = CaptchaHelper.Random.Next(2, 4);
            for (int i = 0; i < numCount; i++)
            {
                var num = CaptchaHelper.Random.Next(0, imgList.Count);
                var bmp = imgList[num];
                var rIndex = imgDict.FirstOrDefault(o => o.Value == bmp.Key.GetHashCode()).Key;

                var direct = CaptchaHelper.Random.Next(1, 4);
                switch (direct)
                {
                    case 1:
                        bmp.Value.RotateDegrees(90);
                        rotateList.Add(new CaptchaRotateModel { Index = rIndex, Direaction = 1, Bitmap = bmp.Key });
                        break;
                    case 2:
                        bmp.Value.RotateDegrees(180);
                        rotateList.Add(new CaptchaRotateModel { Index = rIndex, Direaction = 2, Bitmap = bmp.Key });
                        break;
                    case 3:
                        bmp.Value.RotateDegrees(270);
                        rotateList.Add(new CaptchaRotateModel { Index = rIndex, Direaction = 3, Bitmap = bmp.Key });
                        break;
                }
                imgList.RemoveAt(num);
            }
            for (int i = 0; i < imgList.Count; i++)
            {
                var rIndex = imgDict.FirstOrDefault(o => o.Value == imgList[i].Key.GetHashCode()).Key;
                rotateList.Add(new CaptchaRotateModel { Index = rIndex, Direaction = 0, Bitmap = imgList[i].Key });
            }

            //3.整理数据
            var codeData = "";
            var resultList = new List<string>();
            var orderList = rotateList.OrderBy(o => o.Index).ToList();
            foreach (var item in orderList)
            {
                var resultItem = item.Bitmap.Encode(SKEncodedImageFormat.Jpeg, 100).ToArray();
                resultList.Add("data:image/jpg;base64," + Convert.ToBase64String(resultItem));
                codeData += $"{item.Index}:{item.Direaction},";
            }
            if (codeData.Length > 0) codeData = codeData.Substring(0, codeData.Length - 1);

            //4.输出结果
            var codeId = Guid.NewGuid().ToString();
            return new KeyValuePair<CaptchaImageModel, CaptchaStateModel>(new CaptchaImageModel
            {
                Id = codeId,
                Image_List = resultList
            }, new CaptchaStateModel
            {
                Id = codeId,
                DataCode = codeData
            });
        }
        public static MsgModel Verify(CaptchaStateModel sItem, CaptchaVerifyModel vItem)
        {
            var vcode = "";
            var vList = vItem.DataCode.Split(',').OrderBy(o => o);
            foreach (var item in vList)
            {
                vcode += item + ",";
            }
            var scode = "";
            var sList = sItem.DataCode.Split(',').OrderBy(o => o);
            foreach (var item in sList)
            {
                scode += item + ",";
            }

            if (vcode == scode)
            {
                return new MsgModel { MsgCode = "200", MsgData = "验证通过", MsgError = null };
            }
            else
            {
                return new MsgModel { MsgCode = "700", MsgData = null, MsgError = "验证失败" };
            }
        }
    }

    class CaptchaRotateModel
    {
        public int Index { get; set; }
        /// <summary>
        /// 方向：0上，1右，2下，3左
        /// </summary>
        public int Direaction { get; set; }
        public SKBitmap Bitmap { get; set; }
    }
}
