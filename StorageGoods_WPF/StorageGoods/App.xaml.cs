using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace StorageGoods
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const int SplTime = 4000;

        protected override void OnStartup(StartupEventArgs e)
        {
            SplashScreen spalsh = new SplashScreen();
            spalsh.Show();
            Stopwatch timer = new Stopwatch();
            timer.Start();
            base.OnStartup(e);
            MainWindow main = new MainWindow();
            timer.Stop();
            int remainTime = SplTime - (int) timer.ElapsedMilliseconds;
            if (remainTime > 0)
            {
                Thread.Sleep(remainTime);
            }
            spalsh.Close();
        }
    }
}
