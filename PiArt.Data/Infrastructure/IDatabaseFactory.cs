using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiArt.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {

        PiArtContext DataContext { get; }
    
}
}
