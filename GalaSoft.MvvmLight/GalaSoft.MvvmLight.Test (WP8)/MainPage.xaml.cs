using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Testing;

namespace GalaSoft.MvvmLight.Test__WP8_
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Content = UnitTestSystem.CreateTestPage();
        }
    }
}
            InitializeComponent();
            Loaded += MainPageLoaded;
        }

        void MainPageLoaded(object sender, RoutedEventArgs e)
        {
            SystemTray.IsVisible = false;

         //   var testPage = (IMobileTestPage)UnitTestSystem.CreateTestPage();
            var testPage = UnitTestSystem.CreateTestPage();
         //   BackKeyPress += (x, xe) => xe.Cancel = testPage.NavigateBack();
            ((PhoneApplicationFrame)Application.Current.RootVisual).Content = testPage;
        }
    }
}