using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TestRepo : Repo, IRepo<TestList, int, TestList>
    {
        public TestList Add(TestList obj)
        {
            db.TestLists.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var data = db.TestLists.Find(id);
            db.TestLists.Remove(data);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<TestList> Get()
        {
            return db.TestLists.ToList();
        }

        public TestList Get(int id)
        {
            return db.TestLists.Find(id);
        }

        public TestList Update(TestList obj)
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
