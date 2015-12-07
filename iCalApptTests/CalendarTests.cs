using System;
using NUnit.Framework;
using iCalApp;

namespace iCalApptTests
{
    public class CalendarTests
    {
        [Test]
        public void GivenAnCalendar_WhenAddingAnEvent_ThenTheicsTextIsCorrect()
        {
            Calendar calendar = new Calendar();
            DateTime when = DateTime.Today;
            string eventDescription = "ShipIt";
            Assert.That(calendar.CreateEvent(when, eventDescription), Is.EqualTo("aaaaaaaaa"));
        }
    }
}
