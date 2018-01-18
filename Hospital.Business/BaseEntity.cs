using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}
