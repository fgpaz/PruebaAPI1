using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CustomException : Exception
    {
        public string? Details { get; set; }
        public int StatusCode { get; set; }
    }
}
