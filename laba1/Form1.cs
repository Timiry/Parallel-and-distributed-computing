using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace laba1
{
    public partial class Form1 : Form
    {
        long k = 0;
        Thread Thread1;
        Thread Thread2;

        public Form1()
        {
            InitializeComponent();

            Thread1 = new Thread(funcThread1);
            Thread1.Start();
            Thread2 = new Thread(funcThread2);
            Thread2.Start();
        }

        void funcThread1()
        {
            for (long i = 0; i < 1000000000000000; i++) { k++; }
        }

        void funcThread2()
        {
            for (long i = 0; i < 10000; i++) { k--; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = k.ToString();
            updStates();
        }

        [Obsolete]
        private void Suspend1_Click(object sender, EventArgs e)
        {
            Thread1.Suspend();
            updStates();
        }

        [Obsolete]
        private void Resume1_Click(object sender, EventArgs e)
        {
            Thread1.Resume();
            updStates();
        }

        [Obsolete]
        private void Abort1_Click(object sender, EventArgs e)
        {
            Thread1.Abort();
            updStates();
        }

        [Obsolete]
        private void Suspend2_Click(object sender, EventArgs e)
        {
            Thread2.Suspend();
            updStates();
        }

        [Obsolete]
        private void Resume2_Click(object sender, EventArgs e)
        {
            Thread2.Resume();
            updStates();
        }

        [Obsolete]
        private void Abort2_Click(object sender, EventArgs e)
        {
            Thread2.Abort();
            updStates();
        }

        void updStates()
        {
            state1.Text = Thread1.ThreadState.ToString();
            state2.Text = Thread2.ThreadState.ToString();
        }
    }
}
