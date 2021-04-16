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
        List<Process> firstFitProcesses = new List<Process>();
        List<Process> bestFitProcesses = new List<Process>();
        List<Process> worstFitProcesses = new List<Process>();
        List<Process> firstFitProcessesWaiting = new List<Process>();
        List<Process> bestFitProcessesWaiting = new List<Process>();
        List<Process> worstFitProcessesWaiting = new List<Process>();
        int[] blockes = { 10, 5, 2, 4, 8 };
        int blockIndex = 0;
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
            if(blockIndex == 5)
            {
                blockIndex = 0;
            }
            //Allocate a process
            FirstFit(p);
            BestFit(p);
            WorstFit(p);
            blockIndex++;
            time++;
            label12.Text = time.ToString();

        }


        private void FirstFit(Process p)
        {   

            bool found = false;
            for (int j = 0; j < blockes.Length; j++)
            {
                int block = blockes[j];

                if (p.size <= block)
                {
                    blockes[j] = block - p.size;
                    lbFirstFit.Items.Add("Process: " + p.name + "  Size: " + p.size);
                    firstFitProcesses.Add(p);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("waiting");
                //firstFitProcessesWaiting.Add(p);
            }

            foreach (Process process in firstFitProcesses.ToList())
            {
                if (time - process.startTime >= process.size)
                {
                    lbFirstFit.Items.Remove("Process: " + process.name + "  Size: " + process.size);
                    firstFitProcesses.Remove(process);
                    blockes[blockIndex] += process.size;
                }
            }
        }

        private void BestFit(Process p)
        {
            bool found = false;
            Array.Sort(blockes);

            for (int j = 0; j < blockes.Length; j++) 
            {
                int block = blockes[j];

                if(p.size <= block) 
                {
                    blockes[j] = block - p.size;
                    lbBestFit.Items.Add("Process: " + p.name + " Size: " + p.size);
                    bestFitProcesses.Add(p);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("waiting");
            }

            foreach (Process process in bestFitProcesses.ToList())
            {
                if (time - process.startTime >= process.size)
                {
                    lbBestFit.Items.Remove("Process: " + process.name + "  Size: " + process.size);
                    bestFitProcesses.Remove(process);
                    blockes[blockIndex] += process.size;
                }
            }
        }

        private void WorstFit(Process p)
        {
            bool found = false;
            Array.Sort(blockes);
            Array.Reverse(blockes);

            for (int j = 0; j < blockes.Length; j++)
            {
                int block = blockes[j];

                if (p.size <= block)
                {
                    blockes[j] = block - p.size;
                    lbWorstFit.Items.Add("Process: " + p.name + " Size: " + p.size);
                    worstFitProcesses.Add(p);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("waiting");
            }

            foreach (Process process in bestFitProcesses.ToList())
            {
                if (time - process.startTime >= process.size)
                {
                    lbWorstFit.Items.Remove("Process: " + process.name + "  Size: " + process.size);
                    worstFitProcesses.Remove(process);
                    blockes[blockIndex] += process.size;
                }
            }
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
