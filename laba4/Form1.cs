using System.Diagnostics;

namespace laba4
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private Bitmap resultImage;
        int width;
        private readonly object lockObject = new object();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    originalImage = new Bitmap(openFileDialog.FileName);
                    width = originalImage.Width;
                    resultImage = new Bitmap(originalImage);
                    pictureBoxOriginal.Image = originalImage;
                }
            }
        }

        private void btnIncreaseBrightness_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            int brightnessAdjustment = trackBar1.Value; // Получаем значение из TrackBar
            int numThreads = Environment.ProcessorCount;
            int heightPerThread = originalImage.Height / numThreads;
            Task<Bitmap>[] tasks = new Task<Bitmap>[numThreads];
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < numThreads; i++)
            {
                int startY = i * heightPerThread;
                int endY = (i == numThreads - 1) ? originalImage.Height : startY + heightPerThread;
                Bitmap copy = new Bitmap(originalImage);
                tasks[i] = Task.Run(() => ProcessPixels(startY, endY, copy, brightnessAdjustment));
            }

            Task.WhenAll(tasks).ContinueWith(t =>
            {
                // Собираем итоговое изображение из обработанных Bitmap
                for (int i = 0; i < tasks.Length; i++)
                {
                    Bitmap groupBitmap = tasks[i].Result;
                    for (int y = 0; y < groupBitmap.Height; y++)
                    {
                        for (int x = 0; x < groupBitmap.Width; x++)
                        {
                            resultImage.SetPixel(x, y + (i * heightPerThread), groupBitmap.GetPixel(x, y));
                        }
                    }
                }

                pictureBoxResult.Image = resultImage;
            });
            labelProcCount.Text = Environment.ProcessorCount.ToString();
            labelImgSize.Text = $"{originalImage.Width} X {originalImage.Height}";
            labelWorkTime.Text = sw.ElapsedMilliseconds.ToString();
        }

        private Bitmap ProcessPixels(int startY, int endY, Bitmap copy, int brightnessAdjustment)
        {
            Bitmap groupBitmap = new Bitmap(width, endY - startY);
            for (int y = startY; y < endY; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor = copy.GetPixel(x, y);
                    int r = Math.Clamp(pixelColor.R + brightnessAdjustment, 0, 255);
                    int g = Math.Clamp(pixelColor.G + brightnessAdjustment, 0, 255);
                    int b = Math.Clamp(pixelColor.B + brightnessAdjustment, 0, 255);
                    Color newColor = Color.FromArgb(r, g, b);
                    groupBitmap.SetPixel(x, y - startY, newColor); // Записываем в локальный Bitmap
                }
            }
            return groupBitmap;
        }

        private void btnIncreaseBrightnessSingle_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;
            int brightnessAdjustment = trackBar1.Value; // Получаем значение из TrackBar

            Stopwatch sw = Stopwatch.StartNew();

            IncreaseBrightness(brightnessAdjustment);

            sw.Stop();

            pictureBoxResult.Image = resultImage;
            labelProcCount.Text = Environment.ProcessorCount.ToString();
            labelImgSize.Text = $"{originalImage.Width} X {originalImage.Height}";
            labelWorkTime.Text = sw.ElapsedMilliseconds.ToString();
        }

        private void IncreaseBrightness(int brightnessAdjustment)
        {
            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);
                    int r = Math.Clamp(pixelColor.R + brightnessAdjustment, 0, 255);
                    int g = Math.Clamp(pixelColor.G + brightnessAdjustment, 0, 255);
                    int b = Math.Clamp(pixelColor.B + brightnessAdjustment, 0, 255);
                    Color newColor = Color.FromArgb(r, g, b);
                    resultImage.SetPixel(x, y, newColor);
                }
            }
        }
    }
}
