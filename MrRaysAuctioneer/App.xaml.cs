using MrRaysAuctioneer.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace MrRaysAuctioneer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            LogHelper.Error(e.Exception);
            MessageBox.Show("Mist mit dem Fehler habe ich nicht gerechnet :( " + Environment.NewLine + e.Exception.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //TODO add Language to UserSettings
            //LanguageHelper.ChangCurrentLanguage(new CultureInfo("en-US"));  

        }
        
    }
}
