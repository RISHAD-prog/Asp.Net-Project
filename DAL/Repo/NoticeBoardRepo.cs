using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class NoticeBoardRepo : Repo, IRepo<NoticeBoard, int, NoticeBoard>
    {
        public NoticeBoard Add(NoticeBoard obj)
        {
            db.NoticeBoards.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var data = db.NoticeBoards.Find(id);
            db.NoticeBoards.Remove(data);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<NoticeBoard> Get()
        {
            return db.NoticeBoards.ToList();
        }

        public NoticeBoard Get(int id)
        {
            return db.NoticeBoards.Find(id);
        }

        public NoticeBoard Update(NoticeBoard obj)
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
