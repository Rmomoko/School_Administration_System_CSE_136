namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IEnrollmentRuleRepository
    {
        void InsertEnrollmentRule(EnrollmentRule enrollmentRule, ref List<string> errors);

        void UpdateEnrollmentRule(EnrollmentRule enrollmentRule, ref List<string> errors);

        void DeleteEnrollmentRule(EnrollmentRule enrollmentRule, ref List<string> errors);

        List<EnrollmentRule> GetEnrollmentRuleList(ref List<string> errors);
    }
}
