using Nobatkar_WinUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Nobatkar_WinUI.ViewModels
{
    public class CalendarPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ShiftDay> Days { get; set; }

        private string _currentMonthTitle;
        public string CurrentMonthTitle
        {
            get => _currentMonthTitle;
            set
            {
                _currentMonthTitle = value;
                OnPropertyChanged();
            }
        }

        public CalendarPageViewModel()
        {
            LoadMockData();
        }

        public void GoToPreviousMonth()
        {
            CurrentMonthTitle = "اردیبهشت ۱۴۰۴"; // Placeholder
        }

        public void GoToNextMonth()
        {
            CurrentMonthTitle = "تیر ۱۴۰۴"; // Placeholder
        }

        public void AddDummyShiftPlan()
        {
            // For testing
            Days[0].ShiftLabel = "🌙 شب";
            OnPropertyChanged(nameof(Days));
        }

        private void LoadMockData()
        {
            CurrentMonthTitle = "خرداد ۱۴۰۴";
            Days = new ObservableCollection<ShiftDay>();

            for (int i = 1; i <= 30; i++)
            {
                Days.Add(new ShiftDay
                {
                    DayNumber = i,
                    ShiftLabel = (i % 3 == 0) ? "🌙 شب" : (i % 3 == 1 ? "🌅 صبح" : "💤 استراحت")
                });
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }


}
