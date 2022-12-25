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
    public class LabratoryService
    {
        public static LabratoryDTO Add(LabratoryDTO testList,int id)
        {
            var config = Service.Mapping<LabratoryDTO, Labratory>();
            var mapper = new Mapper(config);
            var data = DataAccessFactory.TestDataAccess().Get(id);
            var result = new Labratory();
            result.PatientID=testList.PatientID;
            result.PatientName=testList.PatientName;
            result.TestID = data.Id;
            result.TestName=data.TestName;
            result.TestFee = data.TestFee;
            var access = DataAccessFactory.LabratoryDataAccess().Add(result);
            if (access != null)
            {
                return mapper.Map<LabratoryDTO>(access);
            }
            return null;
        }
        public static List<LabratoryDTO> Get()
        {
            var cfg = Service.OneTimeMapping<Labratory, LabratoryDTO>();
            var mapper = new Mapper(cfg);
            var access = DataAccessFactory.LabratoryDataAccess().Get();
            return mapper.Map<List<LabratoryDTO>>(access);
        }
        public static LabratoryDTO Get(int id)
        {
            var data = DataAccessFactory.LabratoryDataAccess().Get(id);
            var config = Service.OneTimeMapping<Labratory, LabratoryDTO>();
            var mapper = new Mapper(config);
            return mapper.Map<LabratoryDTO>(data);
        }
        public static LabratoryDTO Update(LabratoryDTO boardDTO)
        {
            var config = Service.Mapping<Labratory, LabratoryDTO>();
            var mapper = new Mapper(config);
            var notice = mapper.Map<Labratory>(boardDTO);
            var data = DataAccessFactory.LabratoryDataAccess().Update(notice);
            if (data != null)
            {
                return mapper.Map<LabratoryDTO>(data);
            }

            return null;

        }
    }
}
