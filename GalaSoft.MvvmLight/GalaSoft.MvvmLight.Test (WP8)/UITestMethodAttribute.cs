using System;
using System.Threading.Tasks;
using System.Windows;

namespace Microsoft.VisualStudio.TestPlatform.UnitTestFramework
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class UITestMethodAttribute : TestMethodAttribute
    {
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            var task = ExecuteOnUi(testMethod);

            task.Wait();

            return task.Result;
        }

        private Task<TestResult[]> ExecuteOnUi(ITestMethod testMethod)
        {
            var tsc = new TaskCompletionSource<TestResult[]>();

            Deployment.Current.Dispatcher.BeginInvoke(() => tsc.SetResult(base.Execute(testMethod)));

            return tsc.Task;
        }
    }
}
