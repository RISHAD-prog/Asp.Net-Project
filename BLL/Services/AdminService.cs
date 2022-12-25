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
    public class AdminService
    {
        public static AdminDTO Add(AdminDTO adminDTO)
        {
            var config = Service.Mapping<AdminDTO, Admin>();
            var mapper = new Mapper(config);
            var data = mapper.Map<Admin>(adminDTO);
            var repo = DataAccessFactory.AdminDataAccess().Add(data);
            if (repo != null)
            {
                return mapper.Map<AdminDTO>(repo);
            }
            return null;
        }
        public static List<AdminDTO> Get()
        {
            var data = DataAccessFactory.AdminDataAccess().Get();
            //var config= Service.OneTimeMapping<Doctor, DoctorDTO>();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<AdminDTO>>(data);
        }
        public static AdminDTO Get(int id)
        {
            var data = DataAccessFactory.AdminDataAccess().Get(id);
            var config = Service.OneTimeMapping<Admin, AdminDTO>();
            var mapper = new Mapper(config);
            return mapper.Map<AdminDTO>(data);
        }


        public static bool Delete(/*DoctorDTO doctorDTO*/ int id)
        {
            //var config = Service.OneTimeMapping<Doctor, DoctorDTO>();
            //var mapper = new Mapper(config);
            //var doctor = mapper.Map<Doctor>(doctorDTO);
            var data = DataAccessFactory.AdminDataAccess().Delete(/*doctor*/ id);
            return data;

        }


        public static AdminDTO Update(AdminDTO adminDTO)
        {
            var config = Service.Mapping<Admin, AdminDTO>();
            var mapper = new Mapper(config);
            var admin = mapper.Map<Admin>(adminDTO);
            var data = DataAccessFactory.AdminDataAccess().Update(admin);
            if (data != null)
            {
                return mapper.Map<AdminDTO>(data);
            }

            return null;

        }


        //_______________________________________

        public static AdminDTO GetChecker(string name)
        {
            var data = DataAccessFactory.AdminAuthCheckerDataAccess().GetChecker(name);
            var config = Service.OneTimeMapping<Admin, AdminDTO>();
            var mapper = new Mapper(config);
            return mapper.Map<AdminDTO>(data);
        }

    }
}
