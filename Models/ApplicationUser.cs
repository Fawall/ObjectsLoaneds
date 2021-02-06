using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectsLoaneds.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<ObjectsLoanedModel> ObjectsLoaneds { get; set; }
        
        
    }
}
