﻿using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface Appointment<CLASS,RET>
    {
        List<CLASS> GetDoctorId(int id);
        
    }
}
