using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        //_________________________________________
        public static IRepo<Doctor, int, Doctor> DoctorDataAccess()
        {
            return new DoctorRepo();
        }
        public static Auth<Doctor,int> DoctorAuthDataAccess()
        {
            return new DoctorRepo();
        }

        public static AuthChecker<Doctor, string> DoctorAuthCheckerDataAccess()
        {
            return new DoctorRepo();
        }
        public static ScheduleChecker<DoctorSchedule, string> DoctorAuthSchCheckerDataAccess()
        {
            return new DoctorScheduleRepo();
        }
        public static QualicationCount<Doctor,string> DoctorQualicationCountDataAccess()
        {
            return new DoctorRepo();
        }
        public static IRepo<DoctorSchedule, int, DoctorSchedule> DoctorScheduleDataAccess()
        {
            return new DoctorScheduleRepo();
        }
        //_______________________________________
        public static IRepo<Patient, int, Patient> PatientDataAccess()
        {
            return new PatientRepo();
        }
        public static Auth<Patient, int> PatientAuthDataAccess()
        {
            return new PatientRepo();
        }

        public static AuthChecker<Patient, string> PatientAuthCheckerDataAccess()
        {
            return new PatientRepo();
        }

        //______________________________________________
        public static IRepo<Admin, int, Admin> AdminDataAccess()
        {
            return new AdminRepo();
        }
        public static Auth<Admin, int> AdminAuthDataAccess()
        {
            return new AdminRepo();
        }

        public static AuthChecker<Admin, string> AdminAuthCheckerDataAccess()
        {
            return new AdminRepo();
        }

        //_____________________________________________
        public static IRepo<Staff, int, Staff> StaffDataAccess()
        {
            return new StaffRepo();
        }
        public static Auth<Staff, int> StaffAuthDataAccess()
        {
            return new StaffRepo();
        }

        public static AuthChecker<Staff, string> StaffAuthCheckerDataAccess()
        {
            return new StaffRepo();
        }

        //__________________________________________________

        public static IRepo<NoticeBoard,int,NoticeBoard> NoticeBoardDataAccess()
        {
            return new NoticeBoardRepo();
        }

        //______________________________________________________
        public static IRepo<Appointment,int,Appointment> AppointmentDataAccess()
        {
            return new AppointmentRepo();
        }
        public static IRepo<Token, string, Token> TokenDataAccess()
        {
            return new TokenRepo();
        }
        public static ErrorReturn Error()
        {
            return new ErrorRepo();
        }
        public static IRepo<TestList,int ,TestList> TestDataAccess()
        {
            return new TestRepo();
        }
        public static IRepo<Labratory,int,Labratory> LabratoryDataAccess()
        {
            return new LabratoryRepo();
        }
        public static ListofID<Appointment,int> NewAppointmentDataAccess()
        {
            return new AppointmentRepo();
        }
        public static BillManagement<Labratory> BillDataAccess()
        {
            return new LabratoryRepo();
        }
        public static ListofID<Bed, int> BedListDataAccess()
        {
            return new BedRepo();
        }
        public static IRepo<PatientCheckUp, int,PatientCheckUp> PatientCheckUpDataAccess()
        {
            return new PatientCheckUpRepo();
        }
        public static IRepo<Medicine, int, Medicine> MedicineDataAccess()
        {
            return new MedicineRepo();
        }
        public static IRepo<BedAllotment, int, BedAllotment> BedAllotmentDataAccess()
        {
            return new BedAllotmentRepo();
        }
        public static IRepo<Bed, int, Bed> BedDataAccess()
        {
            return new BedRepo();
        }
        public static IRepo<BedCategory, int, BedCategory> BedCategoryDataAccess()
        {
            return new BedCategoryRepo();
        }
        public static CheckUp CheckupDataAccess()
        {
            return new PatientCheckUpRepo();
        }
        public static BedCategory<BedCategory> GetBedCategoryDataAccess()
        {
            return new BedCategoryRepo();
        }
        public static Allotment<BedAllotment,string> GetAllotmentOFPatient()
        {
            return new BedAllotmentRepo();
        }
        public static Allotment<Bed, int> GetAllotmentOFBed()
        {
            return new BedRepo();
        }
        //public static IAuth AuthDataAccess()
        //{
        //    return new UserRepo();
        //}
        //public static IRepo<Token, string, Token> TokenDataAccess()
        //{
        //    return new TokenRepo();
        //}
    }
 }
