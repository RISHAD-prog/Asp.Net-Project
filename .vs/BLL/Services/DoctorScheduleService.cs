using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DoctorScheduleService
    {
        public static DoctorScheduleDTO Add(DoctorScheduleDTO doctor)
        {
            var config = Service.Mapping<DoctorScheduleDTO, DoctorSchedule>();
            var mapper = new Mapper(config);

            var data = mapper.Map<DoctorSchedule>(doctor);
            var repo = DataAccessFactory.DoctorScheduleDataAccess().Add(data);
            if (repo != null)
            {
                return mapper.Map<DoctorScheduleDTO>(repo);
            }
            return null;
        }
        public static List<DoctorScheduleDTO> Get()
        {
            var data = DataAccessFactory.DoctorScheduleDataAccess().Get();
            var config= Service.OneTimeMapping<DoctorSchedule, DoctorScheduleDTO>();
            /*var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DoctorSchedule, DoctorScheduleDTO>();
            });*/
            var mapper = new Mapper(config);
            return mapper.Map<List<DoctorScheduleDTO>>(data);
        }
        public static List<DoctorScheduleDTO> Get(string name)
        {
            var data = DataAccessFactory.DoctorAuthDataAccess().Doctors(name);
            var config= Service.OneTimeMapping<DoctorSchedule, DoctorScheduleDTO>();
            /*var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DoctorSchedule, DoctorScheduleDTO>();
            });*/
            var mapper = new Mapper(config);
            return mapper.Map<List<DoctorScheduleDTO>>(data);
        }
        public static DoctorScheduleDTO Get(int id)
        {
            var data = DataAccessFactory.DoctorScheduleDataAccess().Get(id);
            var config = Service.OneTimeMapping<DoctorSchedule, DoctorScheduleDTO>();
            var mapper = new Mapper(config);
            return mapper.Map<DoctorScheduleDTO>(data);
        }


        public static bool Delete(/*DoctorDTO doctorDTO*/ int id)
        {
            //var config = Service.OneTimeMapping<Doctor, DoctorDTO>();
            //var mapper = new Mapper(config);
            //var doctor = mapper.Map<Doctor>(doctorDTO);
            var data = DataAccessFactory.DoctorScheduleDataAccess().Delete(/*doctor*/ id);
            return data;

        }


        public static DoctorScheduleDTO Update(DoctorScheduleDTO doctorDTO)
        {
            var config = Service.Mapping<DoctorSchedule, DoctorScheduleDTO>();
            var mapper = new Mapper(config);
            var doctor = mapper.Map<DoctorSchedule>(doctorDTO);
            var data = DataAccessFactory.DoctorScheduleDataAccess().Update(doctor);
            if (data != null)
            {
                return mapper.Map<DoctorScheduleDTO>(data);
            }

            return null;

        }
    }
}
