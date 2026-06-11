using System.Collections.Generic;
using System.Threading.Tasks;

namespace Yugen.MotoGP.App.Services.CalendarService
{
	public interface ICalendarService
	{
		Task<IList<Models.Events.Event>> GetCalendar();
	}
}