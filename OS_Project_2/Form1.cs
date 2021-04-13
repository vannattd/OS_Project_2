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

//Interface Process
// size, name, start
    public partial class Form1 : Form
    {
        Timer t = new Timer();
        int time = 0;
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

            //Generate a process 
      

            //Allocate a process
            FirstFit(Process p);
            BestFit(Process p);
            WorstFit(Process p);
            time++;
            label12.Text = time.ToString();

        }

       

       
        }
}
