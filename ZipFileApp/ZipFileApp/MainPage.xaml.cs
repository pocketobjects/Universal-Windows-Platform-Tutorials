﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ZipFileApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        Library library = new Library();

        private async void New_Click(object sender, RoutedEventArgs e)
        {
            if (await library.NewAsync())
            {
                Label.Text = library.Name;
            }
        }

        private async void Open_Click(object sender, RoutedEventArgs e)
        {
            Display.ItemsSource = await library.OpenAsync();
            Label.Text = library.Name;
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            Display.ItemsSource = await library.AddAsync();
        }

        private void Extract_Click(object sender, RoutedEventArgs e)
        {
            ZipItem item = (ZipItem)((AppBarButton)sender).Tag;
            library.Extract(item);
        }

        private async void Remove_Click(object sender, RoutedEventArgs e)
        {
            ZipItem item = (ZipItem)((AppBarButton)sender).Tag;
            Display.ItemsSource = await library.RemoveAsync(item);
        }

    }
}
