using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapToolsWinForm
{
    class ConvertUtils
    {
        /**
         * 将字节转化为整型
         *
         * @param a
         * @return Int 整数
         */
        public static int byteToInt(byte a)
        {
            return (a & 0xff);
        }

        /**
         * 将字节数组转成整数(大端模式,高字节在低位即byteArray[0])
         *
         * @param byteData
         * @return整数
         */
        public static int byteArrayToInt(byte[] byteData)
        {
            int result = 0;
            int len = 0;
            if (byteData == null || byteData.Length == 0)
            {
                return 0;
            }
            len = byteData.Length;
            for (int i = 0; i < len; i++)
            {
                result |= (byteData[i] & 0xff) << (len - 1 - i) * 8;
            }
            return result;
        }

        /**
         * 将数组中存的2个数组为整数
         *
         * @param a 最高位
         * @param b
         * @return Int 整数
         */
        public static int byteArraytoShort(byte a, byte b)
        {
            int result = 0;
            int a1 = byteToInt(a);
            int b1 = byteToInt(b);
            result += a1 * 256 + b1;

            if (a < 0)
            {
                result = result - 65536;
            }

            return result;
        }

        /**
         * 将数组中存的四个数组为整数
         *
         * @param a 最高位
         * @param b
         * @param c
         * @param d 最低位
         * @return Int 整数
         */
        public static int byteArraytoInt(byte a, byte b, byte c, byte d)
        {
            int result = 0;
            int a1 = byteToInt(a);
            int b1 = byteToInt(b);
            int c1 = byteToInt(c);
            int d1 = byteToInt(d);

            result += a1 * 256 * 256 * 256 + b1 * 256 * 256 + c1 * 256 + d1;
            return result;
        }

        /**
         * 整形转数组
         *
         * @param value
         * @return
         */
        public static byte[] intToByteArray(int value)
        {
            byte[] result = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                result[i] = (byte)(value >> 8 * (3 - i) & 0xff);
            }
            return result;
        }

        /**
         * short型转数组
         *
         * @param value
         * @return
         */
        public static byte[] shortToByteArray(short value)
        {
            byte[] result = new byte[2];
            for (int i = 0; i < 2; i++)
            {
                result[i] = (byte)(value >> 8 * (1 - i) & 0xff);
            }
            return result;
        }

        /**
         * asc转为bcd
         *
         * @param asc
         * @return
         */
        public static byte asc_to_bcd(byte asc)
        {
            byte bcd;

            if ((asc >= '0') && (asc <= '9'))
                bcd = (byte)(asc - '0');
            else if ((asc >= 'A') && (asc <= 'F'))
                bcd = (byte)(asc - 'A' + 10);
            else if ((asc >= 'a') && (asc <= 'f'))
                bcd = (byte)(asc - 'a' + 10);
            else
                bcd = (byte)(asc - 48);
            return bcd;
        }

        /**
         * asc转为bcd
         *
         * @param ascii
         * @param asc_len
         * @return
         */
        public static byte[] ASCII_To_BCD(byte[] ascii, int asc_len)
        {
            byte[] bcd = new byte[asc_len / 2];
            int j = 0;
            for (int i = 0; i < (asc_len + 1) / 2; i++)
            {
                bcd[i] = asc_to_bcd(ascii[j++]);
                bcd[i] = (byte)(((j >= asc_len) ? 0x00 : asc_to_bcd(ascii[j++])) + (bcd[i] << 4));
            }
            return bcd;
        }

        public static char[] hex = {
            '0', '1', '2', '3', '4', '5', '6', '7',
            '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'
        };
    }
}
