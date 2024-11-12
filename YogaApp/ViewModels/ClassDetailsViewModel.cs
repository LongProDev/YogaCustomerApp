using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using YogaApp.Models;
using YogaApp.Services;
using YogaApp.Views;


namespace YogaApp.ViewModels
{
    public class ClassDetailsViewModel : ObservableObject
    {
        private readonly BookingService _bookingService;
        private ClassDetails _classDetails;
        private bool _isLoading;
        private string _errorMessage;

        public ClassDetailsViewModel(BookingService bookingService)
        {
            _bookingService = bookingService;
            BookClassCommand = new AsyncRelayCommand(BookClassAsync);
            ShareClassCommand = new RelayCommand(ShareClass);
        }

        public ClassDetails ClassDetails
        {
            get => _classDetails;
            set => SetProperty(ref _classDetails, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public ICommand BookClassCommand { get; }
        public ICommand ShareClassCommand { get; }

        private readonly IYogaApiService _apiService;

        [ObservableProperty]
        private ClassDetails classDetails;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private string errorMessage;

        public ClassDetailsViewModel(IYogaApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task LoadClassDetails(int classInstanceId)
        {
            try
            {
                IsLoading = true;
                ErrorMessage = null;
                ClassDetails = await _bookingService.GetClassDetails(classInstanceId);
            }
            catch (Exception ex)
            {
                ErrorMessage = "Failed to load class details";
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task BookClassAsync()
        {
            try
            {
                IsLoading = true;
                ErrorMessage = null;
                // Assuming you have the user ID from authentication
                string userId = "current-user-id";
                await _bookingService.CreateBooking(ClassDetails.Instance.Id, userId);
                await LoadClassDetails(ClassDetails.Instance.Id); // Refresh details
            }
            catch (Exception ex)
            {
                ErrorMessage = "Failed to book class";
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void ShareClass()
        {
            // Implement share functionality
            Share.RequestAsync(new ShareTextRequest
            {
                Title = $"Check out this {ClassDetails.YogaClass.Type} class!",
                Text = $"Join me for {ClassDetails.YogaClass.Type} on {ClassDetails.Instance.Date:dddd, MMMM dd} at {ClassDetails.YogaClass.Time:hh\\:mm}"
            });
        }
    }

}
