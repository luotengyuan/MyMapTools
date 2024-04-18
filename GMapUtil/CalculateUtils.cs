using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMapUtil
{
    public class CalculateUtils
    {
        private static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }

        /**
         * 地球半径 单位:千米
         */
        public static double EARTH_RADIUS = 6378.137;

        /**
         * 获取数据区带进位累加校验码
         *
         * @param byteData 数据
         * @return单字节带进位累加校验码
         */
        public static byte calCheckSumByte(byte[] byteData) {
            short result = 0;
            int len = 0;
            if (byteData == null || byteData.Length == 0) {
                return 0;
            }
            len = byteData.Length;
            for (int i = 0; i < len; i++) {
                result += (short)ConvertUtils.byteToInt(byteData[i]);
                if ((result & 0xff00) >> 8 != 0) {
                    char low = (char) ((char) ((result & 0xff00) >> 8) + (char) (result & 0x00ff));
                    result = (short) low;
                }
            }
            return (byte) (result & 0x00ff);
        }

        /**
         * 计算累加和 (使用时确保要计算累加和数据长度是byteData的长度)
         *
         * @param byteData 数据体
         * @return累加和
         */
        public static int calCheckSum(byte[] byteData) {
            return calCheckSum(byteData, byteData.Length);
        }

        /**
         * 计算累加和
         *
         * @param byteData 数据体
         * @param len      数据长度
         * @return累加和
         */
        public static int calCheckSum(byte[] byteData, int len) {
            int chksum = 0;
            if (byteData == null || byteData.Length < len) {
                return 0;
            }
            for (int i = 0; i < len; i++) {
                chksum += ConvertUtils.byteToInt(byteData[i]);
            }
            return chksum;
        }

        /**
         * 计算单个字节的补码，即: 如b>=0，则返回b；反之，则返回b的反码加1
         *
         * @param b 待计算的单字节数据
         * @return 补码
         */
        public static int calComplement(byte b) {
            return (b >= 0) ? b : (256 + b);
        }

        /**
         * 把角度值转换成弧度
         *
         * @param angle 角度值 单位:度
         * @return 弧度值 单位:弧度
         */
        public static double getRadValue(double angle) {
            return angle * Math.PI / 180.0;
        }

        /**
         * 根据两个位置的经纬度,来计算两地的距离 单位:米
         *
         * @param lon1 位置1经度
         * @param lat1 位置1纬度
         * @param lon2 位置2经度
         * @param lat2 位置2纬度
         * @return
         */
        public static double getDistance(double lon1, double lat1, double lon2, double lat2) {
            double a, b, d, sa2, sb2;
            lat1 = getRadValue(lat1);
            lat2 = getRadValue(lat2);
            a = lat1 - lat2;
            b = getRadValue(lon1 - lon2);

            sa2 = Math.Sin(a / 2.0);
            sb2 = Math.Sin(b / 2.0);
            d = 2 * EARTH_RADIUS * Math.Asin(Math.Sqrt(sa2 * sa2 + Math.Cos(lat1) * Math.Cos(lat2) * sb2 * sb2));
            return d * 1000;
        }

        /**
         * 计算线段的矢量化方向(与正北方向的夹角)
         *
         * @param lonStart 线段起点经度 单位:度
         * @param latStart 线段起点纬度 单位:度
         * @param lonEnd   线段终点经度 单位:度
         * @param latEnd   线段终点纬度 单位:度
         * @return 矢量化方向 单位:度
         */
        public static double getDirection(double lonStart, double latStart, double lonEnd, double latEnd) {
            double FromEc = 6356725 + (6378137 - 6356725) * (90.0 - latStart) / 90.0;
            double FromEd = FromEc * Math.Cos(latStart * Math.PI / 180.0);
            double dx = ((lonEnd * Math.PI / 180.0) - (lonStart * Math.PI / 180.0)) * FromEd;
            double dy = ((latEnd * Math.PI / 180.0) - (latStart * Math.PI / 180.0)) * FromEc;
            double angle = Math.Atan(Math.Abs(dx / dy)) * 180.0 / Math.PI;

            double dLon = lonEnd - lonStart;
            double dLat = latEnd - latStart;

            if (dLon > 0 && dLat <= 0) {
                angle = (90.0 - angle) + 90;
            } else if (dLon <= 0 && dLat < 0) {
                angle = angle + 180.0;
            } else if (dLon < 0 && dLat >= 0) {
                angle = (90.0 - angle) + 270;
            }

            return angle;
        }

        /**
         * 将距离单位米转成经纬度数差
         *
         * @param meter 缓冲区距离 单位:米
         * @return 度数差 单位:度
         */
        public static double meter2Deg(double meter) {
            // 1度等于111千米
            return meter * (1 / 111000.0);
        }

        /**
         * 将经度纬度距离近似转换成米
         *
         * @return
         */
        public static double deg2Meter(double deg) {
            // 1度等于111千米
            return deg * 111000.0;
        }
    }
}
