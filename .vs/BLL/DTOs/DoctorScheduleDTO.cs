using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DoctorScheduleDTO
    {
        public int Id { get; set; }
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string Qualification { get; set; }
        public System.DateTime CheckUpTimeStart { get; set; }
        public System.DateTime CheckUpTimeEnd { get; set; }
        public System.DateTime WeekDay { get; set; }

    }
}
