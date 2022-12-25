using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class DoctorSchedule
    {
        public int Id { get; set; }
        [ForeignKey("Doctors")]
        public int DoctorID { get; set; }
        [Required]
        [StringLength(100)]
        public string DoctorName { get; set; }
        [Required,StringLength(100)]
        public string Qualification { get; set; }
        [Required]
        public System.DateTime CheckUpTimeStart{ get; set; }
        [Required]
        public System.DateTime CheckUpTimeEnd { get; set; }
        [Required]
        public System.DateTime WeekDay { get; set; }
        public virtual Doctor Doctors { get; set; }
        public virtual List<Appointment> Appointments { get; set; }
        public DoctorSchedule()
        {
            this.Appointments = new List<Appointment>();
        }
    }
}
