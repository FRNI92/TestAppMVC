using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDatabse.Entities;

public class AppUserEntity : IdentityUser // Inheris from IdentityUser
{
    [ProtectedPersonalData]//protected will be encrypted. PersonalData will not be encrypted
    public string FirstName { get; set; } = null!;

    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;
}
