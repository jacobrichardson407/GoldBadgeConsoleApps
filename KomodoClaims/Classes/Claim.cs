using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims.Classes
{
    public enum ClaimType { Car, Home, Theft}
    public class Claim
    {
        public Claim()
        {

        }
        public Claim(int claimID, ClaimType claimType, string description, double claimAmount,  DateTime incidentDate, DateTime claimDate)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            ClaimDate = claimDate;
            IncidentDate = incidentDate;
        }
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime ClaimDate { get; set; }
        public DateTime IncidentDate { get; set; }
        public bool IsValid
        {
            get
            {

                if ((ClaimDate - IncidentDate).TotalDays <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                Console.WriteLine("This claim is valid");
                return;
            }
        }
    }
}
