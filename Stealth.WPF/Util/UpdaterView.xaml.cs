﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Stealth.WPF.Util
{
    /// <summary>
    /// Interaction logic for UpdaterView.xaml
    /// </summary>
    public partial class UpdaterView : Window
    {
        public UpdaterView()
        {
            InitializeComponent();

            UpdaterViewModel uvm = new UpdaterViewModel();
            //uvm.close = new DelegateCommand() { ExecuteCommand = new Action<object>((o) => this.Close()) };

            this.DataContext = new UpdaterViewModel();

        }
    }
}
