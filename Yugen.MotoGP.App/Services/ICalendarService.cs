using System.Collections.Generic;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Calendar;

namespace Yugen.MotoGP.App.Services
{
    public interface ICalendarService
    {
        Task<IList<Event>> GetCalendar();
    }
}