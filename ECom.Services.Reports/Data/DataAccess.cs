﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Reports.Data
{
    public class DataAccess
    {
        private static DataAccess _ins;
        public static DataAccess Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new DataAccess();
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }

        public ReportDbContext DB { get; set; }
        private DataAccess()
        {
            DB = new ReportDbContext();
        }
    }
}
