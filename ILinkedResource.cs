using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contozoo
{
    public interface ILinkedResource
    {
        IDictionary<LinkedResourceType, LinkedResource> Links { get; set; }
    }
}
