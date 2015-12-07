using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDay.iCal;

namespace iCalApp
{
    public class Calendar
    {
        public string CreateEvent(DateTime when, string eventDescription)
        {
            iCalendar calendar = new iCalendar();
            calendar.AddProperty(new CalendarProperty());
        }
    }
}
