﻿namespace DotNetCore.MVC.Models
{
    public class ChartsModel
    {
    }
    public class PieChartModel
    {
        public int[] Series { get; set; }
        public string[] Labels { get; set; }
    }

    public class LineChartModel
    {
        public int[] Series { get; set; }
        public string[] Labels { get; set; }
    }

    public class BarChartModel
    {
        public int[] Series { get; set; }
        public string[] Labels { get; set; }
    }

    public class MixedChartModel
    {
        public int[] Series1 { get; set; }
        public int[] Series2 { get; set; }
        public string[] Labels { get; set; }
    }

    public class FunnelChartModel
    {
        public int[] Series { get; set; }
        public string[] Labels { get; set; }
    }

    //ChartJs
    public class LineChartJSModel
    {
        public int[] Data { get; set; }
        public string[] Labels { get; set; }
    }

    public class BarChartJSModel
    {
        public int[] Data { get; set; }
        public string[] Labels { get; set; }
    }

    public class PieChartJSModel
    {
        public int[] Data { get; set; }
        public string[] Labels { get; set; }
    }

    public class RadarChartJSModel
    {
        public int[] Data { get; set; }
        public string[] Labels { get; set; }
    }

    public class PolarAreaChartJSModel
    {
        public int[] Data { get; set; }
        public string[] Labels { get; set; }
    }

    //HighCharts
    public class PieHighChartModel
    {
        public string[] Categories { get; set; }
        public double[] Data { get; set; }
    }

    public class ColumnHighChartModel
    {
        public string[] Categories { get; set; }
        public int[] Data { get; set; }
    }
    public class LineHighChartModel
    {
        public string[] Categories { get; set; }
        public int[] Data { get; set; }
    }
    public class AreaHighChartModel
    {
        public string[] Categories { get; set; }
        public double[] Data { get; set; }
    }
    public class ScatterHighChartModel
    {
        public double[][] Data { get; set; }
    }

    //CanvasJs
    public class PieCanvasJsModel
    {
        public string[] Categories { get; set; }
        public double[] Data { get; set; }
    }
    public class ColumnCanvasJsModel
    {
        public string[] Categories { get; set; }
        public int[] Data { get; set; }
    }
    public class LineCanvasJsModel
    {
        public string[] Categories { get; set; }
        public int[] Data { get; set; }
    }
    public class AreaCanvasJsModel
    {
        public string[] Categories { get; set; }
        public double[] Data { get; set; }
    }
    public class ScatterCanvasJsModel
    {
        public double[][] Data { get; set; }
    }
}
