using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AppointMentService
    {
        public static AppointmentDTO Add(AppointmentDTO appointment,string name)
        {
            var config = Service.Mapping<AppointmentDTO, Appointment>();
            var mapper = new Mapper(config);
            var data = DataAccessFactory.DoctorAuthSchCheckerDataAccess().Schedule(name);
            var patientData = DataAccessFactory.PatientAuthCheckerDataAccess().GetChecker(appointment.PatientName);
            var allappointment = DataAccessFactory.NewAppointmentDataAccess().GetListOfId(data.Id);
            if(data != null && allappointment.Count()<10)
            {
                var data1 = appointment.AppointCreateDate;
                var data2 = data.CheckUpTimeStart;
                var data3 = data.CheckUpTimeEnd;
                var check1 = DateTime.Compare(data1 , data2);
                var check2 = DateTime.Compare(data3 , data1);
                if (check1==1 && check2==1)
                {
                    var addappointment = new Appointment();
                    addappointment.ScheduleID = data.Id;
                    addappointment.PatientID = patientData.ID;
                    addappointment.PatientName = appointment.PatientName;
                    addappointment.AppointCreateDate = appointment.AppointCreateDate;
                    addappointment.DoctorID = data.DoctorID;
                    addappointment.DoctorName = data.DoctorName;
                    addappointment.Status = "Inactive";
                    var access = DataAccessFactory.AppointmentDataAccess().Add(addappointment);
                    if (access != null)
                    {
                        return mapper.Map<AppointmentDTO>(access);
                    }
                }
            }            
            return null;
        }
        public static List<AppointmentDTO> ShowAppointments(int id)
        {
            var appDoc = DataAccessFactory.NewAppointmentDataAccess().GetListOfId(id);
            var config = Service.OneTimeMapping<Appointment, AppointmentDTO>();
            var mapper = new Mapper(config);
            return mapper.Map<List<AppointmentDTO>>(appDoc);
        }
        public static AppointmentDTO Get(int id)
        {
            var data = DataAccessFactory.DoctorDataAccess().Get(id);
            var config = Service.OneTimeMapping<Appointment, AppointmentDTO>();
            var mapper = new Mapper(config);
            return mapper.Map<AppointmentDTO>(data);
        }
        public static AppointmentDTO Get()
        {
            var data = DataAccessFactory.DoctorDataAccess().Get();
            var config = Service.OneTimeMapping<Appointment, AppointmentDTO>();
            var mapper = new Mapper(config);
            return mapper.Map<AppointmentDTO>(data);
        }
    }
}
