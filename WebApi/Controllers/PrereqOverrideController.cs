namespace WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;

    public class PrereqOverrideController : ApiController
    {
        [HttpGet]
        public List<PrereqOverride> GetPrereqOverride(int scheduleId)
        {
            var service = new PrereqOverrideService(new PrereqOverrideRepository());
            var errors = new List<string>();

            return service.GetPrereqOverride(scheduleId, ref errors);
        }

        [HttpGet]
        public List<PrereqOverride> GetAllPrereqOverride()
        {
            var service = new PrereqOverrideService(new PrereqOverrideRepository());
            var errors = new List<string>();

            return service.GetAllPrereqOverride(ref errors);
        }

        [HttpPost]
        public string InsertPrereqOverride(PrereqOverride prereq)
        {
            var errors = new List<string>();
            var repository = new PrereqOverrideRepository();
            var service = new PrereqOverrideService(repository);
            service.InsertPrereqOverride(prereq, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string UpdatePrereqOverride(PrereqOverride prereq)
        {
            var errors = new List<string>();
            var repository = new PrereqOverrideRepository();
            var service = new PrereqOverrideService(repository);
            service.UpdatePrereqOverride(prereq, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }
    }
}