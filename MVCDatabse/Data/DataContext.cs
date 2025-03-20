using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCDatabse.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDatabse.Data;
//add IdentityDbContext and <AppUserEntity>. then generate constructor. sff <DataContet> after dpContextOptions. use primary constructor
public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<AppUserEntity>(options)
{

}
