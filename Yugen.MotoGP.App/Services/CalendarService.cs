using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Calendar;
using Yugen.MotoGP.App.Models.Results.Events;

namespace Yugen.MotoGP.App.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly int _year = DateTime.UtcNow.Year;

        private IList<EventsBase> _eventList;
        private CalendarBase _calendar;

        public CalendarService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IList<Event>> GetCalendar()
        {
            _calendar ??= await _httpClientService.GetCalendar(_year.ToString());
            var motoGpEvents = _calendar.Events.Where(x => x.Kind.Equals("GP")).ToList();

            _eventList ??= await _httpClientService.GetResultsEvents();
            foreach (var motoGpEvent in motoGpEvents)
            {
                var eventBase = _eventList.FirstOrDefault(x => x.ShortName == motoGpEvent.Shortname);
                if (eventBase != null)
                {
                    motoGpEvent.Id = eventBase.Id;
                }
            }

            return motoGpEvents;
        }
    }
}