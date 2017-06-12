using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23
{
    [Serializable]
    public class History
    {
        public History(string t, string p)
        {
            this.TicketNO = t;
            this.PassengerId = p;
        }
        public string TicketNO { get; set; }
        public string PassengerId { get; set; }

        public static bool IsTicketExist(string t)
        {
            return Repository.lstTickets.Any(x => x.No == t);
        }

        public static bool IsTicketSold(string t)
        {
            return Repository.lstHistorys.Any(x => x.TicketNO == t);
        }

        public static bool IsPassengerExist(string p)
        {
            return Repository.lstPassengers.Any(x => x.Id == p);
        }

        public static bool Buy(string t, string p)
        {
            if (IsTicketExist(t) && !IsTicketSold(t))
            {
                Repository.lstHistorys.Add(new History(t, p));
                return true;
            }
            else
                return false;
        }

        public static bool Return(string t)
        {
            if (IsTicketExist(t) && IsTicketSold(t))
            {
                var h = Repository.lstHistorys.First(x => x.TicketNO == t);
                Repository.lstHistorys.Remove(h);
                return true;
            }
            else
                return false;
        }
    }
}
