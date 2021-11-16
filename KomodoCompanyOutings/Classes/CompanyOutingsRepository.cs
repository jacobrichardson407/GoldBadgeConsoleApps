using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCompanyOutings.Classes
{
    public class CompanyOutingsRepository
    {
        protected readonly List<Outing> _outingDirectory = new List<Outing>();
        public bool AddContentToDirectory(Outing content)
        {
            int startingCount = _outingDirectory.Count;
            _outingDirectory.Add(content);

            bool wasAdded = (_outingDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<Outing> GetContents()
        {
            return _outingDirectory;
        }
        public Outing GetContentByEventType(string outing)
        {
            foreach (Outing content in _outingDirectory)
            {
                if (content.EventType.ToString() == outing)
                {
                    return content;
                }
            }
            return null;
        }
        public double GetTotalCost()
        {
            double total = _outingDirectory.Sum(_outingDirectory => _outingDirectory.TotalCost);
            return total;
        }
        public double GetTotalCostByEvent(EventType eventType)
        {
            double total = 0;
            var eventTypeListing = new List<Outing>();
            foreach (var item in _outingDirectory)
            {
                if (item.EventType == eventType)
                {
                    eventTypeListing.Add(item);
                }
            }
            foreach (var totalCost in eventTypeListing)
            {
                total += totalCost.TotalCost;
            }
            return total;
        }
    }
}
