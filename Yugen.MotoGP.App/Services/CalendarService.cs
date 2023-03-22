using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Args;
using Yugen.MotoGP.App.Models.Calendar;

namespace Yugen.MotoGP.App.Services
{
    public class CalendarService : ICalendarService
    {
        public event EventHandler<LiveTimingEventArgs> LiveTimingChanged;

        private readonly IHttpClientService _httpClientService;
        private readonly int _currentYear = 2023;

        private int _year;

        public CalendarService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IList<Event>> GetCalendar(int? year = null)
        {
            _year = year ?? _currentYear;
            var calendar = await _httpClientService.GetCalendar(_year.ToString());
            return calendar.Events;
        }
    }
}