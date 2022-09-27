using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Service.EventHandler.Queries
{
    public abstract class TransportBaseQuery
    {
        public int Page { get; set; } = 1;
        public int Take { get; set; } = 25;
    }
}
