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


    public class Process
    {
        private readonly int size;
        private readonly int name;
        private readonly int startTime;

        public Process(int size, int name, int startTime)
        {
            this.size = size;
            this.name = name;
            this.startTime = startTime;
        }
    }
//Interface Process
// size, name, start
    public partial class Form1 : Form
    {
        Timer t = new Timer();
        int time = 0;
        int processNum = 1;
        public Form1()
        {
            InitializeComponent();

            //timer interval
            t.Interval = 1000;  //in milliseconds

            t.Tick += new EventHandler(this.t_Tick);

            //start timer when form loads
            t.Start();  //this will use t_Tick() method

        }

        private void t_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int processSize = rnd.Next(1, 11);

            Process p = new Process(processSize, processNum, time);
            //Generate a process 


            //Allocate a process
            FirstFit(p);
            BestFit(p);
            WorstFit(p);
            time++;
            processNum++;
            label12.Text = time.ToString();

        }


        private void FirstFit(Process p)
        {

        }

        private void BestFit(Process p)
        {

        }

        private void WorstFit(Process p)
        {

        }




    }
}
