using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Wpf_Karaokay.Model;

namespace Wpf_Karaokay.ViewModel
{

    //define the class for navigation 
    

    public interface INavigationService
    {
        void RegisterWindow(string windowKey, Type windowType, object viewModel);
        void RegisterPage(string pageKey, Type pageType, object viewModel);
        void NavigateToWindow(string windowKey);
        void NavigateToPage(string pageKey);
        void GoBack();
    }

    public class NavigationService : INavigationService
    {
        private Dictionary<string, (Type windowType, object viewModel)> _windows;
        private Dictionary<string, (Type pageType, object viewModel)> _pages;
        private Stack<Window> _windowStack;

        public NavigationService()
        {
            _windows = new Dictionary<string, (Type windowType, object viewModel)>();
            _pages = new Dictionary<string, (Type pageType, object viewModel)>();
            _windowStack = new Stack<Window>();
        }

        public void RegisterWindow(string windowKey, Type windowType, object viewModel)
        {
            if (!_windows.ContainsKey(windowKey))
                _windows.Add(windowKey, (windowType, viewModel));
        }

        public void RegisterPage(string pageKey, Type pageType, object viewModel)
        {
            if (!_pages.ContainsKey(pageKey))
                _pages.Add(pageKey, (pageType, viewModel));
        }

        public void NavigateToWindow(string windowKey)
        {
            if (_windows.TryGetValue(windowKey, out (Type windowType, object viewModel) windowInfo))
            {
                ClosePreviousWindow();

                Window window = Activator.CreateInstance(windowInfo.windowType) as Window;
                window.DataContext = windowInfo.viewModel;
                _windowStack.Push(window);
                window.Show();
            }
        }

        public void NavigateToPage(string pageKey)
        {
            if (_pages.TryGetValue(pageKey, out (Type pageType, object viewModel) pageInfo))
            {
                
                
                Window currentWindow = GetCurrentWindow();
                currentWindow.Content = Activator.CreateInstance(pageInfo.pageType);
                (currentWindow.Content as FrameworkElement).DataContext = pageInfo.viewModel;
                
            }
        }

        public void GoBack()
        {
            if (_windowStack.Count > 1)
            {
                _windowStack.Pop().Close();
                Window previousWindow = _windowStack.Peek();
                previousWindow.Show();
            }
        }

        private void ClosePreviousWindow()
        {
            if (_windowStack.Count > 0)
            {
                Window previousWindow = _windowStack.Pop();
                previousWindow.Close();
            }
        }

        private Window GetCurrentWindow()
        {
            return _windowStack.Peek();
        }
    }

    //Define the class for the Timer 

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected static NavigationService NavigationService { get; } = new NavigationService();


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

   
   
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> execute;
        private readonly Func<T, bool> canExecute;

        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (parameter is T typedParameter)
            {
                return canExecute == null || canExecute(typedParameter);
            }

            return canExecute == null || canExecute(default(T));
        }

        public void Execute(object parameter)
        {
            if (parameter is T typedParameter)
            {
                execute(typedParameter);
            }
            else
            {
                execute(default(T));
            }
        }
    }

    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
