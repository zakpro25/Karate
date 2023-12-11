﻿using Karate_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate
{
    public partial class ListTestsForm : Form
    {
        public ListTestsForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);  
        }
        



        private const int cGrip = 16;
        private const int cCaption = 32;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                }
            }
            base.WndProc(ref m);
        }





        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListTestsForm_Load(object sender, EventArgs e)
        {
         

            DataGridViewForAllTests.DataSource = clsTests.GitAllTests();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsTests.DeleteTest((int)DataGridViewForAllTests.CurrentRow.Cells[0].Value)!=0)
            {
                return;
            }
        }
    }
}
