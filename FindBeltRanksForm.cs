﻿using Karate.Properties;
using Karate_BusinessLayer;
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
    public partial class FindBeltRanksForm : Form
    {
        public FindBeltRanksForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            PictreForFIndOrNot.Visible = false;
            LabelForFIndOrNot.Visible = false;
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


        clsBeltRanks _Belt;

        void FillBeltDataToForm(clsBeltRanks Belt)
        {
            TxtBektUD.Text = Belt.BeltID.ToString();
            TxtBeltName.Text = Belt.BeltName;
            TxtTestFees.Text = Belt.TestsFees.ToString();

            if (Belt.BeltID == 1)
            {
                PictrueForBelt.Image = Resources.karate__7_;
                return;
            }
            if (Belt.BeltID == 2)
            {
                PictrueForBelt.Image = Resources.karate__8_; return;
            }
            if (Belt.BeltID == 3)
            {
                PictrueForBelt.Image = Resources.karate__7_1; return;
            }
            if (Belt.BeltID == 4)
            {
                PictrueForBelt.Image = Resources.karate__10_; return;
            }
            if (Belt.BeltID == 5)
            {
                PictrueForBelt.Image = Resources.karate__11_; return;
            }
            if (Belt.BeltID == 6)
            {
                PictrueForBelt.Image = Resources.karate__12_; return;
            }
            if (Belt.BeltID == 7)
            {
                PictrueForBelt.Image = Resources.karate__13_; return;
            }
            else
            {
                PictrueForBelt.Image = Resources.karate__15_; return;
            }
        }

           
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (TxtBeltIDSearch.Text == string.Empty)
            {
                Form New = new FormForWrongNotExist("Plese Enter ID To Search");
                New.ShowDialog();
                return;
            }

            clsBeltRanks Belt = clsBeltRanks.Find(Convert.ToInt32(TxtBeltIDSearch.Text));

            if (Belt != null)
            {
                FillBeltDataToForm(Belt);
                _Belt = Belt;
                PictreForFIndOrNot.Visible = true;
                LabelForFIndOrNot.Visible = true;
                PictreForFIndOrNot.Image=Resources.check;
                LabelForFIndOrNot.Text = $"Belt With ID {Belt.BeltID} Found.";
                LabelForFIndOrNot.ForeColor= Color.Green;
            }
            else
            {
                PictrueForBelt.Image = Resources.question__1_;
                PictreForFIndOrNot.Visible = true;
                LabelForFIndOrNot.Visible = true;
                PictreForFIndOrNot.Image = Resources.cross;
                LabelForFIndOrNot.Text = $"Belt With ID {TxtBeltIDSearch.Text} Not Exist.";
                LabelForFIndOrNot.ForeColor = Color.Red;
                TxtBektUD.Text = "-1";
                TxtBeltName.Text=string.Empty;
                TxtTestFees.Text = string.Empty;             
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            TxtBektUD.Text = "-1";
            TxtBeltName.Text = string.Empty;
            TxtTestFees.Text = string.Empty;
            PictreForFIndOrNot.Visible=false;
            LabelForFIndOrNot.Visible= false;
            PictrueForBelt.Image= Resources.question__1_;
            TxtBeltIDSearch.Text = string.Empty;

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}