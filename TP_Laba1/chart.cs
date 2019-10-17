using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace TP_Laba1
{
    public partial class chart : Form
    {
        private ArrayList myAL;

        public chart(ArrayList _myAL)
        {
            InitializeComponent();
            this.myAL = _myAL;

            

          for(int i=0; i < myAL.Count; i++)
            {
                
                chart1.Series.Add((i).ToString());
                chart1.Series[i].AxisLabel = (i+1).ToString();
                chart1.Series[i].Points.AddXY(i.ToString(), myAL[i]);
                chart1.Series[i].IsXValueIndexed = true;

            }

          // chart1.AlignDataPointsByAxisLabel();
        }
    }
}
