using System.Diagnostics;
using OxyPlot;
using OxyPlot.Series;

namespace laba3_grafs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int process = Environment.ProcessorCount;

        List<double> x = new List<double>();
        List<double> y1 = new List<double>();
        List<double> y2 = new List<double>();

        List<double> z1 = new List<double>();
        List<double> z2 = new List<double>();
        List<double> z3 = new List<double>();

        void prepareData()
        {
            x.Clear();
            y1.Clear();
            y2.Clear();

            for (long i = 10000; i <= 1000000000; i *= 10)
            {
                x.Add(i);

                z1.Add((double)singleStreamTime(i));
                z2.Add((double)parallelTime(i));
                z3.Add((double)multiStreamsTime(i, process));

                int j = x.Count-1;
                y1.Add(z1[j] / z2[j]);
                y2.Add(z1[j] / z3[j]);
            }
        }

        long multiStreamsTime(long number, int process)
        {
            long sum = 0;
            long partSize = (long)(number / process);
            Limits[] arrLimits = new Limits[process];
            Thread[] arrThreads = new Thread[process];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < process; i++)
            {
                long partStart = i * partSize + 1;
                long partEnd = (i + 1) * partSize;
                if (i == process - 1) partEnd = number;

                Limits limits = new Limits(partStart, partEnd);
                arrLimits[i] = limits;

                Thread thread = new Thread(new ParameterizedThreadStart(Count));
                arrThreads[i] = thread;
                thread.Start(limits);
            }

            foreach (Thread thread in arrThreads) thread.Join();
            foreach (Limits limits in arrLimits) sum += limits.sum;

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        long parallelTime(long number)
        {
            long sum = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Parallel.For(0, number + 1, (i) => { Interlocked.Add(ref sum, i); });

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        long singleStreamTime(long number)
        {
            long sum = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (long i = 0; i < number + 1; i++) sum += i;

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static void Count(Object arg)
        {
            if (arg is Limits limits)
            {
                for (long i = limits.a; i <= limits.b; i++) limits.sum += i;
            }
        }

        public class Limits
        {
            public long a;
            public long b;
            public long sum = 0;
            public Limits(long a, long b)
            {
                this.a = a;
                this.b = b;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prepareData();
            DrawGraph(x.ToArray(), y1.ToArray(), y2.ToArray());
        }



        private void DrawGraph(double[] x, double[] y1, double[] y2)
        {

            // Создание модели графика
            var plotModel = new PlotModel { Title = "Эффективность многопоточности" };

            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                Title = "Число" // Переименование оси X
            });

            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                Title = "Время 1 поток / время много потоков" // Переименование оси Y
            });

            // Первая кривая
            var series1 = new LineSeries
            {
                Title = "Parallel.For",
                MarkerType = MarkerType.Circle,
                ItemsSource = CreatePoints(x, y1)
            };
            plotModel.Series.Add(series1);

            // Вторая кривая
            var series2 = new LineSeries
            {
                Title = "Многопоточность",
                MarkerType = MarkerType.Circle,
                ItemsSource = CreatePoints(x, y2)
            };
            plotModel.Series.Add(series2);

            // Установка модели графика в элемент управления
            var plotView = new OxyPlot.WindowsForms.PlotView
            {
                Dock = DockStyle.Fill,
                Model = plotModel
            };

            // Добавление элемента управления на форму
            this.Controls.Add(plotView);
        }

        private static OxyPlot.DataPoint[] CreatePoints(double[] xValues, double[] yValues)
        {
            OxyPlot.DataPoint[] points = new OxyPlot.DataPoint[xValues.Length];
            for (int i = 0; i < xValues.Length; i++)
            {
                points[i] = new OxyPlot.DataPoint(xValues[i], yValues[i]);
            }
            return points;
        }
    }
}
