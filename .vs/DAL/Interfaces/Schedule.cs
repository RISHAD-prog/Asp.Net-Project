using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface Schedule<CLASS,RET>
    {
        CLASS GetData(List<RET> id);
    }
}
