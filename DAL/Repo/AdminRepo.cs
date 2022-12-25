using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Repo
{
    internal class AdminRepo :Repo, IRepo<Admin, int, Admin>,Auth<Admin, int>,AuthChecker<Admin, string>
    {
        public Admin Add(Admin obj)
        {
            db.Admins.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public Admin Authenticate(string email, string password)
        {
            var obj = db.Admins.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));
            return obj;
        }

        public bool Delete(/*Hospital obj*/int id)
        {
            var data = db.Admins.Find(id);
            db.Admins.Remove(data);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Admin Doctors(string name)
        {
            throw new NotImplementedException();
        }

        public List<Admin> Get()
        {
            return db.Admins.ToList();
        }

        public Admin Get(int id)
        {
            return db.Admins.Find(id);
        }

        public Admin GetChecker(string name)
        {
            var obj = db.Admins.FirstOrDefault(x => x.Name.Equals(name));
            return obj;
        }

        public Admin Update(Admin obj)
        {
            var data = Get(obj.ID);
            db.Entry(data).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }
    }
}
