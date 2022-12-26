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
    public class PatientService
    {
        public static PatientDTO Add(PatientDTO patient)
        {
            var config = Service.Mapping<PatientDTO, Patient>();
            var mapper = new Mapper(config);
            var check=DataAccessFactory.PatientAuthDataAccess().Authenticate(patient.Name,patient.Password);
            if (check != null)
            {
                return null;
            }
            var data = mapper.Map<Patient>(patient);
            var access = DataAccessFactory.PatientDataAccess().Add(data);
            if (access != null)
            {
                return mapper.Map<PatientDTO>(access);
            }return null;
        }
        public static List<PatientDTO> Get()
        {
            var config = Service.OneTimeMapping<Patient, PatientDTO>();
            var mapper = new Mapper(config);
            var access = DataAccessFactory.PatientDataAccess().Get();
            return mapper.Map<List<PatientDTO>>(access);            
        }
        public static PatientDTO Get(int id)
        {
            var config = Service.OneTimeMapping<Patient, PatientDTO>();
            var mapper = new Mapper(config);
            var access = DataAccessFactory.PatientDataAccess().Get(id);
            return mapper.Map<PatientDTO>(access);
        }

        public static bool Delete(/*PatientDTO patient*/int id)
        {
            //var config = Service.OneTimeMapping<Patient, PatientDTO>();
            //var mapper = new Mapper(config);
            //var patients = mapper.Map<Patient>(patient);
            var data = DataAccessFactory.PatientDataAccess().Delete(/*patients*/id);
            return data;

        }


        public static PatientDTO Update(PatientDTO patientDTO)
        {
            var config = Service.Mapping<Patient, PatientDTO>();
            var mapper = new Mapper(config);
            var patient = mapper.Map<Patient>(patientDTO);
            var data = DataAccessFactory.PatientDataAccess().Update(patient);
            if (data != null)
            {
                return mapper.Map<PatientDTO>(data);
            }

            return null;

        }

        //__________________________________________


        public static PatientDTO GetChecker(string name)
        {
            var data = DataAccessFactory.PatientAuthCheckerDataAccess().GetChecker(name);
            var config = Service.OneTimeMapping<Patient, PatientDTO>();
            var mapper = new Mapper(config);
            return mapper.Map<PatientDTO>(data);
        }
        public static PatientDTO GetBills(string name)
        {
            var config = Service.Mapping<Patient, PatientDTO>();
            var mapper = new Mapper(config);
            var totalbill = 0;
            var data = DataAccessFactory.BillDataAccess().GetBills(name);
            foreach(var bill in data)
            {
                var getdata = DataAccessFactory.TestDataAccess().Get(bill.TestID);
                totalbill = totalbill + getdata.TestFee;
            }
            var check = DataAccessFactory.PatientAuthCheckerDataAccess().GetChecker(name);
            var patient = new Patient();
            patient.ID = check.ID;  
            patient.Name =check.Name ;
            patient.Email=check.Email;
            patient.Phone=check.Phone;
            patient.Address = check.Address;
            patient.BloodGroup = check.BloodGroup;
            patient.Password = check.Password;
            patient.Disease = check.Disease;
            patient.Dob = check.Dob;
            patient.Bill = totalbill;
            var patientupdateData=DataAccessFactory.PatientDataAccess().Update(patient);
            if (patientupdateData != null)
            {
                return mapper.Map<PatientDTO>(patientupdateData);
            }
            return null;
        }
        public static PatientDTO GetBillsBed(string name)
        {
            var config = Service.Mapping<Patient, PatientDTO>();
            var mapper = new Mapper(config);
            var totalbill = 0;
            var patientData = DataAccessFactory.GetAllotmentOFPatient().GetData(name);
            var bednameData = DataAccessFactory.GetAllotmentOFBed().GetData(patientData.BedID);
            if(bednameData != null)
            {
                totalbill = totalbill + bednameData.BedFee;
                var check = DataAccessFactory.PatientAuthCheckerDataAccess().GetChecker(name);
                var patient = new Patient();
                patient.ID = check.ID;
                patient.Name = check.Name;
                patient.Email = check.Email;
                patient.Phone = check.Phone;
                patient.Address = check.Address;
                patient.BloodGroup = check.BloodGroup;
                patient.Password = check.Password;
                patient.Disease = check.Disease;
                patient.Dob = check.Dob;
                patient.Bill = totalbill;
                var patientupdateData = DataAccessFactory.PatientDataAccess().Update(patient);
                if (patientupdateData != null)
                {
                    return mapper.Map<PatientDTO>(patientupdateData);
                }
            }
            
            return null;
        }
    }
}
