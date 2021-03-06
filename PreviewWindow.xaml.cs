﻿using System;
using System.Windows;

namespace SvgoAutoExe
{

    /// <summary>
    /// PreviewWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class PreviewWindow : Window
    {
        private readonly MainWindow mainWindow;

        public PreviewWindow(MainWindow mw)
        {
            mainWindow = mw;
            InitializeComponent();
        }

        public void PreviewRefresh()
        {
            Dispatcher.Invoke(() =>
            {
                Browser.Navigate(new Uri(mainWindow.TextBoxDstFile.Text));
            });
        }

        /// <summary>
        /// 閉じるボタン押下時
        /// </summary>
        private void PreviewWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true; // インスタンスを残したままにしたいのでキャンセル
            Hide();
            mainWindow.ButtonPreview.IsChecked = false;
        }

        /// <summary>
        /// 最前面に固定
        /// </summary>
        private void ButtonShowTopChecked(object sender, RoutedEventArgs e)
        {
            Topmost = true;
        }

        /// <summary>
        /// 最前面の固定を解除
        /// </summary>
        private void ButtonShowTopUnChecked(object sender, RoutedEventArgs e)
        {
            Topmost = false;
        }
    }
}
