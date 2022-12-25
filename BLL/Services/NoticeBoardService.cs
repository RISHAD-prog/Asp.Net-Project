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
    public class NoticeBoardService
    {
        public static NoticeBoardDTO Add(NoticeBoardDTO boardDTO)
        {
            var config = Service.Mapping<NoticeBoardDTO, NoticeBoard>();
            var mapper = new Mapper(config);
            var data = mapper.Map<NoticeBoard>(boardDTO);
            var repo = DataAccessFactory.NoticeBoardDataAccess().Add(data);
            if (repo != null)
            {
                return mapper.Map<NoticeBoardDTO>(repo);
            }
            return null;
        }
        public static List<NoticeBoardDTO> Get()
        {
            var data = DataAccessFactory.NoticeBoardDataAccess().Get();
            //var config= Service.OneTimeMapping<Doctor, DoctorDTO>();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<NoticeBoard, NoticeBoardDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<NoticeBoardDTO>>(data);
        }
        public static NoticeBoardDTO Get(int id)
        {
            var data = DataAccessFactory.NoticeBoardDataAccess().Get(id);
            var config = Service.OneTimeMapping<NoticeBoard, NoticeBoardDTO>();
            var mapper = new Mapper(config);
            return mapper.Map<NoticeBoardDTO>(data);
        }


        public static bool Delete(/*DoctorDTO doctorDTO*/ int id)
        {
            //var config = Service.OneTimeMapping<Doctor, DoctorDTO>();
            //var mapper = new Mapper(config);
            //var doctor = mapper.Map<Doctor>(doctorDTO);
            var data = DataAccessFactory.NoticeBoardDataAccess().Delete(/*doctor*/ id);
            return data;

        }


        public static NoticeBoardDTO Update(NoticeBoardDTO boardDTO)
        {
            var config = Service.Mapping<NoticeBoard, NoticeBoardDTO>();
            var mapper = new Mapper(config);
            var notice = mapper.Map<NoticeBoard>(boardDTO);
            var data = DataAccessFactory.NoticeBoardDataAccess().Update(notice);
            if (data != null)
            {
                return mapper.Map<NoticeBoardDTO>(data);
            }

            return null;

        }

    }
}
