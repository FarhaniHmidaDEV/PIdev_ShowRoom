﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiArt.Data.CustumConventions
{
    public class DateTime2Convention : Convention
    {
        public DateTime2Convention()
        {
            Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));

            Properties<int>().
                Where(p => p.Name.EndsWith("code"))
                .Configure(p => p.IsKey());
        }
    }
}

