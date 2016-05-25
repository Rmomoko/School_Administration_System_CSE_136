namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;

    public class AdminController : ApiController
    {
        [HttpGet]
        public Admin GetAdminInfo(int adminId)
        {
            var service = new AdminService(new AdminRepository());
            var errors = new List<string>();

            return service.GetAdminInfo(adminId, ref errors);
        }

        [HttpPost]
        public string UpdateAdminInfo(Admin admin)
        {
            var errors = new List<string>();
            var repository = new AdminRepository();
            var service = new AdminService(repository);
            service.UpdateAdminInfo(new Admin() { Id = admin.Id, FirstName = admin.FirstName, LastName = admin.LastName }, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }
    }
}