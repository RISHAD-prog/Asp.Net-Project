using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Labratory
    {
        public int Id { get; set; }
        [ForeignKey("Patients")]
        public int PatientID { get; set; }
        [Required,StringLength(50)]
        public string PatientName { get; set; }
        [ForeignKey("TestLists")]
        public int TestID { get; set; }
        [Required,StringLength(100)]
        public string TestName { get; set; }
        [Required]
        public int TestFee { get; set; }
        public virtual Patient Patients { get; set; }
        public virtual TestList TestLists { get; set; }
    }
}
