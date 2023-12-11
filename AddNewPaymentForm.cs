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
    public partial class AddNewPaymentForm : Form
    {
        public AddNewPaymentForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            _FillNamesForMembers();
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

        void _FillNamesForMembers()
        {
            DataTable dt1 = clsMemberInstructor.GitAllMemberNames();
            foreach (DataRow Row in dt1.Rows)
            {
                ComboBoxMembersNames.Items.Add(Row[0].ToString());
            }
        }


        private void btnSaveForADD_Click(object sender, EventArgs e)
        {
            clsMembers Member = clsMembers.Find(ComboBoxMembersNames.SelectedItem.ToString());


            if(clsPayments.AddNewPayment(Member.MemberID,DateForPayment.Value,Convert.ToInt64( NumberOfAmountPaid.Value))!=0)
            {
                Form New = new FormForRithThing("The Payment Added");
                New.ShowDialog();            
            }
            else
            {
                Form New = new FormForWrongNotExist("The Payment Does Not Added");
                New.ShowDialog();

            }

            this.Close();
            return;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
