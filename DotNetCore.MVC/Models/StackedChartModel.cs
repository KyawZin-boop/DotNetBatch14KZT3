namespace DotNetCore.MVC.Models
{
    public class StackedChartModel
    {
        public StackedSeries[] Series { get; set; }
    }

    public class StackedSeries
    {
        public string name { get; set; }
        public object[] data { get; set; }
    }


    public class AreaChartModel
    {
        public List<SeriesData> Series { get; set; }
        public string[] Categories { get; set; }
    }

    public class SeriesData
    {
        public string Name { get; set; }
        public int[] Data { get; set; }
    }

    //RadarChart
    public class RadarChartModel
    {
        public string[] Labels { get; set; } // Labels for the radar chart (e.g., categories)
        public List<RadarChartDataset> Datasets { get; set; } // Multiple datasets for the radar chart
    }

    public class RadarChartDataset
    {
        public string Label { get; set; } // Name of the dataset
        public double[] Data { get; set; } // Data points
        public string BorderColor { get; set; } // Line color
        public string BackgroundColor { get; set; } // Fill color
    }

    //HighChart (Packed Bubble Chart)
    public class PackedBubbleSeries
    {
        public string Name { get; set; }
        public List<PackedBubbleData> Data { get; set; }
    }

    public class PackedBubbleData
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }

}
