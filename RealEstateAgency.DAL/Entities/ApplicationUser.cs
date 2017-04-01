using Microsoft.AspNet.Identity.EntityFramework;

namespace RealEstateAgency.DAL.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public virtual Person Person { get; set; }
    }
}
