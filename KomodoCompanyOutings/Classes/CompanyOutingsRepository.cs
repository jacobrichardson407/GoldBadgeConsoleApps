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
    }
}
