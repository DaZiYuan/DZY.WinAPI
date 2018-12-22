﻿using DZY.WinAPI;
using DZY.WinAPI.Desktop.API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(2000);
            var cp = Process.GetCurrentProcess();
            var result = new DZY.WinAPI.Helpers.OtherProgramChecker(cp).CheckMaximized();
            MessageBox.Show(result.ToString());
        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            var test0 = System.Windows.Forms.Screen.AllScreens;
            var test = User32Wrapper.GetDisplays();
            var test2 = User32Wrapper.Display();

            var desktopFactory = DesktopWallpaperFactory.Create();
            desktopFactory.GetSlideshowOptions(out DesktopSlideshowOptions options, out uint slide);
            desktopFactory.SetSlideshowOptions(DesktopSlideshowOptions.DSO_SHUFFLEIMAGES, 1000 * 60);
            desktopFactory.SetSlideshowOptions(DesktopSlideshowOptions.DSO_SHUFFLEIMAGES, 1000 * 60 * 60 * 24);
            desktopFactory.GetSlideshowOptions(out DesktopSlideshowOptions option1s, out uint sli1de);

        }
    }
}
