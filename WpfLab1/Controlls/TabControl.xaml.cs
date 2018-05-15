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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfLab1.Controlls
{
    /// <summary>
    /// Interaction logic for TabControl.xaml
    /// </summary>
    public partial class TabControl : UserControl
    {
        public TabControl()
        {
            InitializeComponent();
            RecieveSelected = true;
            //RecTab.MouseLeftButtonDown+=(s,e)=> RecieveSelected = true;
            //SenTab.MouseLeftButtonDown += (s, e) => RecieveSelected = false;
            Tabctrl.MouseMove += (s, e) => RecieveSelected = RecTab.IsSelected;
        }
        public bool RecieveSelected { get; set; }

        //private void RecieveTrue(object sender, MouseButtonEventArgs e)
        //{
        //    RecieveSelected = true;
        //}
        //private void RecieveFalse(object sender, MouseButtonEventArgs e)
        //{
        //    RecieveSelected = false;
        //}
    }
}
