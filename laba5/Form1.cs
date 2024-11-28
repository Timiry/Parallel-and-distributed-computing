using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace laba5
{
    public partial class Form1 : Form
    {
        private int PhilosopherCount;
        private Philosopher[] philosophers;
        private Thread[] threads;
        private object[] forks;
        private readonly Color thinkingColor = Color.LightBlue;
        private readonly Color eatingColor = Color.LightGreen;
        private readonly Color hungryColor = Color.LightCoral;
        private readonly Color forkColor = Color.Red;
        public Dictionary<PhilosopherState, string> StateDict = new Dictionary<PhilosopherState, string>
        {
            {PhilosopherState.Thinking,"Думает" },
            {PhilosopherState.Eating, "Ест" },
            {PhilosopherState.Hungry, "Голодает"}
        };

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            float centerX = this.ClientSize.Width / 2;
            float centerY = this.ClientSize.Height / 2;
            float radius = 200;
            float philosopherRadius = 30;

            for (int i = 0; i < PhilosopherCount; i++)
            {
                float angle = 2 * (float)Math.PI * i / PhilosopherCount;
                float x = centerX + radius * (float)Math.Cos(angle);
                float y = centerY + radius * (float)Math.Sin(angle);

                // Draw philosopher
                Color color = philosophers[i].CurrentState switch
                {
                    PhilosopherState.Thinking => thinkingColor,
                    PhilosopherState.Eating => eatingColor,
                    PhilosopherState.Hungry => hungryColor,
                    _ => Color.White
                };

                g.FillEllipse(new SolidBrush(color), x - philosopherRadius, y - philosopherRadius, philosopherRadius * 2, philosopherRadius * 2);
                g.DrawString($"Философ {i}: {StateDict[philosophers[i].CurrentState]}", this.Font, Brushes.Black, x - philosopherRadius, y + philosopherRadius + 5);

                // Draw fork between philosophers
                int nextPhilosopher = (i + 1) % PhilosopherCount;
                DrawFork(g, x, y, nextPhilosopher, radius);
            }
        }

        private void DrawFork(Graphics g, float x1, float y1, int nextPhilosopher, float radius)
        {
            float angle = 2 * (float)Math.PI * nextPhilosopher / PhilosopherCount;
            float x2 = this.ClientSize.Width / 2 + radius * (float)Math.Cos(angle);
            float y2 = this.ClientSize.Height / 2 + radius * (float)Math.Sin(angle);

            // Check if the fork is being used by either philosopher
            bool isUsed = philosophers[nextPhilosopher].UsingFork || philosophers[(nextPhilosopher - 1 + PhilosopherCount) % PhilosopherCount].UsingFork;

            // Adjust fork color based on usage
            Color forkDrawColor = isUsed ? Color.Red : Color.Gray;

            using (Brush brush = new SolidBrush(forkDrawColor))
            {
                float forkX = (x1 + x2) / 2 - 5; // Center the fork
                float forkY = (y1 + y2) / 2 - 15; // Center the fork
                g.FillRectangle(brush, forkX, forkY, 10, 30);
            }
        }

        public void UpdatePhilosopherState(int id, PhilosopherState state, bool usingFork)
        {
            philosophers[id].CurrentState = state;
            philosophers[id].UsingFork = usingFork;
            Invalidate(); // Trigger repaint
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (threads != null)
            {
                for (int i = 0; i < philosophers.Length; i++) 
                {
                    philosophers[i].active = false;
                }
                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i].Join();
                }
            }

            if (!int.TryParse(textBoxCount.Text, out PhilosopherCount))
            {
                MessageBox.Show("Некорректный ввод. Пожалуйста, введите целое число");
                return;
            }
 
            threads = new Thread[PhilosopherCount];
            philosophers = new Philosopher[PhilosopherCount];
            forks = new object[PhilosopherCount];

            for (int i = 0; i < PhilosopherCount; i++)
            {
                forks[i] = new object();
                philosophers[i] = new Philosopher(i, this, forks);
                philosophers[i].active = true;
                threads[i] = new Thread(philosophers[i].Start);
                threads[i].Start();
            }

            this.Paint += new PaintEventHandler(Form1_Paint);
        }
    }

    public enum PhilosopherState
    {
        Thinking,
        Eating,
        Hungry
    }

    public class Philosopher
    {
        private int id;
        private Form1 form;
        private static readonly Random random = new Random();
        public PhilosopherState CurrentState { get; set; }
        public bool UsingFork { get; set; }
        public bool active { get; set; }

        private readonly object[] forks;

        public Philosopher(int id, Form1 form, object[] forks)
        {
            this.id = id;
            this.form = form;
            this.forks = forks;
            CurrentState = PhilosopherState.Thinking;
        }

        public void Start()
        {
            while (this.active)
            {
                Eat();
                Think();
            }
        }

        private void Think()
        {
            if (!this.active) return;
            form.UpdatePhilosopherState(id, PhilosopherState.Thinking, false);
            Thread.Sleep(random.Next(3000, 4000));
        }

        private void Eat()
        {
            if (!this.active) return;
            int leftFork = id;
            int rightFork = (id + 1) % forks.Length;

            form.UpdatePhilosopherState(id, PhilosopherState.Hungry, false);
            // Сначала берём левую вилку
            lock (forks[leftFork])
            {
                // Теперь берём правую вилку
                lock (forks[rightFork])
                {
                    UsingFork = true;
                    form.UpdatePhilosopherState(id, PhilosopherState.Eating, true);
                    Thread.Sleep(random.Next(2000, 4000));
                    UsingFork = false;
                }
            }
            
        }
    }
}
