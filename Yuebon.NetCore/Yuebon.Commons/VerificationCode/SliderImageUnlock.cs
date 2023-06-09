using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Commons.VerificationCode
{
    internal class SliderImageUnlock
    {
        public static KeyValuePair<CaptchaModel, CaptchaStateModel> Create(byte[] bgPicture)
        {
            var kv_xy = GenCaptchaCode();
            var kv_map = GenCaptchaImage(bgPicture, kv_xy);

            var img1 = "data:image/png;base64," + Convert.ToBase64String(kv_map.Key);
            var img2 = "data:image/png;base64," + Convert.ToBase64String(kv_map.Value);
            var imgId = Guid.NewGuid().ToString();

            return new KeyValuePair<CaptchaModel, CaptchaStateModel>(new CaptchaModel
            {
                Id = imgId,
                Image_Base64 = img1,
                Image2_Base64 = img2,
                Image2_Offset_X = 0,
                Image2_Offset_Y = kv_xy.Y
            }, new CaptchaStateModel
            {
                Id = imgId,
                DataCode = kv_xy.X.ToString(),
                IsSuccess = false
            });
        }
        public static MsgModel Verify(CaptchaStateModel sItem, CaptchaVerifyModel vItem)
        {
            var codeNumber = Convert.ToInt32(sItem.DataCode);
            var dataNumber = Convert.ToInt32(vItem.DataCode);
            //拼块误差值允许:3像素
            if (dataNumber >= codeNumber - 3 && dataNumber <= codeNumber + 3)
            {
                return new MsgModel { MsgCode = "200", MsgData = "验证通过", MsgError = null };
            }
            else
            {
                return new MsgModel { MsgCode = "700", MsgData = null, MsgError = "验证失败" };
            }
        }

        private static Point GenCaptchaCode()
        {
            //生成小图随机裁剪开始坐标
            var rd_x = CaptchaHelper.Random.Next(50, 230);
            var rd_y = CaptchaHelper.Random.Next(10, 80);
            return new Point(rd_x, rd_y);
        }
        private static KeyValuePair<byte[], byte[]> GenCaptchaImage(byte[] p_map, Point p_xy)
        {
            var jigsawType = CaptchaHelper.Random.Next(0, 10);

            //1.定义大图和小图
            var bigMap = new SKBitmap(CaptchaHelper.Bitmap_Width, CaptchaHelper.Bitmap_Height);
            var bigCanvas = new SKCanvas(bigMap);//创建画笔
            using (var paint = new SKPaint())
            {
                paint.IsAntialias = true;//消锯齿
                paint.FilterQuality = SKFilterQuality.High;//高质量
                paint.Style = SKPaintStyle.StrokeAndFill;
                paint.StrokeWidth = 1;
                paint.IsDither = true;
                bigCanvas.DrawBitmap(SKBitmap.Decode(p_map), new SKRect(0, 0, CaptchaHelper.Bitmap_Width, CaptchaHelper.Bitmap_Height), paint);
            }
            var smallMap = new SKBitmap(40, 40);
            var smallCanvas = new SKCanvas(smallMap);
            smallCanvas.Clear(SKColors.Transparent);

            //2.计算小图区域坐标
            var s_x = p_xy.X;
            var s_x2 = p_xy.X + smallMap.Width;
            var s_y = p_xy.Y;
            var s_y2 = p_xy.Y + smallMap.Height;

            /*
             * 0上外下外（废），1上外下内，2上外左外，3上外左内，4上外右外，5上外右内，
             * 6上内下外，7上内下内，8上内左外，9上内左内，10上内右外，11上内右内，
             * 12下外左外，13下外左内，14下外右外，15下外右内，
             * 16下内左外，17下内左内，18下内右外，19下内右内，
             * 20左外右外（废），21左外右内，22左内右外，23左内右内，
             */
            var jigsawDirect = CaptchaHelper.Random.Next(0, 24);
            while (jigsawDirect == 0 || jigsawDirect == 20)
            {
                jigsawDirect = CaptchaHelper.Random.Next(0, 24);
            }

            //3.执行裁剪
            for (int y = 0; y < CaptchaHelper.Bitmap_Height; y++)
            {
                //处于Y轴裁剪区
                if (y > s_y && y < s_y2)
                {
                    for (int x = 0; x < CaptchaHelper.Bitmap_Width; x++)
                    {
                        //处于X轴裁剪区
                        if (x > s_x && x < s_x2)
                        {
                            //拼图裁剪
                            if (jigsawType == 0)
                            {
                                JigsawCut_LTR.JigsawCut(bigMap, smallMap, s_x, s_y, x, y);
                            }
                            else
                            {
                                JigsawCut_Random.JigsawCut(bigMap, smallMap, s_x, s_y, x, y, jigsawDirect);
                            }
                        }
                    }
                }
            }

            //4.输出结果
            var bigBitmap = SKImage.FromBitmap(bigMap);
            var resultBig = bigBitmap.Encode(SKEncodedImageFormat.Png, 100).ToArray();
            var smallBitmap = SKImage.FromBitmap(smallMap);
            var resultSmall = smallBitmap.Encode(SKEncodedImageFormat.Png, 100).ToArray();
            return new KeyValuePair<byte[], byte[]>(resultBig, resultSmall);
        }
    }
    class JigsawCut_LTR
    {
        //小圆直径
        private static int round_diameter = 12;
        public static void JigsawCut(SKBitmap bigMap, SKBitmap smallMap, int s_x, int s_y, int curX, int curY)
        {
            var isTop = JigsawCut_Top(bigMap, smallMap, s_x, s_y, curX, curY);
            var isLeft = JigsawCut_Left(bigMap, smallMap, s_x, s_y, curX, curY);
            var isRight = JigsawCut_Right(bigMap, smallMap, s_x, s_y, curX, curY);
            if (!isTop && !isLeft && !isRight)
            {
                JigsawCut_Other(bigMap, smallMap, s_x, s_y, curX, curY);
            }
        }
        private static bool JigsawCut_Top(SKBitmap bigMap, SKBitmap smallMap, int s_x, int s_y, int curX, int curY)
        {
            var top_y = s_y;
            var top_y2 = s_y + round_diameter;
            if (curY >= top_y && curY <= top_y2)
            {
                //a.圆心坐标
                var top_center_x = s_x + (smallMap.Width - round_diameter) / 2;
                var top_center_y = top_y + round_diameter / 2;

                //b.裁剪开始和结束(圆的标准方程)
                var _tmpX = Math.Sqrt(Math.Pow(round_diameter / 2, 2) - Math.Pow(curY - top_center_y, 2)) + top_center_x;
                var cut_x = (top_center_x - Math.Abs(top_center_x - _tmpX));
                var cut_x2 = (top_center_x + Math.Abs(top_center_x - _tmpX));
                //c.执行裁剪
                if (curX >= cut_x && curX <= cut_x2)
                {
                    ExecuteCut(bigMap, smallMap, s_x, s_y, curX, curY);
                }
                return true;
            }
            return false;
        }
        private static bool JigsawCut_Left(SKBitmap bigMap, SKBitmap smallMap, int s_x, int s_y, int curX, int curY)
        {
            var left_y = s_y + smallMap.Height / 2;
            var left_y2 = left_y + round_diameter;
            if (curY >= left_y && curY <= left_y2)
            {
                //a.圆心坐标
                var left_center_x = s_x + round_diameter / 2;
                var left_center_y = left_y + round_diameter / 2;

                //b.裁剪开始和结束(圆的标准方程)
                var _tmpX = Math.Sqrt(Math.Pow(round_diameter / 2, 2) - Math.Pow(curY - left_center_y, 2)) + left_center_x;
                var cut_x = (left_center_x - Math.Abs(left_center_x - _tmpX));
                var cut_x2 = (left_center_x + Math.Abs(left_center_x - _tmpX));

                //c.执行裁剪
                var cut_x3 = s_x + smallMap.Width - round_diameter;
                if (curX <= cut_x3)
                {
                    if ((curX >= s_x && curX <= cut_x) || (curX >= cut_x2 && curX <= cut_x3))
                    {
                        ExecuteCut(bigMap, smallMap, s_x, s_y, curX, curY);
                    }
                }
                return true;
            }
            return false;
        }
        private static bool JigsawCut_Right(SKBitmap bigMap, SKBitmap smallMap, int s_x, int s_y, int curX, int curY)
        {
            var right_y = s_y + smallMap.Height / 2;
            var right_y2 = right_y + round_diameter;
            if (curY >= right_y && curY <= right_y2)
            {
                //a.圆心坐标
                var right_center_x = s_x + smallMap.Width - round_diameter / 2;
                var right_center_y = right_y + round_diameter / 2;

                //b.裁剪开始和结束(圆的标准方程)
                var _tmpX = Math.Sqrt(Math.Pow(round_diameter / 2, 2) - Math.Pow(curY - right_center_y, 2)) + right_center_x;
                var cut_x = (right_center_x - Math.Abs(right_center_x - _tmpX));
                var cut_x2 = (right_center_x + Math.Abs(right_center_x - _tmpX));

                //c.执行裁剪
                var cut_x3 = s_x + smallMap.Width - round_diameter;
                if (curX >= cut_x3)
                {
                    if (curX >= cut_x && curX <= cut_x2)
                    {
                        ExecuteCut(bigMap, smallMap, s_x, s_y, curX, curY);
                    }
                }
                return true;
            }
            return false;
        }
        private static void JigsawCut_Other(SKBitmap bigMap, SKBitmap smallMap, int s_x, int s_y, int curX, int curY)
        {
            var other_y = s_y + round_diameter;
            var other_y2 = s_y + smallMap.Height;

            var max_X = s_x + smallMap.Width - round_diameter;
            if (curX >= s_x && curX <= max_X)
            {
                ExecuteCut(bigMap, smallMap, s_x, s_y, curX, curY);
            }
        }
        private static void ExecuteCut(SKBitmap bigMap, SKBitmap smallMap, int s_x, int s_y, int curX, int curY)
        {
            //1.取大图坐标位置像素值
            var xy_px = bigMap.GetPixel(curX, curY);

            //2.计算小图x轴和y轴坐标
            var sx = curX - s_x;
            var sy = curY - s_y;

            //3.设置小图像素
            smallMap.SetPixel(sx, sy, xy_px);

            //4.设置大图像素(半透明)
            bigMap.SetPixel(curX, curY, new SKColor(xy_px.Red, xy_px.Green, xy_px.Blue, 15));
        }
    }
    class JigsawCut_Random
    {
        //小圆直径
        private static int round_diameter = 12;
        public static void JigsawCut(SKBitmap bigMap, SKBitmap smallMap, int s_x, int s_y, int curX, int curY, int direct = 0)
        {
            var isLeftOuter = false;
            var isRightOuter = false;
            var isTopOuter = true;
            var isBottomOuter = true;

            var realCut1 = false;
            var realCut2 = false;
            switch (direct)
            {
                #region 上...
                case 0://0上外下外
                    isTopOuter = true;
                    isBottomOuter = true;
                    isLeftOuter = false;
                    isRightOuter = false;
                    realCut1 = JigsawCut_Top_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Bottom_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 1://1上外下内
                    isTopOuter = true;
                    isBottomOuter = false;
                    isLeftOuter = false;
                    isRightOuter = false;
                    realCut1 = JigsawCut_Top_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Bottom_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 2://2上外左外
                    isTopOuter = true;
                    isBottomOuter = false;
                    isLeftOuter = true;
                    isRightOuter = false;
                    realCut1 = JigsawCut_Top_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Left_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    JigsawCut_Repair_Right(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 3://3上外左内
                    isTopOuter = true;
                    isBottomOuter = false;
                    isLeftOuter = false;
                    isRightOuter = false;
                    realCut1 = JigsawCut_Top_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Left_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    JigsawCut_Repair_Right(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 4://4上外右外
                    isTopOuter = true;
                    isBottomOuter = false;
                    isLeftOuter = false;
                    isRightOuter = true;
                    realCut1 = JigsawCut_Top_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Right_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    JigsawCut_Repair_Left(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 5://5上外右内
                    isTopOuter = true;
                    isBottomOuter = false;
                    isLeftOuter = false;
                    isRightOuter = false;
                    realCut1 = JigsawCut_Top_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Right_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    JigsawCut_Repair_Left(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 6://6上内下外
                    isTopOuter = false;
                    isBottomOuter = true;
                    isLeftOuter = false;
                    isRightOuter = false;
                    realCut1 = JigsawCut_Top_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Bottom_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 7://7上内下内
                    isTopOuter = false;
                    isBottomOuter = false;
                    isLeftOuter = false;
                    isRightOuter = false;
                    realCut1 = JigsawCut_Top_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Bottom_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 8://8上内左外
                    isTopOuter = false;
                    isBottomOuter = false;
                    isLeftOuter = true;
                    isRightOuter = false;
                    realCut1 = JigsawCut_Top_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Left_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    JigsawCut_Repair_Right(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 9://9上内左内
                    isTopOuter = false;
                    isBottomOuter = false;
                    isLeftOuter = false;
                    isRightOuter = false;
                    realCut1 = JigsawCut_Top_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Left_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    JigsawCut_Repair_Right(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 10://10上内右外
                    isTopOuter = false;
                    isBottomOuter = false;
                    isLeftOuter = false;
                    isRightOuter = true;
                    realCut1 = JigsawCut_Top_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Right_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    JigsawCut_Repair_Left(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 11://11上内右内
                    isTopOuter = false;
                    isBottomOuter = false;
                    isLeftOuter = false;
                    isRightOuter = false;
                    realCut1 = JigsawCut_Top_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Right_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    JigsawCut_Repair_Left(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                #endregion

                #region 下...
                case 12://12下外左外
                    isTopOuter = false;
                    isBottomOuter = true;
                    isLeftOuter = true;
                    isRightOuter = false;
                    realCut1 = JigsawCut_Bottom_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Left_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    JigsawCut_Repair_Right(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 13://13下外左内
                    isTopOuter = false;
                    isBottomOuter = true;
                    isLeftOuter = false;
                    isRightOuter = false;
                    realCut1 = JigsawCut_Bottom_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Left_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    JigsawCut_Repair_Right(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 14://14下外右外
                    isTopOuter = false;
                    isBottomOuter = true;
                    isLeftOuter = false;
                    isRightOuter = true;
                    realCut1 = JigsawCut_Bottom_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Right_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    JigsawCut_Repair_Left(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 15://15下外右内
                    isTopOuter = false;
                    isBottomOuter = true;
                    isLeftOuter = false;
                    isRightOuter = false;
                    realCut1 = JigsawCut_Bottom_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Right_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    JigsawCut_Repair_Left(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 16://16下内左外
                    isLeftOuter = true;
                    isRightOuter = false;
                    isTopOuter = false;
                    isBottomOuter = false;
                    realCut1 = JigsawCut_Bottom_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Left_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    JigsawCut_Repair_Right(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 17://17下内左内
                    isLeftOuter = false;
                    isRightOuter = false;
                    isTopOuter = false;
                    isBottomOuter = false;
                    realCut1 = JigsawCut_Bottom_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Left_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    JigsawCut_Repair_Right(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 18://18下内右外
                    isLeftOuter = false;
                    isRightOuter = true;
                    isTopOuter = false;
                    isBottomOuter = false;
                    realCut1 = JigsawCut_Bottom_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Right_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    JigsawCut_Repair_Left(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 19://19下内右内
                    isLeftOuter = false;
                    isRightOuter = false;
                    isTopOuter = false;
                    isBottomOuter = false;
                    realCut1 = JigsawCut_Bottom_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Right_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    JigsawCut_Repair_Left(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                #endregion

                #region 左右
                case 20://20左外右外
                    isLeftOuter = true;
                    isRightOuter = true;
                    isTopOuter = false;
                    isBottomOuter = false;
                    realCut1 = JigsawCut_Left_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Right_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 21://21左外右内
                    isLeftOuter = true;
                    isRightOuter = false;
                    isTopOuter = false;
                    isBottomOuter = false;
                    realCut1 = JigsawCut_Left_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Right_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 22://22左内右外
                    isLeftOuter = false;
                    isRightOuter = true;
                    isTopOuter = false;
                    isBottomOuter = false;
                    realCut1 = JigsawCut_Left_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Right_Outer(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                case 23://23左内右内
                    isLeftOuter = false;
                    isRightOuter = false;
                    isTopOuter = false;
                    isBottomOuter = false;
                    realCut1 = JigsawCut_Left_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    realCut2 = JigsawCut_Right_Inner(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
                    break;
                    #endregion
            }

            //裁剪非小圆区域
            if (!realCut1 && !realCut2)
            {
                JigsawCut_Other(bigMap, smallMap, s_x, s_y, curX, curY, isLeftOuter, isRightOuter, isTopOuter, isBottomOuter);
            }
        }
        private static bool JigsawCut_Top_Inner(SKBitmap bigMap, SKBitmap smallMap, int s_x, int s_y, int curX, int curY, bool isLeftOuter = false, bool isRightOuter = false, bool isTopOuter = false, bool isBottomOuter = false)
        {
            var top_y = s_y;
            var top_y2 = s_y + round_diameter / 2;
            if (curY >= top_y && curY <= top_y2)
            {
                //a.圆心坐标
                var top_center_x = s_x + smallMap.Width / 2;
                var top_center_y = top_y;

                top_center_x = Calc_Offset_X(top_center_x, smallMap, s_x, s_y, isLeftOuter, isRightOuter);

                //b.裁剪开始和结束(圆的标准方程)
                var _tmpX = Math.Sqrt(Math.Pow(round_diameter / 2, 2) - Math.Pow(curY - top_center_y, 2)) + top_center_x;
                var cut_x = Math.Ceiling(top_center_x - Math.Abs(top_center_x - _tmpX));
                var cut_x2 = Math.Ceiling(top_center_x + Math.Abs(top_center_x - _tmpX));

                //c.执行裁剪（取外不取内）
                var x_start = isLeftOuter ? (s_x + round_diameter / 2) : s_x;
                var x_end = isRightOuter ? (s_x + smallMap.Width - round_diameter / 2) : (s_x + smallMap.Width);
                if ((curX >= x_start && curX <= cut_x) || (curX >= cut_x2 && curX <= x_end))
                {
                    ExecuteCut(bigMap, smallMap, s_x, s_y, curX, curY);
                }
                return true;
            }
            return false;
        }
        private static bool JigsawCut_Top_Outer(SKBitmap bigMap, SKBitmap smallMap, int s_x, int s_y, int curX, int curY, bool isLeftOuter = false, bool isRightOuter = false, bool isTopOuter = false, bool isBottomOuter = false)
        {
            var top_y = s_y;
            var top_y2 = s_y + round_diameter / 2;
            if (curY >= top_y && curY <= top_y2)
            {
                //a.圆心坐标
                var top_center_x = s_x + smallMap.Width / 2;
                var top_center_y = top_y2;

                top_center_x = Calc_Offset_X(top_center_x, smallMap, s_x, s_y, isLeftOuter, isRightOuter);

                //b.裁剪开始和结束(圆的标准方程)
                var _tmpX = Math.Sqrt(Math.Pow(round_diameter / 2, 2) - Math.Pow(curY - top_center_y, 2)) + top_center_x;
                var cut_x = Math.Ceiling(top_center_x - Math.Abs(top_center_x - _tmpX));
                var cut_x2 = Math.Ceiling(top_center_x + Math.Abs(top_center_x - _tmpX));

                //c.执行裁剪（取内不取外）
                if (curX >= cut_x && curX <= cut_x2)
                {
                    ExecuteCut(bigMap, smallMap, s_x, s_y, curX, curY);
                }
                return true;
            }
            return false;
        }
        private static bool JigsawCut_Bottom_Inner(SKBitmap bigMap, SKBitmap smallMap, int s_x, int s_y, int curX, int curY, bool isLeftOuter = false, bool isRightOuter = false, bool isTopOuter = false, bool isBottomOuter = false)
        {
            var bottom_y = s_y + smallMap.Height - round_diameter / 2;
            var bottom_y2 = s_y + smallMap.Height;
            if (curY >= bottom_y && curY <= bottom_y2)
            {
                //a.圆心坐标
                var bottom_center_x = s_x + smallMap.Width / 2;
                var bottom_center_y = bottom_y2;

                bottom_center_x = Calc_Offset_X(bottom_center_x, smallMap, s_x, s_y, isLeftOuter, isRightOuter);

                //b.裁剪开始和结束(圆的标准方程)
                var _tmpX = Math.Sqrt(Math.Pow(round_diameter / 2, 2) - Math.Pow(curY - bottom_center_y, 2)) + bottom_center_x;
                var cut_x = Math.Ceiling(bottom_center_x - Math.Abs(bottom_center_x - _tmpX));
                var cut_x2 = Math.Ceiling(bottom_center_x + Math.Abs(bottom_center_x - _tmpX));

                //c.执行裁剪（取外不取内）
                var x_start = (isLeftOuter ? (s_x + round_diameter / 2) : s_x);
                var x_end = isRightOuter ? (s_x + smallMap.Width - round_diameter / 2) : (s_x + smallMap.Width);
                if ((curX >= x_start && curX <= cut_x) || (curX >= cut_x2 && curX <= x_end))
                {
                    ExecuteCut(bigMap, smallMap, s_x, s_y, curX, curY);
                }
                return true;
            }
            return false;
        }
        private static bool JigsawCut_Bottom_Outer(SKBitmap bigMap, SKBitmap smallMap, int s_x, int s_y, int curX, int curY, bool isLeftOuter = false, bool isRightOuter = false, bool isTopOuter = false, bool isBottomOuter = false)
        {
            var bottom_y = s_y + smallMap.Height - round_diameter / 2;
            var bottom_y2 = s_y + smallMap.Height;
            if (curY >= bottom_y && curY <= bottom_y2)
            {
                //a.圆心坐标
                var bottom_center_x = s_x + smallMap.Width / 2;
                var bottom_center_y = bottom_y;

                bottom_center_x = Calc_Offset_X(bottom_center_x, smallMap, s_x, s_y, isLeftOuter, isRightOuter);

                //b.裁剪开始和结束(圆的标准方程)
                var _tmpX = Math.Sqrt(Math.Pow(round_diameter / 2, 2) - Math.Pow(curY - bottom_center_y, 2)) + bottom_center_x;
                var cut_x = Math.Ceiling(bottom_center_x - Math.Abs(bottom_center_x - _tmpX));
                var cut_x2 = Math.Ceiling(bottom_center_x + Math.Abs(bottom_center_x - _tmpX));

                //c.执行裁剪（取内不取外）
                if (curX >= cut_x && curX <= cut_x2)
                {
                    ExecuteCut(bigMap, smallMap, s_x, s_y, curX, curY);
                }
                return true;
            }
            return false;
        }
        private static bool JigsawCut_Left_Inner(SKBitmap bigMap, SKBitmap smallMap, int s_x, int s_y, int curX, int curY, bool isLeftOuter = false, bool isRightOuter = false, bool isTopOuter = false, bool isBottomOuter = false)
        {
            var newY = Calc_Offset_Y(smallMap, s_x, s_y, isTopOuter, isBottomOuter);
            var left_y = newY.Key;
            var left_y2 = newY.Value;

            if (curY >= left_y && curY <= left_y2)
            {
                //a.圆心坐标
                var left_center_x = s_x;
                var left_center_y = left_y + round_diameter / 2;

                //b.裁剪开始和结束(圆的标准方程)
                var _tmpX = Math.Sqrt(Math.Pow(round_diameter / 2, 2) - Math.Pow(curY - left_center_y, 2)) + left_center_x;
                var cut_x = Math.Ceiling(left_center_x - Math.Abs(left_center_x - _tmpX));
                var cut_x2 = Math.Ceiling(left_center_x + Math.Abs(left_center_x - _tmpX));

                //c.执行裁剪（不取半圆）
                var s_x2 = s_x + smallMap.Width / 2;
                if (curX >= cut_x2 && curX <= s_x2)
                {
                    ExecuteCut(bigMap, smallMap, s_x, s_y, curX, curY);
                }
                return true;
            }
            return false;
        }
        private static bool JigsawCut_Left_Outer(SKBitmap bigMap, SKBitmap smallMap, int s_x, int s_y, int curX, int curY, bool isLeftOuter = false, bool isRightOuter = false, bool isTopOuter = false, bool isBottomOuter = false)
        {
            var newY = Calc_Offset_Y(smallMap, s_x, s_y, isTopOuter, isBottomOuter);
            var left_y = newY.Key;
            var left_y2 = newY.Value;

            if (curY >= left_y && curY <= left_y2)
            {
                //a.圆心坐标
                var left_center_x = s_x + round_diameter / 2;
                var left_center_y = left_y + round_diameter / 2;

                //b.裁剪开始和结束(圆的标准方程)
                var _tmpX = Math.Sqrt(Math.Pow(round_diameter / 2, 2) - Math.Pow(curY - left_center_y, 2)) + left_center_x;
                var cut_x = Math.Ceiling(left_center_x - Math.Abs(left_center_x - _tmpX));
                var cut_x2 = Math.Ceiling(left_center_x + Math.Abs(left_center_x - _tmpX));

                //c.执行裁剪（取半圆）
                var s_x2 = s_x + smallMap.Width / 2;
                if (curX >= cut_x && curX <= s_x2)
                {
                    ExecuteCut(bigMap, smallMap, s_x, s_y, curX, curY);
                }
                return true;
            }
            return false;
        }
        private static bool JigsawCut_Right_Inner(SKBitmap bigMap, SKBitmap smallMap, int s_x, int s_y, int curX, int curY, bool isLeftOuter = false, bool isRightOuter = false, bool isTopOuter = false, bool isBottomOuter = false)
        {
            var newY = Calc_Offset_Y(smallMap, s_x, s_y, isTopOuter, isBottomOuter);
            var right_y = newY.Key;
            var right_y2 = newY.Value;

            if (curY >= right_y && curY <= right_y2)
            {
                //a.圆心坐标
                var right_center_x = s_x + smallMap.Width;
                var right_center_y = right_y + round_diameter / 2;

                //b.裁剪开始和结束(圆的标准方程)
                var _tmpX = Math.Sqrt(Math.Pow(round_diameter / 2, 2) - Math.Pow(curY - right_center_y, 2)) + right_center_x;
                var cut_x = Math.Ceiling(right_center_x - Math.Abs(right_center_x - _tmpX));
                var cut_x2 = Math.Ceiling(right_center_x + Math.Abs(right_center_x - _tmpX));

                //c.执行裁剪（不取半圆）
                var s_x2 = s_x + smallMap.Width / 2 + 1;
                if (curX >= s_x2 && curX <= cut_x)
                {
                    ExecuteCut(bigMap, smallMap, s_x, s_y, curX, curY);
                }
                return true;
            }
            return false;
        }
        private static bool JigsawCut_Right_Outer(SKBitmap bigMap, SKBitmap smallMap, int s_x, int s_y, int curX, int curY, bool isLeftOuter = false, bool isRightOuter = false, bool isTopOuter = false, bool isBottomOuter = false)
        {
            var newY = Calc_Offset_Y(smallMap, s_x, s_y, isTopOuter, isBottomOuter);
            var right_y = newY.Key;
            var right_y2 = newY.Value;

            if (curY >= right_y && curY <= right_y2)
            {
                //a.圆心坐标
                var right_center_x = s_x + smallMap.Width - round_diameter / 2;
                var right_center_y = right_y + round_diameter / 2;

                //b.裁剪开始和结束(圆的标准方程)
                var _tmpX = Math.Sqrt(Math.Pow(round_diameter / 2, 2) - Math.Pow(curY - right_center_y, 2)) + right_center_x;
                var cut_x = Math.Ceiling(right_center_x - Math.Abs(right_center_x - _tmpX));
                var cut_x2 = Math.Ceiling(right_center_x + Math.Abs(right_center_x - _tmpX));

                //c.执行裁剪（不取半圆）
                var s_x2 = s_x + smallMap.Width / 2 + 1;
                if (curX >= s_x2 && curX <= cut_x2)
                {
                    ExecuteCut(bigMap, smallMap, s_x, s_y, curX, curY);
                }
                return true;
            }
            return false;
        }
        private static void JigsawCut_Other(SKBitmap bigMap, SKBitmap smallMap, int s_x, int s_y, int curX, int curY, bool isLeftOuter = false, bool isRightOuter = false, bool isTopOuter = false, bool isBottomOuter = false)
        {
            var y_start = isTopOuter ? (s_y + round_diameter / 2) : s_y;
            var y_end = isBottomOuter ? (s_y + smallMap.Height - round_diameter / 2) : (s_y + smallMap.Height);
            if (curY >= y_start && curY <= y_end)
            {
                var x_start = isLeftOuter ? (s_x + round_diameter / 2) : s_x;
                var x_end = isRightOuter ? (s_x + smallMap.Width - round_diameter / 2) : (s_x + smallMap.Width);
                if (curX >= x_start && curX <= x_end)
                {
                    ExecuteCut(bigMap, smallMap, s_x, s_y, curX, curY);
                }
            }
        }
        private static void ExecuteCut(SKBitmap bigMap, SKBitmap smallMap, int s_x, int s_y, int curX, int curY)
        {
            //1.取大图坐标位置像素值
            var b_px = bigMap.GetPixel(curX, curY);

            //2.计算小图x轴和y轴坐标
            var _s_x = curX - s_x;
            var _s_y = curY - s_y;

            //3.设置小图像素
            smallMap.SetPixel(_s_x, _s_y, b_px);

            //4.设置大图像素(半透明)
            bigMap.SetPixel(curX, curY, new SKColor(b_px.Red, b_px.Green, b_px.Blue, 15));
        }
        private static void JigsawCut_Repair_Left(SKBitmap bigMap, SKBitmap smallMap, int s_x, int s_y, int curX, int curY, bool isLeftOuter = false, bool isRightOuter = false, bool isTopOuter = false, bool isBottomOuter = false)
        {
            var newY = Calc_Offset_Y(smallMap, s_x, s_y, isTopOuter, isBottomOuter);
            var left_y = newY.Key;
            var left_y2 = newY.Value;

            if (curY >= left_y && curY <= left_y2)
            {
                var s_x2 = s_x + smallMap.Width / 2;
                if (curX >= s_x && curX <= s_x2)
                {
                    ExecuteCut(bigMap, smallMap, s_x, s_y, curX, curY);
                }
            }
        }
        private static void JigsawCut_Repair_Right(SKBitmap bigMap, SKBitmap smallMap, int s_x, int s_y, int curX, int curY, bool isLeftOuter = false, bool isRightOuter = false, bool isTopOuter = false, bool isBottomOuter = false)
        {
            var newY = Calc_Offset_Y(smallMap, s_x, s_y, isTopOuter, isBottomOuter);
            var right_y = newY.Key;
            var right_y2 = newY.Value;

            if (curY >= right_y && curY <= right_y2)
            {
                var s_x2 = s_x + smallMap.Width / 2 + 1;
                if (curX >= s_x2 && curX <= (s_x + smallMap.Width))
                {
                    ExecuteCut(bigMap, smallMap, s_x, s_y, curX, curY);
                }
            }
        }
        private static KeyValuePair<int, int> Calc_Offset_Y(SKBitmap smallMap, int s_x, int s_y, bool isTopOuter = false, bool isBottomOuter = false)
        {
            var _y = s_y + smallMap.Height / 2 - round_diameter / 2;
            _y = isTopOuter ? (_y + round_diameter / 4) : _y;
            _y = isBottomOuter ? (_y - round_diameter / 4) : _y;

            var _y2 = s_y + smallMap.Height / 2 + round_diameter / 2;
            _y2 = isTopOuter ? (_y2 + round_diameter / 4) : _y2;
            _y2 = isBottomOuter ? (_y2 - round_diameter / 4) : _y2;

            return new KeyValuePair<int, int>(_y, _y2);
        }
        private static int Calc_Offset_X(int originValue, SKBitmap smallMap, int s_x, int s_y, bool isLeftOuter = false, bool isRightOuter = false)
        {
            originValue = isLeftOuter ? (originValue + round_diameter / 4) : originValue;
            originValue = isRightOuter ? (originValue - round_diameter / 4) : originValue;
            return originValue;
        }
    }
}
