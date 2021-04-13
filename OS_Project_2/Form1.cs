using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_Project_2
{
    public partial class Form1 : Form
    {
        Timer t = new Timer();
        Process[] processes = new Process[30];
        Process[] firstFitProcesses = new Process[30];
        Process[] bestFitProcesses = new Process[30];
        Process[] worstFitProcesses = new Process[30];
        int time = 0;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i <= 25; i++)
            {
                int processSize = rnd.Next(1, 11);

                processes[i] = new Process(processSize, i);
            }

            //timer interval
            t.Interval = 1000;  //in milliseconds

            t.Tick += new EventHandler(this.t_Tick);

            //start timer when form loads
            t.Start();  //this will use t_Tick() method

        }

        private void t_Tick(object sender, EventArgs e)
        {

            //Generate a process 
            Process p = processes[time];
            Process next = processes[time + 1];

            label8.Text = next.size.ToString();
            label9.Text = next.size.ToString();
            label10.Text = next.size.ToString();

            p.setStartTime(time);
            //Allocate a process
            FirstFit(p);
            BestFit(p);
            WorstFit(p);
            time++;
            label12.Text = time.ToString();

        }


        private void FirstFit(Process p)
        {
            lbFirstFit.Items.Add("Process: " + p.name + "  Size: " + p.size);
            firstFitProcesses[0] = p;
            
        }

        private void BestFit(Process p)
        {
            lbBestFit.Items.Add("Process: " + p.name + "  Size: " + p.size);
            bestFitProcesses.Append(p);

        }

        private void WorstFit(Process p)
        {
            lbWorstFit.Items.Add("Process: "+p.name + "  Size: " +p.size);
            worstFitProcesses.Append(p);

        }




    }

    public class Process
    {
        public readonly int size;
        public readonly int name;
        public int startTime;

        public Process(int size, int name)
        {
            this.size = size;
            this.name = name;
        }

        public void setStartTime(int x)
        {
            this.startTime = x;
        }
    }
}
