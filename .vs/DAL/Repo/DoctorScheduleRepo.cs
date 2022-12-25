using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class DoctorScheduleRepo : Repo, IRepo<DoctorSchedule, int, DoctorSchedule>
    {
        public DoctorSchedule Add(DoctorSchedule obj)
        {
            db.DoctorSchedules.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var data = db.DoctorSchedules.Find(id);
            db.DoctorSchedules.Remove(data);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<DoctorSchedule> Get()
        {
            return db.DoctorSchedules.ToList();
        }

        public DoctorSchedule Get(int id)
        {
            return db.DoctorSchedules.Find(id);
        }

        public DoctorSchedule Update(DoctorSchedule obj)
        {
            var data = Get(obj.Id);
            db.Entry(data).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }
    }
}
