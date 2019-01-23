﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.Models
{
    public class EmployeeDetailContext :DbContext
    {
        public EmployeeDetailContext(DbContextOptions<EmployeeDetailContext> options  ): base(options)
        {

        }
       public DbSet<EmployeeDetail> employeeDetails { get; set; }
    }
}
