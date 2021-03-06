﻿using System;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Test.ViewModel;

#if NETFX_CORE || WINDOWS_PHONE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace GalaSoft.MvvmLight.Test
{
    [TestClass]
    public class ObservableObjectPropertyChangedTest
    {
        [TestMethod]
        public void TestPropertyChangedNoBroadcast()
        {
            var receivedDateTimeLocal = DateTime.MinValue;

            var vm = new TestClassWithObservableObject();
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == TestClassWithObservableObject.LastChangedPropertyName)
                {
                    receivedDateTimeLocal = vm.LastChanged;
                }
            };

            var now = DateTime.Now;
            vm.LastChanged = now;
            Assert.AreEqual(now, vm.LastChanged);
            Assert.AreEqual(now, receivedDateTimeLocal);
        }

#if !SL3
        [TestMethod]
        public void TestPropertyChangedNoMagicString()
        {
            var receivedDateTimeLocal = DateTime.MinValue;

            var vm = new TestClassWithObservableObject();
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "LastChangedNoMagicString")
                {
                    receivedDateTimeLocal = vm.LastChangedNoMagicString;
                }
            };

            var now = DateTime.Now;
            vm.LastChangedNoMagicString = now;
            Assert.AreEqual(now, vm.LastChangedNoMagicString);
            Assert.AreEqual(now, receivedDateTimeLocal);
        }
#endif

        [TestMethod]
        public void TestRaisePropertyChangedValidInvalidPropertyName()
        {
            var vm = new TestClassWithObservableObject();

            var receivedPropertyChanged = false;
            var invalidPropertyNameReceived = false;
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == TestClassWithObservableObject.LastChangedPropertyName)
                {
                    receivedPropertyChanged = true;
                }
                else
                {
                    invalidPropertyNameReceived = true;
                }
            };

            vm.RaisePropertyChangedPublic(TestClassWithObservableObject.LastChangedPropertyName);

            Assert.IsTrue(receivedPropertyChanged);
            Assert.IsFalse(invalidPropertyNameReceived);

            try
            {
                vm.RaisePropertyChangedPublic(TestClassWithObservableObject.LastChangedPropertyName + "1");

#if DEBUG
                Assert.Fail("ArgumentException was expected");
#else
                Assert.IsTrue(invalidPropertyNameReceived);
#endif
            }
            catch (ArgumentException)
            {
            }
        }

#if !SL3
        [TestMethod]
        public void TestSet()
        {
            var vm = new TestClassWithObservableObject();
            const int expectedValue = 1234;
            var receivedValueChanged = 0;
            var receivedValueChanging = 0;

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == TestClassWithObservableObject.PropertyWithSetPropertyName)
                {
                    receivedValueChanged = vm.PropertyWithSet;
                }
            };
#if !PORTABLE
            vm.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName == TestClassWithObservableObject.PropertyWithSetPropertyName)
                {
                    receivedValueChanging = vm.PropertyWithSet;
                }
            };
#else
            receivedValueChanging = -1;
#endif

            vm.PropertyWithSet = expectedValue;
            Assert.AreEqual(expectedValue, receivedValueChanged);
            Assert.AreEqual(-1, receivedValueChanging);
        }

        [TestMethod]
        public void TestSetWithString()
        {
            var vm = new TestClassWithObservableObject();
            const int expectedValue = 1234;
            var receivedValueChanged = 0;
            var receivedValueChanging = 0;

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == TestClassWithObservableObject.PropertyWithStringSetPropertyName)
                {
                    receivedValueChanged = vm.PropertyWithStringSet;
                }
            };

#if !PORTABLE
            vm.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName == TestClassWithObservableObject.PropertyWithStringSetPropertyName)
                {
                    receivedValueChanging = vm.PropertyWithStringSet;
                }
            };
#else
            receivedValueChanging = -1;
#endif

            vm.PropertyWithStringSet = expectedValue;
            Assert.AreEqual(expectedValue, receivedValueChanged);
            Assert.AreEqual(-1, receivedValueChanging);
        }

        [TestMethod]
        public void TestReturnValueWithSet()
        {
            var vm = new TestClassWithObservableObject();
            const int firstValue = 1234;
            var receivedValueChanged = 0;
            var receivedValueChanging = 0;

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == TestClassWithObservableObject.PropertyWithSetPropertyName)
                {
                    receivedValueChanged = vm.PropertyWithSet;
                }
            };

#if !PORTABLE
            vm.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName == TestClassWithObservableObject.PropertyWithSetPropertyName)
                {
                    receivedValueChanging = vm.PropertyWithSet;
                }
            };
#endif

            vm.PropertyWithSet = firstValue;
#if !PORTABLE
            Assert.AreEqual(-1, receivedValueChanging);
#endif
            Assert.AreEqual(firstValue, receivedValueChanged);
            Assert.IsTrue(vm.SetRaisedPropertyChangedEvent);

            vm.PropertyWithSet = firstValue;
#if !PORTABLE
            Assert.AreEqual(-1, receivedValueChanging);
#endif
            Assert.AreEqual(firstValue, receivedValueChanged);
            Assert.IsFalse(vm.SetRaisedPropertyChangedEvent);

            vm.PropertyWithSet = firstValue + 1;
#if !PORTABLE
            Assert.AreEqual(firstValue, receivedValueChanging);
#endif
            Assert.AreEqual(firstValue + 1, receivedValueChanged);
            Assert.IsTrue(vm.SetRaisedPropertyChangedEvent);
        }

        [TestMethod]
        public void TestReturnValueWithSetWithString()
        {
            var vm = new TestClassWithObservableObject();
            const int firstValue = 1234;
            var receivedValueChanged = 0;
            var receivedValueChanging = 0;

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == TestClassWithObservableObject.PropertyWithStringSetPropertyName)
                {
                    receivedValueChanged = vm.PropertyWithStringSet;
                }
            };

#if !PORTABLE
            vm.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName == TestClassWithObservableObject.PropertyWithStringSetPropertyName)
                {
                    receivedValueChanging = vm.PropertyWithStringSet;
                }
            };
#endif


            vm.PropertyWithStringSet = firstValue;
#if !PORTABLE
            Assert.AreEqual(-1, receivedValueChanging);
#endif
            Assert.AreEqual(firstValue, receivedValueChanged);
            Assert.IsTrue(vm.SetRaisedPropertyChangedEvent);

            vm.PropertyWithStringSet = firstValue;
#if !PORTABLE
            Assert.AreEqual(-1, receivedValueChanging);
#endif
            Assert.AreEqual(firstValue, receivedValueChanged);
            Assert.IsFalse(vm.SetRaisedPropertyChangedEvent);

            vm.PropertyWithStringSet = firstValue + 1;
#if !PORTABLE
            Assert.AreEqual(firstValue, receivedValueChanging);
#endif
            Assert.AreEqual(firstValue + 1, receivedValueChanged);
            Assert.IsTrue(vm.SetRaisedPropertyChangedEvent);
        }
#endif

#if CMNATTR
        [TestMethod]
        public void TestCallerMemberName()
        {
            var instance = new TestViewModel();

            const string value1 = "1234";
            const string value2 = "5678";

            instance.TestPropertyWithCallerMemberName = value1;

            var changedWasRaised = false;

            instance.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName != TestViewModel.TestPropertyWithCallerMemberNamePropertyName)
                {
                    return;
                }

                var sender = (TestViewModel)s;
                Assert.AreSame(instance, sender);

                Assert.AreEqual(value2, instance.TestPropertyWithCallerMemberName);
                changedWasRaised = true;
            };

            instance.TestPropertyWithCallerMemberName = value2;
            Assert.IsTrue(changedWasRaised);
        }
        [TestMethod]
        public void TestCallerMemberNameWithSet()
        {
            var instance = new TestViewModel();

            const string value1 = "1234";
            const string value2 = "5678";

            instance.TestPropertyWithCallerMemberNameAndSet = value1;

            var changedWasRaised = false;

            instance.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName != TestViewModel.TestPropertyWithCallerMemberNameAndSetPropertyName)
                {
                    return;
                }

                var sender = (TestViewModel)s;
                Assert.AreSame(instance, sender);

                Assert.AreEqual(value2, instance.TestPropertyWithCallerMemberNameAndSet);
                changedWasRaised = true;
            };

            instance.TestPropertyWithCallerMemberNameAndSet = value2;
            Assert.IsTrue(changedWasRaised);
        }

#endif
    }
}
