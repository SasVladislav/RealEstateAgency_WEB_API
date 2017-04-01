using Microsoft.AspNet.Identity.EntityFramework;

namespace RealEstateAgency.DAL.Entities
{
    public class ApplicationRole:IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name) { }
    }
}
