using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ScheduleChecker<CLASS,RET>
    {
        List<CLASS> data(RET data);
        CLASS Schedule(RET data);
    }
}
