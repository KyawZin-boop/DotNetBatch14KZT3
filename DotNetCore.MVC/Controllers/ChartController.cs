using DotNetCore.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.MVC.Controllers
{
    public class ChartController : Controller
    {
        //ApexChart
        public IActionResult StackedChart()
        {
            var model = new StackedChartModel
            {
                Series = new[]
                {
            new StackedSeries
            {
                name = "South",
                data = GenerateDayWiseTimeSeries(new DateTime(2017, 2, 11), 20, 10, 60)
            },
            new StackedSeries
            {
                name = "North",
                data = GenerateDayWiseTimeSeries(new DateTime(2017, 2, 11), 20, 10, 20)
            },
            new StackedSeries
            {
                name = "Central",
                data = GenerateDayWiseTimeSeries(new DateTime(2017, 2, 11), 20, 10, 15)
            }
        }
            };

            return View(model);
        }

        private object[] GenerateDayWiseTimeSeries(DateTime start, int count, int min, int max)
        {
            var random = new Random();
            var data = new List<object>();
            for (var i = 0; i < count; i++)
            {
                var timestamp = new DateTimeOffset(start.AddDays(i)).ToUnixTimeMilliseconds(); // Convert to milliseconds
                data.Add(new object[] { timestamp, random.Next(min, max) });
            }
            return data.ToArray();
        }

        //CanvasJs (Multi Series Area)
        public IActionResult MultiSeriesAreaChart()
        {
            AreaChartModel model = new AreaChartModel
            {
                Series = new List<SeriesData>
        {
            new SeriesData { Name = "Ladakh", Data = new[] { 5, 7, 7, 9, 10, 8, 6, 6, 6, 5, 6, 7, 7, 5, 7, 7, 8, 7, 7, 7 } },
            new SeriesData { Name = "Chandigarh", Data = new[] { 15, 16, 14, 15, 17, 19, 20, 15, 16, 16, 16, 17, 20, 17, 18, 20, 17, 19, 16, 17 } },
            new SeriesData { Name = "Delhi", Data = new[] { 28, 29, 30, 31, 32, 31, 30, 29, 28, 27, 27, 28, 30, 31, 30, 29, 28, 29, 30, 31 } },
            new SeriesData { Name = "Mumbai", Data = new[] { 26, 27, 28, 29, 30, 30, 31, 31, 30, 29, 28, 28, 29, 30, 31, 32, 33, 32, 31, 30 } },
            new SeriesData { Name = "Kolkata", Data = new[] { 30, 31, 32, 33, 34, 34, 33, 33, 32, 31, 30, 30, 31, 32, 33, 34, 34, 33, 32, 31 } },
            new SeriesData { Name = "Chennai", Data = new[] { 32, 33, 34, 35, 36, 36, 37, 37, 36, 35, 34, 34, 35, 36, 37, 38, 38, 37, 36, 35 } },
            new SeriesData { Name = "Bangalore", Data = new[] { 24, 25, 26, 27, 28, 28, 27, 26, 25, 24, 24, 25, 26, 27, 28, 29, 28, 27, 26, 25 } },
            new SeriesData { Name = "Hyderabad", Data = new[] { 28, 29, 30, 31, 32, 33, 34, 33, 32, 31, 30, 30, 31, 32, 33, 34, 33, 32, 31, 30 } }
        },
                Categories = new string[]
                {
            "1 Apr", "2 Apr", "3 Apr", "4 Apr", "5 Apr", "6 Apr", "7 Apr", "8 Apr", "9 Apr", "10 Apr",
            "11 Apr", "12 Apr", "13 Apr", "14 Apr", "15 Apr", "16 Apr", "17 Apr", "18 Apr", "19 Apr", "20 Apr"
                }
            };
            return View(model);
        }


        //ChartJs (RadarChart)
        public IActionResult RadarChart()
        {
            var model = new RadarChartModel
            {
                Labels = new[]
                {
            "Communication", "Problem-Solving", "Teamwork", "Leadership",
            "Creativity", "Technical Skills", "Adaptability", "Time Management"
        },
                Datasets = new List<RadarChartDataset>
        {
            new RadarChartDataset
            {
                Label = "Employee A",
                Data = new[] { 8.0, 7.0, 6.5, 8.5, 9.0, 7.5, 8.0, 8.5 },
                BorderColor = "rgba(255, 99, 132, 1)",
                BackgroundColor = "rgba(255, 99, 132, 0.2)"
            },
            new RadarChartDataset
            {
                Label = "Employee B",
                Data = new[] { 7.0, 8.0, 7.5, 7.0, 8.5, 8.0, 7.5, 7.0 },
                BorderColor = "rgba(54, 162, 235, 1)",
                BackgroundColor = "rgba(54, 162, 235, 0.2)"
            },
            new RadarChartDataset
            {
                Label = "Employee C",
                Data = new[] { 9.0, 7.5, 8.0, 9.0, 8.5, 9.0, 8.0, 8.5 },
                BorderColor = "rgba(75, 192, 192, 1)",
                BackgroundColor = "rgba(75, 192, 192, 0.2)"
            },
            new RadarChartDataset
            {
                Label = "Employee D",
                Data = new[] { 6.0, 7.0, 7.0, 6.5, 7.5, 7.0, 7.5, 6.5 },
                BorderColor = "rgba(153, 102, 255, 1)",
                BackgroundColor = "rgba(153, 102, 255, 0.2)"
            },
            new RadarChartDataset
            {
                Label = "Employee E",
                Data = new[] { 7.5, 8.5, 8.0, 7.0, 8.0, 8.5, 8.0, 7.5 },
                BorderColor = "rgba(255, 206, 86, 1)",
                BackgroundColor = "rgba(255, 206, 86, 0.2)"
            }
        }
            };

            return View(model);
        }

        //HighChart (Packed Bubble Chart)
        public IActionResult SplitPackedBubbleChart()
        {
            var model = new List<PackedBubbleSeries>
    {
        new PackedBubbleSeries
        {
            Name = "Europe",
            Data = new List<PackedBubbleData>
            {
                new PackedBubbleData { Name = "Germany", Value = 673.6 },
                new PackedBubbleData { Name = "United Kingdom", Value = 340.6 },
                new PackedBubbleData { Name = "France", Value = 315.5 },
                new PackedBubbleData { Name = "Italy", Value = 322.9 },
                new PackedBubbleData { Name = "Poland", Value = 322.0 },
                new PackedBubbleData { Name = "Spain", Value = 254.4 },
                new PackedBubbleData { Name = "Turkey", Value = 481.2 },
                new PackedBubbleData { Name = "Russia", Value = 1909.0 },
                new PackedBubbleData { Name = "Ukraine", Value = 132.5 },
                new PackedBubbleData { Name = "Netherlands", Value = 134.7 }
            }
        },
        new PackedBubbleSeries
        {
            Name = "Africa",
            Data = new List<PackedBubbleData>
            {
                new PackedBubbleData { Name = "South Africa", Value = 405.0 },
                new PackedBubbleData { Name = "Nigeria", Value = 122.8 },
                new PackedBubbleData { Name = "Egypt", Value = 266.0 },
                new PackedBubbleData { Name = "Morocco", Value = 72.6 },
                new PackedBubbleData { Name = "Kenya", Value = 21.5 },
                new PackedBubbleData { Name = "Ethiopia", Value = 21.1 },
                new PackedBubbleData { Name = "Libya", Value = 62.7 },
                new PackedBubbleData { Name = "Angola", Value = 20.2 },
                new PackedBubbleData { Name = "Algeria", Value = 177.1 },
                new PackedBubbleData { Name = "Ghana", Value = 24.5 }
            }
        },
        new PackedBubbleSeries
        {
            Name = "Oceania",
            Data = new List<PackedBubbleData>
            {
                new PackedBubbleData { Name = "Australia", Value = 393.2 },
                new PackedBubbleData { Name = "New Zealand", Value = 32.4 },
                new PackedBubbleData { Name = "Papua New Guinea", Value = 4.7 },
                new PackedBubbleData { Name = "Fiji", Value = 1.8 },
                new PackedBubbleData { Name = "Samoa", Value = 0.5 }
            }
        },
        new PackedBubbleSeries
        {
            Name = "North America",
            Data = new List<PackedBubbleData>
            {
                new PackedBubbleData { Name = "United States", Value = 4853.8 },
                new PackedBubbleData { Name = "Canada", Value = 582.1 },
                new PackedBubbleData { Name = "Mexico", Value = 487.8 },
                new PackedBubbleData { Name = "Cuba", Value = 24.8 },
                new PackedBubbleData { Name = "Dominican Republic", Value = 23.5 },
                new PackedBubbleData { Name = "Panama", Value = 11.4 },
                new PackedBubbleData { Name = "Guatemala", Value = 20.1 },
                new PackedBubbleData { Name = "Honduras", Value = 10.6 },
                new PackedBubbleData { Name = "El Salvador", Value = 8.0 },
                new PackedBubbleData { Name = "Jamaica", Value = 6.1 }
            }
        },
        new PackedBubbleSeries
        {
            Name = "South America",
            Data = new List<PackedBubbleData>
            {
                new PackedBubbleData { Name = "Brazil", Value = 466.8 },
                new PackedBubbleData { Name = "Argentina", Value = 184.0 },
                new PackedBubbleData { Name = "Colombia", Value = 88.5 },
                new PackedBubbleData { Name = "Chile", Value = 92.9 },
                new PackedBubbleData { Name = "Peru", Value = 61.6 },
                new PackedBubbleData { Name = "Venezuela", Value = 96.9 },
                new PackedBubbleData { Name = "Ecuador", Value = 46.1 },
                new PackedBubbleData { Name = "Bolivia", Value = 22.0 },
                new PackedBubbleData { Name = "Paraguay", Value = 8.9 },
                new PackedBubbleData { Name = "Uruguay", Value = 8.5 }
            }
        },
        new PackedBubbleSeries
        {
            Name = "Asia",
            Data = new List<PackedBubbleData>
            {
                new PackedBubbleData { Name = "China", Value = 12667.4 },
                new PackedBubbleData { Name = "India", Value = 2693.0 },
                new PackedBubbleData { Name = "Japan", Value = 1082.6 },
                new PackedBubbleData { Name = "South Korea", Value = 635.5 },
                new PackedBubbleData { Name = "Indonesia", Value = 692.2 },
                new PackedBubbleData { Name = "Saudi Arabia", Value = 607.9 },
                new PackedBubbleData { Name = "Iran", Value = 686.4 },
                new PackedBubbleData { Name = "Vietnam", Value = 327.9 },
                new PackedBubbleData { Name = "Pakistan", Value = 199.3 },
                new PackedBubbleData { Name = "Thailand", Value = 282.4 }
            }
        }
    };

            return View(model);
        }

    }
}
