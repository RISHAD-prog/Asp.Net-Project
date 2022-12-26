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
    public class BedService
    {
        public static BedCategoryDTO AddCategory(BedCategoryDTO bedCategory)
        {
            var config = Service.Mapping<BedCategoryDTO, BedCategory>();
            var mapper = new Mapper(config);
            var map = mapper.Map<BedCategory>(bedCategory);
            var data = DataAccessFactory.BedCategoryDataAccess().Add(map);
            if (data != null)
            {
                return mapper.Map<BedCategoryDTO>(data);
            }
            return null;
        }
        public static List<BedDTO> ShowBeds(int id)
        {
            var config = Service.OneTimeMapping<Bed, BedDTO>();
            var mapper = new Mapper(config);
            var data = DataAccessFactory.BedListDataAccess().GetListOfId(id);
            return mapper.Map<List<BedDTO>>(data);
        }
        public static BedDTO AddBedsInCategory(BedDTO beds,string name)
        {
            //Changes need . need to set the bed as Vacant
            var config = Service.Mapping<BedDTO, Bed>();
            var mapper = new Mapper(config);
            var data = DataAccessFactory.GetBedCategoryDataAccess().Category(name);
            if(data != null)
            {
                var bed = new Bed();
                bed.BedCategoryID = data.Id;
                bed.BedCategory = name;
                bed.BedName = beds.BedName;
                bed.Status = "Vacant";
                bed.BedFee = beds.BedFee;
                var value = DataAccessFactory.BedDataAccess().Add(bed);
                if (value != null)
                {
                    return mapper.Map<BedDTO>(value);
                }
            }
            
            return null;
        }
        public static List<BedCategoryDTO> GetCategory()
        {
            var config = Service.OneTimeMapping<BedCategory, BedCategoryDTO>();
            var mapper = new Mapper(config);
            var data = DataAccessFactory.BedCategoryDataAccess().Get();
            return mapper.Map<List<BedCategoryDTO>>(data);
        }
        public static void EditBedStatus(Bed bed)
        {
            var config = Service.Mapping<Bed, BedDTO>();
            var mapper = new Mapper(config);
            var data = DataAccessFactory.BedDataAccess().Update(bed);
            mapper.Map<BedDTO>(data);
        }
        public static double Checkout(int id)
        {

            var data = DataAccessFactory.BedAllotmentDataAccess().Get(id);
            var bednameData = DataAccessFactory.GetAllotmentOFBed().GetData(data.BedID);
            if (data != null)
            {
                var Fee = (data.DischargeDate - data.AllotmentDate).TotalDays * bednameData.BedFee;
                var bedinfo = DataAccessFactory.BedListDataAccess().GetCategory(data.BedCategory);
                var bed = new Bed();
                bed.Id = data.BedID;
                bed.BedCategoryID = bedinfo.BedCategoryID;
                bed.BedCategory = data.BedCategory;
                bed.BedName = data.BedName;
                bed.Status = "Vacant";
                bed.BedFee = bedinfo.BedFee;
                var config = Service.Mapping<Bed, BedDTO>();
                var mapper = new Mapper(config);
                var new_data = DataAccessFactory.BedDataAccess().Update(bed);
                if (new_data != null)
                {
                    return Fee;
                }

            }
            return 0.00;

        }
    }
}
