﻿using System;
using GalaSoft.MvvmLight.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test.Command
{
    [TestClass]
    public class RelayCommandGenericTest
    {
        private bool _canExecute = true;
        private WeakReference _reference;
        private TemporaryClass _tempoInstance;

        public RelayCommand<string> TestCommand
        {
            get;
            private set;
        }

        [TestMethod]
        public void CanExecuteChangedTest()
        {
            var command = new RelayCommand<string>(
                p =>
                {
                },
                p => true);

            var canExecuteChangedCalled = 0;

            var canExecuteChangedEventHandler = new EventHandler((s, e) => canExecuteChangedCalled++);

            command.CanExecuteChanged += canExecuteChangedEventHandler;

            command.RaiseCanExecuteChanged();

#if SILVERLIGHT
             Assert.AreEqual(1, canExecuteChangedCalled);
#else
            // In WPF, cannot trigger the CanExecuteChanged event like this
            Assert.AreEqual(0, canExecuteChangedCalled);
#endif

            command.CanExecuteChanged -= canExecuteChangedEventHandler;

            command.RaiseCanExecuteChanged();

#if SILVERLIGHT
             Assert.AreEqual(1, canExecuteChangedCalled);
#else
            // In WPF, cannot trigger the CanExecuteChanged event like this
            Assert.AreEqual(0, canExecuteChangedCalled);
#endif
        }

        [TestMethod]
        public void CanExecuteTest()
        {
            var command = new RelayCommand<string>(
                p =>
                {
                },
                p => p == "CanExecute");

            Assert.AreEqual(true, command.CanExecute("CanExecute"));
            Assert.AreEqual(false, command.CanExecute("Hello"));
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidCastException))]
        public void CanExecuteTestInvalidParameterType()
        {
            var command = new RelayCommand<string>(
                p =>
                {
                },
                p => p == "CanExecute");

            command.CanExecute(DateTime.Now);
        }

        [TestMethod]
        public void CanExecuteTestNull()
        {
            var command = new RelayCommand<string>(
                p =>
                {
                });

            Assert.AreEqual(true, command.CanExecute("Hello"));
        }

        [TestMethod]
        public void CanExecuteTestNullParameter()
        {
            var command = new RelayCommand<string>(
                p =>
                {
                },
                p => false);

            Assert.AreEqual(false, command.CanExecute(null));

            var command2 = new RelayCommand<string>(
                p =>
                {
                },
                p => true);

            Assert.AreEqual(true, command2.CanExecute(null));
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ConstructorTestInvalidExecuteNull1()
        {
            new RelayCommand<string>(null);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ConstructorTestInvalidExecuteNull2()
        {
            new RelayCommand<string>(null, null);
        }

        [TestMethod]
        public void TestExecute()
        {
            var dummy = "Not executed";
            const string executed = "Executed";
            const string parameter = "Parameter";

            var command = new RelayCommand<string>(
                p =>
                {
                    dummy = executed + p;
                });

            command.Execute(parameter);

            Assert.AreEqual(executed + parameter, dummy);
        }

        private static string _dummyStatic;
        
        [TestMethod]
        public void TestExecuteStatic()
        {
            _dummyStatic = "Not executed";
            const string executed = "Executed";
            const string parameter = "Parameter";

            var command = new RelayCommand<string>(
                p =>
                {
                    _dummyStatic = executed + p;
                });

            command.Execute(parameter);

            Assert.AreEqual(executed + parameter, _dummyStatic);
        }

        [TestMethod]
        public void TestCallingExecuteWhenCanExecuteIsFalse()
        {
            var result = string.Empty;
            const string value1 = "Hello";
            const string value2 = "World";

            var command = new RelayCommand<string>(
                s => result = s,
                s => _canExecute);

            command.Execute(value1);
            Assert.AreEqual(value1, result);
            _canExecute = false;
            command.Execute(value2);
            Assert.AreEqual(value1, result);
            _canExecute = true;
            command.Execute(value2);
            Assert.AreEqual(value2, result);
        }

        [TestMethod]
        public void TestReleasingTargetForCanExecuteGeneric()
        {
            _tempoInstance = new TemporaryClass();
            _reference = new WeakReference(_tempoInstance);

            TestCommand = new RelayCommand<string>(
                _tempoInstance.SetContent,
                _tempoInstance.CheckEnabled);

            Assert.IsTrue(_reference.IsAlive);

            _tempoInstance = null;
            GC.Collect();

#if NETFX_CORE
            Assert.IsTrue(_reference.IsAlive);
            TestCommand = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestReleasingTargetForCanExecuteGenericPrivate()
        {
            _tempoInstance = new TemporaryClass();
            _reference = new WeakReference(_tempoInstance);

            _tempoInstance.CreateCommandGenericCanExecutePrivate();

            Assert.IsTrue(_reference.IsAlive);

            _tempoInstance = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestReleasingTargetForCanExecuteGenericInternal()
        {
            _tempoInstance = new TemporaryClass();
            _reference = new WeakReference(_tempoInstance);

            _tempoInstance.CreateCommandGenericCanExecuteInternal();

            Assert.IsTrue(_reference.IsAlive);

            _tempoInstance = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestReleasingTargetForExecuteGeneric()
        {
            _tempoInstance = new TemporaryClass();
            _reference = new WeakReference(_tempoInstance);

            TestCommand = new RelayCommand<string>(
                _tempoInstance.SetContent);

            Assert.IsTrue(_reference.IsAlive);

            _tempoInstance = null;
            GC.Collect();

#if NETFX_CORE
            Assert.IsTrue(_reference.IsAlive);
            TestCommand = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestReleasingTargetForExecuteGenericPrivate()
        {
            _tempoInstance = new TemporaryClass();
            _reference = new WeakReference(_tempoInstance);

            _tempoInstance.CreateCommandGenericPrivate();

            Assert.IsTrue(_reference.IsAlive);

            _tempoInstance = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestReleasingTargetForExecuteGenericInternal()
        {
            _tempoInstance = new TemporaryClass();
            _reference = new WeakReference(_tempoInstance);

            _tempoInstance.CreateCommandGenericInternal();

            Assert.IsTrue(_reference.IsAlive);

            _tempoInstance = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestValueTypeCanExecute()
        {
            Reset();

            var command = new RelayCommand<int>(
                i => _methodWasExecuted = true,
                i => true);

            Assert.IsFalse(_methodWasExecuted);
            command.Execute(null);
            Assert.IsTrue(_methodWasExecuted);
        }

        [TestMethod]
#if NETFX_CORE
        [ExpectedException(typeof(InvalidCastException))] // TODO Try to find a way in Win8
#endif
        public void TestValueTypeConversion()
        {
            Reset();

            const int inputInt = 1234;
            const double inputDouble = 1234.5678;
            const bool inputBool = true;

            var resultInt = 0;
            var resultBool = false;
            var resultDouble = 0.0;

            var commandInt = new RelayCommand<int>(
                p =>
                {
                    resultInt = p;
                },
                p => true);

            var commandBool = new RelayCommand<bool>(
                p =>
                {
                    resultBool = p;
                },
                p => true);

            var commandDouble = new RelayCommand<double>(
                p =>
                {
                    resultDouble = p;
                },
                p => true);

            Assert.AreEqual(0, resultInt);
            Assert.AreEqual(false, resultBool);
            Assert.AreEqual(0.0, resultDouble);
            commandInt.Execute(inputInt.ToString());
            commandBool.Execute(inputBool.ToString());
            commandDouble.Execute(inputDouble.ToString());
            Assert.AreEqual(inputInt, resultInt);
            Assert.AreEqual(inputBool, resultBool);
            Assert.AreEqual(inputDouble, resultDouble);
        }

        private bool _methodWasExecuted;

        private void Reset()
        {
            _methodWasExecuted = false;
        }
    }
}