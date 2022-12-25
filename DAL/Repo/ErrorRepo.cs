using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class ErrorRepo : ErrorReturn
    {
        public string error()
        {
            return "Data is already inserted";
        }
    }
}
