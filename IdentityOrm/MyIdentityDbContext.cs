using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityOrm;

public class MyIdentityDbContext(DbContextOptions<MyIdentityDbContext> options) : IdentityDbContext<User>(options);