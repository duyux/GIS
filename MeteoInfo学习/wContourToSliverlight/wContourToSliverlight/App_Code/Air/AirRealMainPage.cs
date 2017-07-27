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
using System.Collections.Generic;
using System.Linq;
using ESRI.ArcGIS.Client.Symbols;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using System.Windows.Data;
using wContourToSliverlight.GetPointInfo;

namespace wContourToSliverlight
{
    /// <summary>
    /// 存放空气自动站实时数据相关的功能
    /// </summary>
    public partial class MainPageForGIS : UserControl
    {
        #region  空气自动站实时数据
        private void BindAirRealData()
        {

            GetPointInfo.PUBServicForGisLivingSoapClient client = new GetPointInfo.PUBServicForGisLivingSoapClient("PUBServicForGisLivingSoap", _paramerDic["GetPointInfoUrl"]);
            client.GetAirAllPointValueCompleted += new System.EventHandler<GetAirAllPointValueCompletedEventArgs>(clientGetAirAllPointValueCompleted);
            client.GetAirAllPointValueAsync();

        }
        private void clientGetAirAllPointValueCompleted(object sender, GetPointInfo.GetAirAllPointValueCompletedEventArgs e)
        {
            AirPointItemReport = e.Result;
            pPointItemInfoEx = getPointItemInfoEx();

            ShowStation(gstrLayerType);//显示测点

            //DoContour();//等值线
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<PointItemInfoEx> getPointItemInfoEx()
        {
            List<PointItemInfoEx> pTempPointInfoEx = new List<PointItemInfoEx>();
            pTempPointInfoEx.Clear();
            PointItemInfoEx[] pTempArray = new PointItemInfoEx[500];

            AirAQIInfo airAQI=null;

            int k = -1;
            for (int i = 0; i < AirPointItemReport.Length; i++)
            {
               
                PointInfo pSelePI = getSelePointInfo(AirPointItemReport[i].pcode, AirPointItemReport[i].CityCode);
                if (pSelePI != null)  //只显示有经纬度的
                {
                    if (pSelePI.Latitude > 0)
                    {
                       
                        if (AirPointItemReport[i].itemCharCode == "测点:")
                        {
                            k = k + 1;
                            pTempArray[k] = new PointItemInfoEx();
                            pTempArray[k].pcodeName = AirPointItemReport[i].itemValue;
                            pTempArray[k].PCode = AirPointItemReport[i].pcode;
                           // pTempArray[k].PAttribute = pSelePI.Attribute ;//测点属性，如郊区点
                            pTempArray[k].cityName = AirPointItemReport[i].CityName;
                            pTempArray[k].cityCode = AirPointItemReport[i].CityCode;
                            pTempArray[k].AQI= AirPointItemReport[i].ItemAQI;
                            pTempArray[k].CPI = AirPointItemReport[i].CPI;

                            pTempArray[k].PM1024Value = AirPointItemReport[i].PM10Value;//24小时均值
                            pTempArray[k].PM2524Value  = AirPointItemReport[i].PM25Value;//24小时均值
                            pTempArray[k].O3Value = AirPointItemReport[i].O3Value;//8小时滑动均值

                            airAQI = new AirAQIInfo(pTempArray[k].AQI);
                            pTempArray[k].KQZLZK = airAQI.GradeClass;
                            pTempArray[k].JYCQCS = airAQI.JYCQCS;
                           // pTempArray[k].JYCQCSImg = airAQI.JYCQCSImg;
                            

                            pTempArray[k].ETime = System.Convert.ToDateTime(System.DateTime.Now.Year.ToString() + "-" + AirPointItemReport[i].itemEtime).ToString("HH：mm");
                            pTempArray[k].EDate = System.Convert.ToDateTime(System.DateTime.Now.Year.ToString() + "-" + AirPointItemReport[i].itemEtime).ToString("yyyy年MM月dd日");

                        }
                        if (AirPointItemReport[i].itemCharCode == "SO2:")
                        {
                           
                                if (pTempArray[k].SO2Value == null)
                                {
                                    if (AirPointItemReport[i].itemValue == "NA" || AirPointItemReport[i].itemValue == "--")
                                    {
                                        pTempArray[k].SO2Value = AirPointItemReport[i].itemValue ;
                                        pTempArray[k].SO2AQI = AirPointItemReport[i].ItemAQI;
                                    }
                                    else
                                    {
                                        //pTempArray[k].SO2Value = (System.Convert.ToDouble(AirPointItemReport[i].itemValue) * 1000).ToString();
                                        if (AirPointItemReport[i].itemValue != "")
                                        {
                                            pTempArray[k].SO2Value = AirPointItemReport[i].itemValue;
                                        }
                                        pTempArray[k].SO2AQI = AirPointItemReport[i].ItemAQI;
                                    }
                                }
                      
                        }
                        if (AirPointItemReport[i].itemCharCode == "PM10:")
                        {
                           
                                if (pTempArray[k].PM10Value == null)
                                {
                                    if (AirPointItemReport[i].itemValue == "NA" || AirPointItemReport[i].itemValue == "--")
                                    {
                                        pTempArray[k].PM10Value = AirPointItemReport[i].itemValue;
                                        pTempArray[k].PM10AQI = AirPointItemReport[i].ItemAQI;

                                        pTempArray[k].PM1024Value = AirPointItemReport[i].PM10Value;//PM10的24小时均值
                                        pTempArray[k].PM1024AQI = AirPointItemReport[i].PM10AQIValue;//PM10的24小时AQI
                                    }
                                    else
                                    {
                                        //pTempArray[k].PM10Value = (System.Convert.ToDouble(AirPointItemReport[i].itemValue) * 1000).ToString();
                                        if (AirPointItemReport[i].itemValue != "")
                                        {
                                            pTempArray[k].PM10Value = AirPointItemReport[i].itemValue;
                                        }
                                        if (AirPointItemReport[i].ItemAQI != "")
                                        {
                                            pTempArray[k].PM10AQI = AirPointItemReport[i].ItemAQI;
                                        }


                                        if (AirPointItemReport[i].PM10Value != "" ) //PM10的24小时均值
                                        {
                                            pTempArray[k].PM1024Value = AirPointItemReport[i].PM10Value;
                                        }
                                        if (AirPointItemReport[i].PM10AQIValue != "")//PM10的24小时AQI
                                        {
                                            pTempArray[k].PM1024AQI = AirPointItemReport[i].PM10AQIValue;
                                        }
                                    }
                                }
                           
                        }
                        if (AirPointItemReport[i].itemCharCode == "NO2:")
                        {
                           
                                if (pTempArray[k].NO2Value == null)
                                {
                                    if (AirPointItemReport[i].itemValue == "NA" || AirPointItemReport[i].itemValue == "--")
                                    {
                                        pTempArray[k].NO2Value = AirPointItemReport[i].itemValue;
                                        pTempArray[k].NO2AQI = AirPointItemReport[i].ItemAQI;
                                    }
                                    else
                                    {
                                        //pTempArray[k].NO2Value = (System.Convert.ToDouble(AirPointItemReport[i].itemValue) * 1000).ToString();
                                        if (AirPointItemReport[i].itemValue != "")
                                        {
                                            pTempArray[k].NO2Value = AirPointItemReport[i].itemValue;
                                        }
                                        if (AirPointItemReport[i].ItemAQI != "")
                                        {
                                            pTempArray[k].NO2AQI = AirPointItemReport[i].ItemAQI;
                                        }
                                    }
                                    }
                                }
                       
                        }
                        if (AirPointItemReport[i].itemCharCode == "PM25:")
                        {
                           
                                if (pTempArray[k].PM25Value == null)
                                {
                                    if (AirPointItemReport[i].itemValue == "NA" || AirPointItemReport[i].itemValue == "--")
                                    {
                                        pTempArray[k].PM25Value = AirPointItemReport[i].itemValue;
                                        pTempArray[k].PM25AQI = AirPointItemReport[i].ItemAQI;

                                        pTempArray[k].PM2524Value = AirPointItemReport[i].PM25Value;//PM25的24小时均值
                                        pTempArray[k].PM2524AQI = AirPointItemReport[i].PM25AQIValue;//PM25的24小时AQI
                                    }
                                    else
                                    {
                                        //pTempArray[k].PM25Value = (System.Convert.ToDouble(AirPointItemReport[i].itemValue) * 1000).ToString();
                                        if (AirPointItemReport[i].itemValue != "")
                                        {
                                            pTempArray[k].PM25Value = AirPointItemReport[i].itemValue;
                                        }
                                        if (AirPointItemReport[i].ItemAQI != "")
                                        {
                                            pTempArray[k].PM25AQI =AirPointItemReport[i].ItemAQI;
                                        }

                                        if (AirPointItemReport[i].PM25Value != "") //PM25的24小时均值
                                        {
                                            pTempArray[k].PM2524Value = AirPointItemReport[i].PM25Value;
                                        }
                                        if (AirPointItemReport[i].PM25AQIValue != "") //PM25的24小时AQI
                                        {
                                            pTempArray[k].PM2524AQI = AirPointItemReport[i].PM25AQIValue;
                                        }
                                    }
                                }
                           

                        }
                        if (AirPointItemReport[i].itemCharCode == "CO:")
                        {
                           
                                if (pTempArray[k].COValue == null)
                                {
                                    if (AirPointItemReport[i].itemValue == "NA" || AirPointItemReport[i].itemValue == "--")
                                    {
                                        pTempArray[k].COValue = AirPointItemReport[i].itemValue;
                                        pTempArray[k].COAQI= AirPointItemReport[i].ItemAQI;
                                    }
                                    else
                                    {
                                        if (AirPointItemReport[i].itemValue != "")
                                        {
                                            pTempArray[k].COValue =(System.Convert.ToDouble(AirPointItemReport[i].itemValue)).ToString("0.00");
                                        }
                                        pTempArray[k].COAQI = AirPointItemReport[i].ItemAQI;

                                    }
                                }
                           
                        }
                        if (AirPointItemReport[i].itemCharCode == "O3:")
                        {

                            if (pTempArray[k].O3Value == null || pTempArray[k].O3Value == "")
                                {
                                    if (AirPointItemReport[i].itemValue == "NA" || AirPointItemReport[i].itemValue == "--")
                                    {
                                        pTempArray[k].O3Value = AirPointItemReport[i].itemValue;
                                        pTempArray[k].O3AQI = AirPointItemReport[i].ItemAQI;

                                        pTempArray[k].O38Value  = AirPointItemReport[i].O3Value;//O3的8小时均值
                                        pTempArray[k].O38AQI = AirPointItemReport[i].O3AQIValue;//O3的8小时AQI
                                    }
                                    else
                                    {
                                        //pTempArray[k].O3Value = (System.Convert.ToDouble(AirPointItemReport[i].itemValue) * 1000).ToString();
                                        if (AirPointItemReport[i].itemValue != "")
                                        {
                                            pTempArray[k].O3Value = AirPointItemReport[i].itemValue;
                                        }
                                        if (AirPointItemReport[i].ItemAQI != "")
                                        {
                                            pTempArray[k].O3AQI =AirPointItemReport[i].ItemAQI;
                                        }

                                        if (AirPointItemReport[i].O3Value != "")//O3的8小时均值
                                        {
                                            pTempArray[k].O38Value = AirPointItemReport[i].O3Value;
                                        }
                                        if (AirPointItemReport[i].O3AQIValue != "")//O3的8小时AQI
                                        {
                                            pTempArray[k].O38AQI = AirPointItemReport[i].O3AQIValue;
                                        }
                                    }
                                }
                           
                        }
                    }
            }

         
            for (int j = 0; j < pTempArray.Length; j++)
            {
                if (pTempArray[j] != null)
                {
                    if (pTempArray[j].pcodeName != "")
                    {
                       
                       
                            if (gCurrSeleCityCode != "")
                            {
                                
                                if (gCurrSeleCityCode.Substring(2, 4) == "0000")  //省
                                {
                                    pTempPointInfoEx.Add(pTempArray[j]);
                                }

                                
                                if (gCurrSeleCityCode.Substring(0, 4) == pTempArray[j].cityCode.Substring(0, 4))//过滤相应城市的数据列表
                                {
                                    pTempPointInfoEx.Add(pTempArray[j]);
                                }
                                
                            }
                            else
                            {
                                pTempPointInfoEx.Add(pTempArray[j]);
                            }
                        
                    }
                }

            }

            return pTempPointInfoEx;
        }
        /// <summary>
        /// 根据点位代码获取PointInfo
        /// </summary>
        /// <param name="strPCodeName"></param>
        /// <param name="strCityCode"></param>
        public PointInfo getSelePointInfo(string strPCode, string strCityCode)
        {

            for (int i = 0; i < gPointInfo.Length; i++)
            {
                if (gPointInfo[i].CityCode == strCityCode && gPointInfo[i].PCode == strPCode)
                {

                    return gPointInfo[i];
                }
            }

            return null;
        }
        #endregion
    }
}
