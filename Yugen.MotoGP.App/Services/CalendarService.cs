using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Calendar;

namespace Yugen.MotoGP.App.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly IHttpClientService _httpClientService;

        private int _year;
        private CalendarBase calendar;

        public CalendarService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IList<Event>> GetCalendar(int? year = null)
        {
            _year = year ?? DateTime.UtcNow.Year;
            calendar = calendar ?? await _httpClientService.GetCalendar(_year.ToString());
            return calendar.Events.Where(x => x.Kind.Equals("GP")).ToList();
        }

        public async Task<Event> GetCurrentEvent()
        {
            var events = await GetCalendar();
            return events.FirstOrDefault(x => x.Status.Equals("CURRENT"));
        }
    }
}