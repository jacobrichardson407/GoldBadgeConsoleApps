using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims.Classes
{
    public class ClaimRepository
    {
        protected readonly List<Claim> _claimDirectory = new List<Claim>();
        public bool AddContentToDirectory(Claim content)
        {
            int startingCount = _claimDirectory.Count;
            _claimDirectory.Add(content);

            bool wasAdded = (_claimDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<Claim> GetContents()
        {
            return _claimDirectory;
        }
        public Claim GetContentByClaimID(int number)
        {
            foreach (Claim content in _claimDirectory)
            {
                if (content.ClaimID == number)
                {
                    return content;
                }
            }
            return null;
        }
        public bool DeleteExistingContent(Claim existingContent)
        {
            bool deleteResult = _claimDirectory.Remove(existingContent);
            return deleteResult;
        }
        public bool DeleteExistingContentByClaimID(int number)
        {
            return DeleteExistingContent(GetContentByClaimID(number));
        }
    }
}
