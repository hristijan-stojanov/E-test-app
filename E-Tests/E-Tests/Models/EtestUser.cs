using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tests.Models
{
    public class EtestUser: IdentityUser
    {
        public string FirstName { set; get; }
        public string FastName { set; get; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}
