using IdentityModel;
using MatchMe.Identity.Domain.Entities;
using MatchMe.Identity.Infrastructure.EF.Contexts;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace MatchMe.Identity.Infrastructure.EF.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IdentityServerDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(IdentityServerDbContext Db, UserManager<ApplicationUser> UserManager, RoleManager<IdentityRole> RoleManager)
        {
            _db = Db;
            _userManager = UserManager;
            _roleManager = RoleManager;
        }
        public void Initialize()
        {
            if (_roleManager.FindByNameAsync("Admin").Result is null)
            {
                _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("Customer")).GetAwaiter().GetResult();
            }
            else
            {
                return;
            }

            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "919999999",
                FirstName = "Hugo",
                LastName = "Admin"
            };

            _userManager.CreateAsync(adminUser, "Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, "Admin").GetAwaiter().GetResult();

            var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, adminUser.FirstName+" "+adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName, adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, adminUser.LastName),
                new Claim(JwtClaimTypes.Role, "Admin"),
            }).Result;

            ApplicationUser customerUser = new ApplicationUser()
            {
                UserName = "customer@gmail.com",
                Email = "customer@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "919999999",
                FirstName = "Hugo",
                LastName = "Customer"
            };

            _userManager.CreateAsync(customerUser, "Customer123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(customerUser, "Customer").GetAwaiter().GetResult();

            var temp2 = _userManager.AddClaimsAsync(customerUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, customerUser.FirstName+" "+customerUser.LastName),
                new Claim(JwtClaimTypes.GivenName, customerUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, customerUser.LastName),
                new Claim(JwtClaimTypes.Role, "Customer"),
            }).Result;
        }
    }
}
