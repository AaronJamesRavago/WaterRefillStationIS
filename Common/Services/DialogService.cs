using System;
using System.Collections.Generic;
using System.Windows;

namespace Common.Services
{
    public class DialogService : IDialogService
    {
        private Dictionary<Type, Type> windowMapping = new Dictionary<Type, Type>();

        /// <summary>
        /// Register the ViewModel and View in the Map
        /// </summary>
        /// <param name="ViewModel"></param>
        /// <param name="View"></param>
        public void Register(Type ViewModel, Type View)
        {
            if (windowMapping.ContainsKey(ViewModel))
                throw new ArgumentException("viewModel is already registered. Consider using Replace method");
            else
                windowMapping.Add(ViewModel, View);
        }

        /// <summary>
        /// Remove ViewModel from the Map
        /// </summary>
        /// <param name="ViewModel"></param>
        public void Unregister(Type ViewModel)
        {
            windowMapping.Remove(ViewModel);
        }

        public void Show(Type viewModel, bool allowMultipleInstance = false)
        {
            Type windowType = null;

            bool isRegistered = windowMapping.TryGetValue(viewModel, out windowType);

            if (!isRegistered)
                throw new KeyNotFoundException("The dialog window is not registered to DialogService");


            // Check if dialog is already created
            if (allowMultipleInstance == false)
            {
                foreach (Window form in Application.Current.Windows)
                {
                    if (form.GetType() == windowType)
                    {
                        form.Visibility = Visibility.Visible;
                        form.Focus();
                        return;
                    }
                }
            }

            // Create dialog and set properties
            Window dialog = (Window)Activator.CreateInstance(windowType);
            dialog.DataContext = viewModel;

            // Show dialog
            dialog.Show();
        }

        public bool? ShowDialog(Type viewModel)
        {
            Type windowType = null;

            bool isRegistered = windowMapping.TryGetValue(viewModel, out windowType);

            if (!isRegistered)
                throw new KeyNotFoundException("The dialog window is not registered to DialogService");

            // Create dialog and set properties
            Window dialog = (Window)Activator.CreateInstance(windowType);
            dialog.DataContext = viewModel;

            return dialog.ShowDialog();
        }
    }
}
