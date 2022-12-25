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
    public class ListService
    {
        public static TestListDTO Add(TestListDTO testList)
        {
            var config = Service.Mapping<TestListDTO, TestList>();
            var mapper = new Mapper(config);
            var result = mapper.Map<TestList>(testList);
            var access = DataAccessFactory.TestDataAccess().Add(result);
            if (access != null)
            {
                return mapper.Map<TestListDTO>(access);
            }
            return null;
        }
        public static List<TestListDTO> Get()
        {
            var cfg = Service.OneTimeMapping<TestList, TestListDTO>();
            var mapper = new Mapper(cfg);
            var access = DataAccessFactory.TestDataAccess().Get();
            return mapper.Map<List<TestListDTO>>(access);
        }
        public static TestListDTO Get(int id)
        {
            var data = DataAccessFactory.TestDataAccess().Get(id);
            var config = Service.OneTimeMapping<TestList, TestListDTO>();
            var mapper = new Mapper(config);
            return mapper.Map<TestListDTO>(data);
        }
        public static TestListDTO Update(TestListDTO boardDTO)
        {
            var config = Service.Mapping<TestList, TestListDTO>();
            var mapper = new Mapper(config);
            var notice = mapper.Map<TestList>(boardDTO);
            var data = DataAccessFactory.TestDataAccess().Update(notice);
            if (data != null)
            {
                return mapper.Map<TestListDTO>(data);
            }

            return null;

        }
    }
}
