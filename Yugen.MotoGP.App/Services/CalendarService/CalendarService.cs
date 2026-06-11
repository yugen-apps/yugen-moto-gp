using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Services.HttpClientService;

namespace Yugen.MotoGP.App.Services.CalendarService
{
	public class CalendarService : ICalendarService
	{
		private readonly IHttpClientService _httpClientService;
		private readonly string _year = DateTime.UtcNow.Year.ToString();

		private IList<Models.Events.Event> _events;
		private IList<Models.Events.Event> _gpEvents;

		public CalendarService(IHttpClientService httpClientService)
		{
			_httpClientService = httpClientService;
		}

		public async Task<IList<Models.Events.Event>> GetCalendar()
		{
			_events ??= await _httpClientService.GetEvents(_year);

			_gpEvents ??= _events.Where(x => x.Kind.Equals("GP")).ToList();

			return _gpEvents;
		}
	}
}