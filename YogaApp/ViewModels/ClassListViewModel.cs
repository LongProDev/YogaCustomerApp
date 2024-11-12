
using YogaApp.Services;
using YogaApp.Models;

namespace YogaApp.ViewModels
{
    public class ClassListViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;
        private List<YogaClassInstance> _classInstances;
        private string _selectedDay;
        private TimeSpan? _selectedTime;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<YogaClassInstance> FilteredInstances => _classInstances?
            .Where(i => (string.IsNullOrEmpty(_selectedDay) || i.Date.DayOfWeek.ToString() == _selectedDay) &&
                        (!_selectedTime.HasValue || i.YogaClass.Time == _selectedTime.Value))
            .ToList();

        public string SelectedDay
        {
            get => _selectedDay;
            set
            {
                _selectedDay = value;
                OnPropertyChanged(nameof(FilteredInstances));
            }
        }

        public TimeSpan? SelectedTime
        {
            get => _selectedTime;
            set
            {
                _selectedTime = value;
                OnPropertyChanged(nameof(FilteredInstances));
            }
        }

        public ClassListViewModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task LoadClassesAsync()
        {
            _classInstances = await _apiService.GetClassInstances();
            OnPropertyChanged(nameof(FilteredInstances));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
