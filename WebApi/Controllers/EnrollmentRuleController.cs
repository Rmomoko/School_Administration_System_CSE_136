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

    public class EnrollmentRuleController : ApiController
    {
        [HttpGet]
        public List<EnrollmentRule> GetEnrollmentRuleList()
        {
            var errors = new List<string>();
            var repository = new EnrollmentRuleRepository();
            var service = new EnrollmentRuleService(repository);
            return service.GetEnrollmentRuleList(ref errors);
        }

        [HttpPost]
        public string InsertEnrollmentRule(EnrollmentRule enrollmentRule)
        {
            var errors = new List<string>();
            var repository = new EnrollmentRuleRepository();
            var service = new EnrollmentRuleService(repository);
            service.InsertEnrollmentRule(enrollmentRule, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string UpdateEnrollmentRule(EnrollmentRule enrollmentRule)
        {
            var errors = new List<string>();
            var repository = new EnrollmentRuleRepository();
            var service = new EnrollmentRuleService(repository);
            service.UpdateEnrollmentRule(enrollmentRule, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeleteEnrollmentRule(EnrollmentRule enrollmentRule)
        {
            var errors = new List<string>();
            var repository = new EnrollmentRuleRepository();
            var service = new EnrollmentRuleService(repository);
            service.DeleteEnrollmentRule(enrollmentRule, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }
    }
}