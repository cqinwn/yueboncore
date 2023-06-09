using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Commons.VerificationCode
{
    public class CaptchaHelper
    {
        /// <summary>
        /// 简易输入式验证码
        /// </summary>
        /// <param name="codeLength">字符长度</param>
        /// <param name="isNumber">是否数字</param>
        /// <param name="isGradient">渐变色</param>
        /// <param name="isZao">噪点</param>
        /// <param name="isLine">噪线</param>
        /// <param name="isWavy">波浪线</param>
        /// <returns></returns>
        public static KeyValuePair<CaptchaModel, CaptchaStateModel> SimpleInput(int codeLength = 4, bool isNumber = false, bool isGradient = false, bool isZao = true, bool isLine = true, bool isWavy = true)
        {
            return SimpleInputUnlock.Create(codeLength, isNumber, isGradient, isZao, isLine, isWavy);
        }
        /// <summary>
        /// 简易计算式验证码
        /// </summary>
        /// <returns></returns>
        public static KeyValuePair<CaptchaModel, CaptchaStateModel> SimpleCalculate()
        {
            return SimpleCalculateUnlock.Create();
        }
        /// <summary>
        /// 滑块拼图式验证码
        /// </summary>
        /// <param name="img">图片</param>
        /// <returns></returns>
        public static KeyValuePair<CaptchaModel, CaptchaStateModel> SliderImage(byte[] bgPicture)
        {
            return SliderImageUnlock.Create(bgPicture);
        }
        /// <summary>
        /// 文字点选式验证码
        /// </summary>
        /// <param name="bgPicture">背景图片</param>
        /// <returns></returns>
        public static KeyValuePair<CaptchaModel, CaptchaStateModel> TouchLetter(byte[] bgPicture)
        {
            return TouchLetterUnlock.Create(bgPicture);
        }
        /// <summary>
        /// 图片旋转式验证码
        /// </summary>
        /// <param name="imgList">图片列表</param>
        /// <returns></returns>
        public static KeyValuePair<CaptchaImageModel, CaptchaStateModel> TouchRotate(List<byte[]> imgList)
        {
            return TouchRotateUnlock.Create(imgList);
        }
        /// <summary>
        /// 图片点选式验证码
        /// </summary>
        /// <param name="imgDataList"></param>
        /// <param name="imgNameList"></param>
        /// <returns></returns>
        public static KeyValuePair<CaptchaImageModel, CaptchaStateModel> TouchObject(List<byte[]> imgDataList, List<string> imgNameList)
        {
            return TouchObjectUnlock.Create(imgDataList, imgNameList);
        }

        /// <summary>
        /// 验证码校验
        /// </summary>
        /// <param name="sItem">原始数据</param>
        /// <param name="vItem">检验数据</param>
        /// <returns></returns>
        public static MsgModel Verify(CaptchaStateModel sItem, CaptchaVerifyModel vItem)
        {
            var result = new MsgModel() { MsgCode = "700" };
            switch (vItem.Type.ToLower())
            {
                case "simpleinput":
                    result = SimpleInputUnlock.Verify(sItem, vItem);
                    break;
                case "simplecalculate":
                    result = SimpleCalculateUnlock.Verify(sItem, vItem);
                    break;
                case "sliderimage":
                    result = SliderImageUnlock.Verify(sItem, vItem);
                    break;
                case "touchletter":
                    result = TouchLetterUnlock.Verify(sItem, vItem);
                    break;
                case "touchrotate":
                    result = TouchRotateUnlock.Verify(sItem, vItem);
                    break;
                case "touchobject":
                    result = TouchObjectUnlock.Verify(sItem, vItem);
                    break;
            }
            return result;
        }

        /// <summary>
        /// 验证码图片宽度
        /// </summary>
        internal const int Bitmap_Width = 320;
        /// <summary>
        /// 验证码图片高度
        /// </summary>
        internal const int Bitmap_Height = 170;
        /// <summary>
        /// 随机数：随机种子----Ticks是 long 类型，强制到 int 类型可能报错~unchecked避免报错
        /// </summary>
        internal static Random Random = new Random(~unchecked((int)DateTime.Now.Ticks));
    }
}
