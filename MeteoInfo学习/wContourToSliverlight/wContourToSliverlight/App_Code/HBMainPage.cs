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
using wContourToSliverlight.GetPointInfo;
using System.Windows.Browser;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client.Symbols;
using ESRI.ArcGIS.Client.Toolkit;


namespace wContourToSliverlight
{
    public partial class MainPageForGIS : UserControl
    {

        #region 加载并显示站位
        /// <summary>
        /// 加载站位
        /// author;du
        /// date:2012.03.26
        /// </summary>
        public void LoadStations(string strType)
        {
            wContourToSliverlight.GetPointInfo.PUBServicForGisLivingSoapClient client = new wContourToSliverlight.GetPointInfo.PUBServicForGisLivingSoapClient("PUBServicForGisLivingSoap", _paramerDic["GetPointInfoUrl"]);
            client.GetLatitudeAndLongitudeCompleted += new System.EventHandler<GetLatitudeAndLongitudeCompletedEventArgs>(clientGetLatitudeAndLongitudeCompleted);
            client.GetLatitudeAndLongitudeAsync(strType);

            gstrLayerType = "大气";
        }

        private void clientGetLatitudeAndLongitudeCompleted(object sender, GetLatitudeAndLongitudeCompletedEventArgs e)
        {
            gPointInfo = e.Result;
            if (gstrLayerType == FunType._Air)
            {
                BindAirRealData();//加载空气自动站实时数据
            }
        }

        /// <summary>
        /// 显示站位
        /// author:du
        /// date:2012.03.26
        /// </summary>
        public void ShowStation(string strLayerType)
        {

            ESRI.ArcGIS.Client.GraphicsLayer stationLayer = MyMap.Layers["StationGraphicsLayer"] as GraphicsLayer;
            stationLayer.ClearGraphics();
            //增加MapTip
            //this.MyMapTip.AllowDrop = true;
            //this.MyMapTip.GraphicsLayer = stationLayer;
            for (int i = 0; i < gPointInfo.Length; i++)
            {
                if (gPointInfo[i] != null)
                {
                    if (gPointInfo[i].Latitude > 0)
                    {

                        if (gPointInfo[i].CityCode.Substring(0, 4) == gCurrSeleCityCode.Substring(0, 4) || gCurrSeleCityCode.Substring(2, 4) == "0000") //dyx20130616只有省或选择的城市才能执行
                        {
                            Graphic graphic = new Graphic();

                            //element.Name = gPointInfo[i].CityName + gPointInfo[i].PName.Trim();
                            //element.Cursor = Cursors.Hand;

                            MarkerSymbol pSymbol = new MarkerSymbol();

                            switch (strLayerType)
                            {
                                case FunType._Air:

                                   // pSymbol = ((MarkerSymbol)Application.Current.Resources["airSymbol"]);
                                    pSymbol = setAirRealSymbol(gPointInfo[i].CityCode, gPointInfo[i].PCode);
                                    //pSymbol = setAirRealSymbol(gPointInfo[i].CityCode,gPointInfo[i].PCode);
                                    break;
                                case FunType._Water:
                                    pSymbol = ((MarkerSymbol)Application.Current.Resources["waterSymbol"]);
                                    break;
                                case FunType._Wry:
                                    pSymbol = ((MarkerSymbol)Application.Current.Resources["wrySymbol"]);
                                    break;
                                case FunType._Hssz:
                                    pSymbol = ((MarkerSymbol)Application.Current.Resources["hsszSymbol"]);
                                    break;
                                case FunType._Noise:
                                    pSymbol = ((MarkerSymbol)Application.Current.Resources["noiseSymbol"]);
                                    break;
                                case FunType._Dcfs:
                                    pSymbol = ((MarkerSymbol)Application.Current.Resources["dcfsSymbol"]);
                                    break;
                                case FunType._CSKQZLRB:
                                    pSymbol = ((MarkerSymbol)Application.Current.Resources["airSymbol"]);
                                    break;
                                case FunType._HLSZYB:
                                    pSymbol = ((MarkerSymbol)Application.Current.Resources["waterSymbol"]);
                                    break;
                                case FunType._HLSZZB:
                                    pSymbol = ((MarkerSymbol)Application.Current.Resources["waterSymbol"]);
                                    break;
                                case FunType._HLSZNB:
                                    pSymbol = ((MarkerSymbol)Application.Current.Resources["waterSymbol"]);
                                    break;
                                case FunType._YYSYDYB:
                                    pSymbol = ((MarkerSymbol)Application.Current.Resources["drinkSymbol"]);
                                    break;
                                default:
                                    pSymbol = ((MarkerSymbol)Application.Current.Resources["airSymbol"]);
                                    break;
                            }

                            //graphic.AddHandler(Pushpin.MouseLeftButtonDownEvent, new MouseButtonEventHandler(station_MouseLeftButtonDown), true);

                            // element.Tag = (this.gPointInfo[i]);

                            //Location location = new Location(System.Convert.ToDouble(gPointInfo[i].Latitude), System.Convert.ToDouble(gPointInfo[i].Longitude));
                            //ToolTipService.SetToolTip(element, gPointInfo[i].CityName + gPointInfo[i].PName.Trim());

                            ESRI.ArcGIS.Client.Geometry.Geometry pPoint = mercator.FromGeographic(new MapPoint(System.Convert.ToDouble(gPointInfo[i].Longitude), System.Convert.ToDouble(gPointInfo[i].Latitude)));
                            //this.layStation.AddChild(element, location);
                            graphic.Geometry = pPoint;
                            graphic.Attributes["tag"] = (this.gPointInfo[i]);
                            graphic.Attributes["GName"] = gPointInfo[i].CityName + gPointInfo[i].PName.Trim();
                            graphic.Attributes["CityName"] = gPointInfo[i].CityName;
                            graphic.Symbol = pSymbol;
                            graphic.MapTip = new MapTip();
                            //ToolTipService.SetToolTip((System.Windows.UIElement)graphic, gPointInfo[i].CityName + gPointInfo[i].PName.Trim());


                            stationLayer.Graphics.Add(graphic);
                        }
                    }
                }
            }
        }
        #endregion

        #region 设置空气实时数据的符号
        public MarkerSymbol setAirRealSymbol(string strCityCode,string strPCode)
        {
            MarkerSymbol pSymbol = new MarkerSymbol();
            pSymbol = ((MarkerSymbol)Application.Current.Resources["airSymbol"]);

            string strAQI = "";

            for (int i = 0; i < pPointItemInfoEx.Count; i++)
            {
                if (pPointItemInfoEx[i] != null)
                {
                    if (pPointItemInfoEx[i].PCode == strPCode && pPointItemInfoEx[i].cityCode == strCityCode)
                    {
                        // strAQI = pPointItemInfoEx[i].AQI;
                        strAQI = getAirPAQI(pPointItemInfoEx[i]);
                        //strAQI = "35";//???临时
                        if (strAQI != "")
                        {
                            AirAQIInfo airAQI = new AirAQIInfo(strAQI);
                            pSymbol = airAQI.pSymbol;
                        }
                        return pSymbol;

                    }
                }
            }
            return pSymbol;

        }

        /// <summary>
        /// 根据选择的是AQI还是监测因子返回对应的AQI
        /// </summary>
        /// <param name="piie"></param>
        /// <returns></returns>
        private string getAirPAQI (PointItemInfoEx piie)
        {
            string strAQI = "--";
            if (gstrStationItemCode == "AQI")
            {
                strAQI = piie.AQI;
            }
            else if (gstrStationItemCode == "101")
            {
                strAQI = piie.SO2AQI;
            }
            else if (gstrStationItemCode == "141")
            {
                strAQI = piie.NO2AQI;
            }
            else if (gstrStationItemCode == "107")
            {
                strAQI = piie.PM1024AQI;
            }
            else if (gstrStationItemCode == "105")
            {
                strAQI = piie.PM2524AQI;
            }
            else if (gstrStationItemCode == "106")
            {
                strAQI = piie.COAQI;
            }
            else if (gstrStationItemCode == "108")
            {
                strAQI = piie.O38AQI;
            }
            else if (gstrStationItemCode == "101")
            {
                strAQI = piie.SO2AQI;
            }

            return strAQI;
        }
        #endregion

        #region   获取点位对应的AQI
        /// <summary>
        /// 获取点位对应的AQI
        /// </summary>
        /// <param name="strCityCode"></param>
        /// <param name="strPCode"></param>
        /// <returns></returns>
        private double getAQIByPoint(string strCityCode, string strPCode)
        {
            double dAQI = 0;
            for (int i = 0; i < pPointItemInfoEx.Count; i++)
            {
                if (pPointItemInfoEx[i] != null)
                {
                    if (pPointItemInfoEx[i].PCode == strPCode && pPointItemInfoEx[i].cityCode == strCityCode)
                    {
                        // strAQI = pPointItemInfoEx[i].AQI;
                        if (CommonLib.IsNumeric(pPointItemInfoEx[i].AQI) == true)
                        {
                            dAQI =System.Convert.ToDouble( pPointItemInfoEx[i].AQI);
                        }

                        break;

                    }
                }
            }
            return dAQI;
        }

        #endregion
    }


    public class PointItemInfoEx
    {
        public string cityCode { get; set; }
        public string PCode { get; set; }
        public string cityName { get; set; }
        public string pcodeName { get; set; }
        public string AQI { get; set; }
        public string CPI { get; set; }//首要污染物
        public string SO2Value { get; set; }
        public string NO2Value { get; set; }
        public string PM10Value { get; set; }
        public string PM1024Value { get; set; }//PM10的24小时均值
        public string PM25Value { get; set; }
        public string PM2524Value { get; set; }//PM25的24小时均值
        public string COValue { get; set; }
        public string O3Value { get; set; }
        public string O38Value { get; set; }//臭氧8小时滑动均值
        public string SO2AQI { get; set; }
        public string NO2AQI { get; set; }
        public string PM10AQI { get; set; }
        public string PM1024AQI { get; set; }//PM10的24小时滑动AQI
        public string PM25AQI { get; set; }
        public string PM2524AQI { get; set; }//PM25的24小时滑动AQI
        public string COAQI { get; set; }
        public string O3AQI { get; set; }
        public string O38AQI { get; set; }//O3的8小时滑动AQI
        public string ETime { get; set; }
        public string EDate { get; set; }
        public string KQZLZK { get; set; }//空气质量状况
        public string JYCQCS { get; set; }//建议采取措施
        public PointItemInfoEx(string _pcodeName, string _AQI, string _SO2Value, string _NO2Value, string _PM10Value, string _PM1024Value, string _PM25Value, string _PM2524Value,

            string _COValue, string _O3Value, string _O38Value, string _SO2AQI, string _NO2AQI, string _PM10AQI, string _PM1024AQI, string _PM25AQI, string _PM2524AQI,

            string _COAQI, string _O3AQI, string _O38AQI, string _strETime, string _strEDate, string _cityName, string _cityCode, string _PCode, string _KQZLZK, string _JYCQCS, string _CPI)
        {
            this.cityName = _cityName;
            this.pcodeName = _pcodeName;
            this.AQI = _AQI;
            this.SO2Value = _SO2Value;
            this.NO2Value = _NO2Value;
            this.PM10Value = _PM10Value;
            this.PM1024Value = _PM1024Value;
            this.PM1024AQI = _PM1024AQI;
            this.PM25Value = _PM25Value;
            this.PM2524Value = _PM2524Value;
            this.PM2524AQI = _PM2524AQI;
            this.COValue = _COValue;
            this.O3Value = _O3Value;
            this.O38Value = _O38Value;
            this.SO2AQI = _SO2AQI;
            this.NO2AQI = _NO2AQI;
            this.PM10AQI = _PM10AQI;
            this.PM25AQI = _PM25AQI;
            this.COAQI = _COAQI;
            this.O3AQI = _O3AQI;
            this.O38AQI = _O38AQI;
            this.ETime = _strETime;
            this.EDate = _strEDate;
            this.cityCode = _cityCode;
            this.PCode = _PCode;
            this.KQZLZK = _KQZLZK;
            this.JYCQCS = _JYCQCS;
            this.CPI = _CPI;

        }
        public PointItemInfoEx()
        {

        }

    }

    #region 空气质量指数相关信息
    public class AirAQIInfo
    {
        public string AQI { get; set; } //空气质量指数
        public string Grade { get; set; }//空气质量指数级别
        public string GradeClass { get; set; }//空气质量指数类别
        public string GradeColor { get; set; }//空气质量指数表示颜色
        public string JKYXQK { get; set; }//对健康影响情况
        public string JYCQCS { get; set; }//建议采取的措施

        public MarkerSymbol pSymbol = new MarkerSymbol();//符号


        public AirAQIInfo(string strAQI)
        {
            double dblAQI = 0;
            if (strAQI != "")
            {
                dblAQI = System.Convert.ToDouble(strAQI);
                if (dblAQI >= 0 && dblAQI <= 50)
                {
                    this.AQI = strAQI;
                    this.Grade = "一级";
                    this.GradeClass = "优";
                    this.GradeColor = "绿色";
                    this.JKYXQK = "空气质量令人满意，基本无空气污染";
                    this.JYCQCS = "各类人群可正常活动";

                    this.pSymbol = ((MarkerSymbol)Application.Current.Resources["airGrade1"]);
                }

                if (dblAQI >= 51 && dblAQI <= 100)
                {
                    this.AQI = strAQI;
                    this.Grade = "二级";
                    this.GradeClass = "良";
                    this.GradeColor = "黄色";
                    this.JKYXQK = "空气质量可接受，但某些污染物可能对极少数异常敏感人群健康有较弱影响";
                    this.JYCQCS = "极少数异常敏感人群应减少户外活动";
                    //this.JKYXQK = "空气质量可接受，但某些污染物可能对\n极少数异常敏感人群健康有较弱影响";
                    //this.JYCQCS = "极少数异常敏感人群应\n减少户外正常活动";

                    this.pSymbol = ((MarkerSymbol)Application.Current.Resources["airGrade2"]);
                }

                if (dblAQI >= 101 && dblAQI <= 150)
                {
                    this.AQI = strAQI;
                    this.Grade = "三级";
                    this.GradeClass = "轻度污染";
                    this.GradeColor = "橙色";
                    this.JKYXQK = "易感人群症状有轻度加剧，\n健康人群出现刺激症状";
                    this.JYCQCS = "儿童、老年人及心脏病、呼吸系统疾病患者应减少长时间、高强度的户外锻炼";

                    this.pSymbol = ((MarkerSymbol)Application.Current.Resources["airGrade3"]);
                }

                if (dblAQI >= 151 && dblAQI <= 200)
                {
                    this.AQI = strAQI;
                    this.Grade = "四级";
                    this.GradeClass = "中度污染";
                    this.GradeColor = "红色";
                    this.JKYXQK = "进一步加剧易感人群症状，可能对健康人群\n心脏、呼吸系统有影响";
                    this.JYCQCS = "儿童、老年人及心脏病、呼吸系统疾病患者应避免长时间、高强度的户外锻炼，一般人群适量减少户外运动";

                    this.pSymbol = ((MarkerSymbol)Application.Current.Resources["airGrade4"]);
                }

                if (dblAQI >= 201 && dblAQI <= 300)
                {
                    this.AQI = strAQI;
                    this.Grade = "五级";
                    this.GradeClass = "重度污染";
                    this.GradeColor = "紫色";
                    this.JKYXQK = "心脏病和肺病患者症状显著加剧，运动耐受力\n降低，健康人群普遍出现症状";
                    this.JYCQCS = "儿童、老年人及心脏病、呼吸系统疾病患者应停留在室内，停止户外活动，一般人群应避免户外活动";

                    this.pSymbol = ((MarkerSymbol)Application.Current.Resources["airGrade5"]);
                }

                if (dblAQI > 300)
                {
                    this.AQI = strAQI;
                    this.Grade = "六级";
                    this.GradeClass = "严重污染";
                    this.GradeColor = "褐红色";
                    this.JKYXQK = "健康人群运动耐受力降低，有明显强烈症状，\n提前出现某些疾病";
                    this.JYCQCS = "儿童、老年人及心脏病、呼吸系统疾病患者应停留在室内，避免体力消耗，一般人群应避免户外活动";

                    this.pSymbol = ((MarkerSymbol)Application.Current.Resources["airGrade6"]);
                }

            }

        }
    }
    #endregion

}
