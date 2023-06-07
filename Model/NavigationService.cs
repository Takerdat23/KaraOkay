using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_Karaokay.Model
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

        public object GetwindowVM(string windowkey)
        {
            object ViewModel= new object(); 
            if (_windows.TryGetValue(windowkey, out (Type windowType, object viewModel) windowInfo))
            {
                ViewModel = windowInfo.viewModel;
            }
            

            return ViewModel;
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
}
