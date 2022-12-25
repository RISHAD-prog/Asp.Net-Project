using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class LabratoryRepo : Repo, IRepo<Labratory, int, Labratory>, BillManagement<Labratory>
    {
        public Labratory Add(Labratory obj)
        {
            db.Labratories.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var data = db.Labratories.Find(id);
            db.Labratories.Remove(data);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Labratory> Get()
        {
            return db.Labratories.ToList();
        }

        public Labratory Get(int id)
        {
            return db.Labratories.Find(id);
        }

        public List<Labratory> GetBills(string name)
        {
            return db.Labratories.Where(X => X.PatientName.Equals(name)).ToList();
        }

        public Labratory Update(Labratory obj)
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
