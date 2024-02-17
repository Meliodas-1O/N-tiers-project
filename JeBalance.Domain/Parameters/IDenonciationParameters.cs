using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Parameters
{
    public interface IDenonciationParameters
    {
        int Limit { get; set; }
        int Offset { get; set; }
        string? PaysEvasion { get; set; }
    }
}
