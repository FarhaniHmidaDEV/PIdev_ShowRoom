using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiArt.Data.Infrastructure
{
    public class DatabaseFactory: Disposable, IDatabaseFactory
    {
        
        private PiArtContext dataContext;
        public PiArtContext DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new PiArtContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }
}

