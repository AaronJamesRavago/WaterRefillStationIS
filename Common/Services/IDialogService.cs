using System;
namespace Common.Services
{
    public interface IDialogService
    {
        void Register(Type ViewModel, Type View);
        void Show(Type viewModel, bool allowMultipleInstance = false);
        bool? ShowDialog(Type viewModel);
        void Unregister(Type ViewModel);
    }
}
