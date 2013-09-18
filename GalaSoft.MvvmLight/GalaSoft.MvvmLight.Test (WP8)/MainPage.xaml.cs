using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Phone.Controls;
using Microsoft.VisualStudio.TestPlatform.Core;
using Microsoft.VisualStudio.TestPlatform.TestExecutor;
using vstest_executionengine_platformbridge;

namespace GalaSoft.MvvmLight.Test__WP8_
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            var wrapper = new TestExecutorServiceWrapper();
            new Thread(new ServiceMain((param0, param1) => wrapper.SendMessage((ContractName)param0, param1)).Run).Start();

        }
    }
}
