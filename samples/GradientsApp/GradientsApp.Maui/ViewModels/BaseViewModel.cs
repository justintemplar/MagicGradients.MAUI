using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradientsApp.Maui.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        public BaseViewModel()
        {
            Title = string.Empty;            
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        public bool isBusy = false;

        public bool IsNotBusy => !IsBusy;

        [ObservableProperty]
        public string title;

        public virtual void OnAppearing() { }

        public virtual void OnNavigatedTo() { }

        public virtual void OnDisappearing() { }


        private bool shouldLoadContent = true;
        public bool ShouldLoadContent(bool forAnyUpdates = false)
        {
            bool result = shouldLoadContent;

            if (result)
            {
                shouldLoadContent = false;
            }

            return result;
        }



        public void ResetShouldLoadContent()
        {
            shouldLoadContent = true;
        }

        private bool _alreadyOpen = false;

        [RelayCommand]
        public void ToggleFlyoutMenu()
        {
            // BUG: https://github.com/dotnet/maui/issues/8226
#if ANDROID
            if (!_alreadyOpen)
            {
                Shell.Current.FlyoutBehavior = FlyoutBehavior.Locked;
                Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
                _alreadyOpen = true;
            }
#endif

            Shell.Current.FlyoutIsPresented = !Shell.Current.FlyoutIsPresented;
        }

        [RelayCommand]
        public async Task NavigationBack()
        {
            try
            {
                await Shell.Current.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
