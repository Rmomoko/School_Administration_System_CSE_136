namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;

    public class CapeController : ApiController
    {
        [HttpGet]
        public List<Cape> GetCape()
        {
            var service = new CapeService(new CapeRepository());
            var errors = new List<string>();

            //// we could log the errors here if there are any...
            return service.GetCape(ref errors);
        }

        [HttpPost]
        public string InsertCapeData(Cape cape)
        {
            var errors = new List<string>();
            var repository = new CapeRepository();
            var service = new CapeService(repository);
            service.InsertCapeData(cape, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string UpdateCape(Cape cape, int courseId)
        {
            var errors = new List<string>();
            var repository = new CapeRepository();
            var service = new CapeService(repository);
            service.UpdateCape(cape, courseId, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }
    }
}