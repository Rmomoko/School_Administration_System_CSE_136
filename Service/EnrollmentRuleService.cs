namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using IRepository;
    using POCO;

    public class EnrollmentRuleService
    {
        private readonly IEnrollmentRuleRepository repository;

        public EnrollmentRuleService(IEnrollmentRuleRepository repository)
        {
            this.repository = repository;
        }

        public void InsertEnrollmentRule(EnrollmentRule enrollmentRule, ref List<string> errors)
        {
            if (enrollmentRule == null)
            {
                errors.Add("Enrollment rule cannot be null");
                ////throw new ArgumentException();
                return;
            }

            this.repository.InsertEnrollmentRule(enrollmentRule, ref errors);
        }

        public void UpdateEnrollmentRule(EnrollmentRule enrollmentRule, ref List<string> errors)
        {
            if (enrollmentRule == null)
            {
                errors.Add("Enrollment rule cannot be null");
                ////throw new ArgumentException();
                return;
            }

            this.repository.UpdateEnrollmentRule(enrollmentRule, ref errors);
        }

        public void DeleteEnrollmentRule(EnrollmentRule enrollmentRule, ref List<string> errors)
        {
            if (enrollmentRule == null)
            {
                errors.Add("Enrollment rule cannot be null");
                ////throw new ArgumentException();
                return;
            }

            this.repository.DeleteEnrollmentRule(enrollmentRule, ref errors);
        }

        public List<EnrollmentRule> GetEnrollmentRuleList(ref List<string> errors)
        {
            return this.repository.GetEnrollmentRuleList(ref errors);
        }

        /*
        public List<EnrollmentRule> CheckMinUnit(EnrollmentRule enrollmentRule, ref List<string> errors)
        {
            return this.repository.CheckMinUnit(enrollmentRule, ref errors);
        }

        public List<EnrollmentRule> getMaximumUnit(EnrollmentRule enrollmentRule, ref List<string> errors)
        {
            return this.repository.CheckMaxUnit(enrollmentRule, ref errors);
        }
         * */
    }
}
