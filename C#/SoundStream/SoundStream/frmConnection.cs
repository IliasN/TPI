﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundStream
{
    public partial class frmConnection : Form
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Methods

        #region Constructor
        public frmConnection()
        {
            InitializeComponent();
        }
        #endregion

        private void llblSwitch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbxConfPass.Visible = !tbxConfPass.Visible;
            lblConfirmPass.Visible = !lblConfirmPass.Visible;
        }

        #endregion
    }
}
