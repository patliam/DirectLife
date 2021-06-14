using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectLife.Infrastructure
{
    public class TillException : Exception
    {
        public TillException( string message ) : base(message)
        {
        }
    }
}
