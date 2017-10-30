using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiArt.Domain.Entities
{
    [DefaultValue(On_Hold)]
    public enum State
    {
        Accepted , 
        Refused  , 
        On_Hold   
    }
   
}
