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

    public class GraduateCourseAppController : ApiController
    {
        [HttpGet]
        public List<GraduateCourseApp> GetGraduateCourseApp(int scheduleId)
        {
            var service = new GraduateCourseAppService(new GraduateCourseAppRepository());
            var errors = new List<string>();

            return service.GetGraduateCourseApp(scheduleId, ref errors);
        }

        [HttpGet]
        public List<GraduateCourseApp> GetAllGraduateCourseApp()
        {
            var service = new GraduateCourseAppService(new GraduateCourseAppRepository());
            var errors = new List<string>();

            return service.GetAllGraduateCourseApp(ref errors);
        }

        [HttpPost]
        public string InsertGraduateCourseApp(GraduateCourseApp graduateCourseApp)
        {
            var errors = new List<string>();
            var repository = new GraduateCourseAppRepository();
            var service = new GraduateCourseAppService(repository);
            service.InsertGraduateCourseApp(graduateCourseApp, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string UpdateGraduateCourseApp(GraduateCourseApp graduateCourseApp)
        {
            var errors = new List<string>();
            var repository = new GraduateCourseAppRepository();
            var service = new GraduateCourseAppService(repository);
            service.UpdateGraduateCourseApp(graduateCourseApp, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }
    }
}
