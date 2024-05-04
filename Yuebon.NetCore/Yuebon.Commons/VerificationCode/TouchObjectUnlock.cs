using SkiaSharp;

namespace Yuebon.Commons.VerificationCode
{
    internal class TouchObjectUnlock
    {
        /// <summary>
        /// 创建验证码
        /// </summary>
        /// <param name="imgBTList"></param>
        /// <param name="imgNameList"></param>
        /// <returns></returns>
        public static KeyValuePair<CaptchaImageModel, CaptchaStateModel> Create(List<byte[]> imgBTList, List<string> imgNameList)
        {
            /*
             * 随机从图片名称里选出实物名称，随机排序后输出
             */
            //1.依据原始图片生产新图片
            var height = 80;
            var width = 80;
            List<KeyValuePair<SKBitmap, SKCanvas>> imgList = new List<KeyValuePair<SKBitmap, SKCanvas>>();
            for (int i = 0; i < imgBTList.Count; i++)
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
                    btCanvas.DrawBitmap(SKBitmap.Decode(imgBTList[i]), new SKRect(0, 0, width, height), paint);
                }

                imgList.Add(new KeyValuePair<SKBitmap, SKCanvas>(btImage, btCanvas));
            }

            //2.对新图片随机排序
            var orderList = new List<string>();
            var orderNameList = new List<string>();
            while (imgList.Count > 0)
            {
                var num = CaptchaHelper.Random.Next(0, imgList.Count);

                var resultItem = imgList[num].Key.Encode(SKEncodedImageFormat.Jpeg, 100).ToArray();
                orderList.Add("data:image/jpg;base64," + Convert.ToBase64String(resultItem));
                orderNameList.Add(imgNameList[num]);
                imgList.RemoveAt(num);
                imgNameList.RemoveAt(num);
            }

            //4.选出最多数量的实物名称
            var imgName = orderNameList[0];
            var imgCount = 1;
            for (int i = 0; i < orderNameList.Count; i++)
            {
                var tmpList = orderNameList.FindAll(o => o == orderNameList[i]);
                if (tmpList.Count > imgCount)
                {
                    imgName = orderNameList[i];
                    imgCount = tmpList.Count;
                }
            }

            //5.计算结果
            var codeId = Guid.NewGuid().ToString();
            var codeData = "";
            for (int i = 0; i < orderNameList.Count; i++)
            {
                if (orderNameList[i] == imgName)
                {
                    codeData += $"{i.ToString()},";
                }
            }
            if (codeData.Length > 0) codeData = codeData.Substring(0, codeData.Length - 1);

            //6.输出结果
            return new KeyValuePair<CaptchaImageModel, CaptchaStateModel>(new CaptchaImageModel
            {
                Id = codeId,
                Image_Name = imgName,
                Image_List = orderList
            }, new CaptchaStateModel
            {
                Id = codeId,
                DataCode = codeData
            });
        }
        /// <summary>
        /// 验证码验证
        /// </summary>
        /// <param name="sItem"></param>
        /// <param name="vItem"></param>
        /// <returns></returns>
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
}
