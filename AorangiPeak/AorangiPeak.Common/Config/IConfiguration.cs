using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AorangiPeak.Common.Config
{
    public interface IConfiguration
    {
        string EmailFromAddress { get; }
        string EmailVerifyAddress { get; }
    }
}
