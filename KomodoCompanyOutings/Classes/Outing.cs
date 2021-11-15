using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCompanyOutings.Classes
{
    public enum EventType { Golf, Bowling, AmusementPark, Concert }
    public class Outing
    {
        public Outing() { }
        public Outing(EventType eventType, int attendance, DateTime eventDate, double totalCost)
        {
            EventType = eventType;
            Attendance = attendance;
            EventDate = eventDate;
            TotalCost = totalCost;
        }
        public EventType EventType { get; set; }
        public int Attendance { get; set; }
        public DateTime EventDate { get; set; }
        public double TotalCost { get; set; }
        public double CostPerPerson 
        {
            get
            {
                return CostPerPerson = TotalCost / Attendance;
            }
            set
            {
                return;
            }
        }
    }
}
