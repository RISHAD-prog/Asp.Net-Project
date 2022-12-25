using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [ForeignKey("DoctorSchedules")]
        public int ScheduleID { get; set; }
        [ForeignKey("Patients")]
        public int PatientID { get; set; }
        [Required]
        [StringLength(100)]
        public string PatientName { get; set; }
        [Required]
        public System.DateTime AppointCreateDate { get; set; }
        [Required]
        [StringLength(100)]
        public string Status { get; set; }
        [Required]
        public int DoctorID { get; set; }
        [Required,StringLength(100)]
        public string DoctorName { get; set; }
        [Required, StringLength(100)]
        public string DoctorQualification { get; set; }
        public virtual Patient Patients { get; set; }
        public virtual DoctorSchedule DoctorSchedules { get; set; }
        public virtual List<PatientCheckUp> PatientCheckUps { get; set; }
        public Appointment()
        {
            this.PatientCheckUps=new List<PatientCheckUp>();    
        }
    }
}
