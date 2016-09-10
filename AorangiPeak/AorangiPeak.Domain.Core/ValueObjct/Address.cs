using AorangiPeak.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AorangiPeak.Domain.Core.ValueObjct
{
    /// <summary>
    /// Address Value Object
    /// </summary>
    public class Address : EntityBase
    {
        public string Country;
        public string City;
        public string Suburb;
    }
}
