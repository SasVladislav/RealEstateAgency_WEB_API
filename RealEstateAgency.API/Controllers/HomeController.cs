using System;
using System.Web.Http;
using System.Web;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Text;
using System.Xml;
using RealEstateAgency.BLL.Interfaces;
using Ninject;
using RealEstateAgency.API.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.BLL.Infrastuctures;
using System.Collections.Generic;
using RealEstateAgency.BLL.Services.GenericServices;

namespace RealEstateAgency.API.Controllers
{
    public class HomeController : ApiController
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }
        public HomeController()
        {
        }
        [HttpGet]
        public IHttpActionResult GetIndex()
        {
            string url = "http://localhost:51608/api/Address/GetAllAddresses";
            System.Uri uri = new System.Uri(url);
            return Redirect(uri);
            //HttpContext.Current.Response.Write("HelloWorld");
            //using (var ctx = kernel.Get<IdentityDbContext>())
            //{
            //    using (var writer = new XmlTextWriter($@"{AppDomain.CurrentDomain.BaseDirectory}\RealEstateAgencyModel.edmx", Encoding.Default))
            //    {
            //        EdmxWriter.WriteEdmx(ctx, writer);
            //    }
            //}            
        }
        }
}
