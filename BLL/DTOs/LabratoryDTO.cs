using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class LabratoryDTO
    {
        public int TestID { get; set; }
        public string TestName { get; set; }
        public int TestFee { get; set; }
        public int PatientID { get; set; }
        public string PatientName { get; set; }
    }
}
