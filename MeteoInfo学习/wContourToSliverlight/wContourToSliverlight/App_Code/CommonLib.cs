using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace wContourToSliverlight
{
    public static class CommonLib
    {
        /// <summary>
        ///判断输入字符串是否为数字
        /// </summary>
        /// <param name="nValue">字符串</param>
        /// <returns></returns>
        public static bool IsNumeric(string nValue)
        {
            int i, iAsc, idecimal = 0;
            if (nValue.Trim() == "") return false;
            for (i = 0; i <= nValue.Length - 1; i++)
            {
                iAsc = (int)System.Convert.ToChar(nValue.Substring(i, 1));
                //'-'45 '.'46 '''0-9' 48-57
                if (iAsc == 45)
                {
                    if (nValue.Length == 1)//不能只有一个负号
                    {
                        return false;
                    }
                    if (i != 0)   //'-'不能在字符串中间
                    {
                        return false;
                    }
                }
                else if (iAsc == 46)
                {
                    idecimal++;
                    if (idecimal > 1)  //如果有两个以上的小数点
                        return false;
                }
                else if (iAsc < 48 || iAsc > 57)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
