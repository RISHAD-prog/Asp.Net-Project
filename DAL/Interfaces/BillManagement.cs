using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface BillManagement<CLASS>
    {
        List<CLASS> GetBills(string name);
    }
}
