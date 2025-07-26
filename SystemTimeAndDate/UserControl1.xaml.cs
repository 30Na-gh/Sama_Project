using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SystemTimeAndDate
{
    public partial class ClockControl : UserControl
    {
        private readonly DispatcherTimer _timer;

        public ClockControl()
        {
            InitializeComponent();
            UpdateClock();

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += (_, _) => UpdateClock();
            _timer.Start();
        }

        private void UpdateClock()
        {
            TimeText.Text = DateTime.Now.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);

            // تاریخ شمسی
            PersianCalendar pc = new PersianCalendar();
            DateTime now = DateTime.Now;

            string[] weekDays = { "یکشنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنج‌شنبه", "جمعه", "شنبه" };
            string[] months = { "", "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };

            string farsiWeekday = weekDays[(int)pc.GetDayOfWeek(now)];
            string farsiMonth = months[pc.GetMonth(now)];

            string persianDate = $"{farsiWeekday} {pc.GetDayOfMonth(now)} {farsiMonth} {pc.GetYear(now)}";
            DateText.Text = persianDate;
        }
    }
}