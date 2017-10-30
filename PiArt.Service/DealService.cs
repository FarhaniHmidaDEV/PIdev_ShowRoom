using PiArt.Data.Infrastructure;
using PiArt.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiArt.Service
{
    public class DealService: Service<Deal> , IDealService
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utk = new UnitOfWork(dbf);


        public DealService() : base(utk)
        {
        }
    }
}
