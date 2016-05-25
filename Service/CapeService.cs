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

    public class CapeService
    {
        private readonly ICapeRepository repository;

        public CapeService(ICapeRepository repository)
        {
            this.repository = repository;
        }

        public void InsertCapeData(Cape cape, ref List<string> errors)
        {
            if (cape == null)
            {
                errors.Add("Cape cannot be null");
                //// throw new ArgumentException();
                return;
            }

         

            string strRegex = @"[^0-9]";
            Regex re = new Regex(strRegex);
            var flag = re.IsMatch(cape.CourseId.ToString());


            this.repository.InsertCapeData(cape, ref errors);
        }

        public void UpdateCape(Cape cape, int courseId, ref List<string> errors)
        {
            if (cape == null)
            {
                errors.Add("Cape cannot be null");
                throw new ArgumentException();
            }

            if (courseId <= 0)
            {
                errors.Add("Invalid course id");
                throw new ArgumentException();
            }

            this.repository.UpdateCape(cape, courseId, ref errors);
        }

        public List<Cape> GetCape(ref List<string> errors)
        {
            return this.repository.GetCape(ref errors);
        }

        public float CalculateCapeEasiness(int courseId, List<Cape> cape, ref List<string> errors)
        {
            if (courseId <= 0)
            {
                errors.Add("Invalid course id");
                ////   throw new ArgumentException();
                return 0.00f;
            }

            if (cape == null)
            {
                errors.Add("Invalid cape");
                ////   throw new ArgumentException();
                return 0.00f;
            }

            if (cape.Count == 0)
            {
                return 0.0f;
            }

            var easinessSum = 0.0f;

            foreach (var capeData in cape)
            {
                easinessSum += capeData.Easiness;
            }

            return easinessSum / cape.Count;
        }

        public float CalculateCapeHelpfulness(int courseId, List<Cape> cape, ref List<string> errors)
        {
            if (courseId <= 0)
            {
                errors.Add("Invalid course id");

                ////throw new ArgumentException();
                return 0.00f;
            }

            if (cape == null)
            {
                errors.Add("Invalid cape");
                ////   throw new ArgumentException();
                return 0.00f;
            }

            if (cape.Count == 0)
            {
                return 0.0f;
            }

            var helpfulnessSum = 0.0f;

            foreach (var capeData in cape)
            {
                helpfulnessSum += capeData.Helpfulness;
            }

            return helpfulnessSum / cape.Count;
        }

        public float CalculateCapeClarity(int courseId, List<Cape> cape, ref List<string> errors)
        {
            if (courseId <= 0)
            {
                errors.Add("Invalid course id");
                ////   throw new ArgumentException();
                return 0.00f;
            }

            if (cape == null)
            {
                errors.Add("Invalid cape");
                ////   throw new ArgumentException();
                return 0.00f;
            }

            if (cape.Count == 0)
            {
                return 0.0f;
            }

            var claritySum = 0.0f;

            foreach (var capeData in cape)
            {
                claritySum += capeData.Clarity;
            }

            return claritySum / cape.Count;
        }

        public float CalculateCapeHoursSpend(int courseId, List<Cape> cape, ref List<string> errors)
        {
            if (courseId <= 0)
            {
                errors.Add("Invalid course id");
                ////   throw new ArgumentException();
                return 0.00f;
            }

            if (cape == null)
            {
                errors.Add("Invalid cape");
                ////   throw new ArgumentException();
                return 0.00f;
            }

            if (cape.Count == 0)
            {
                return 0.0f;
            }

            var hours_spendSum = 0.0f;

            foreach (var capeData in cape)
            {
                hours_spendSum += capeData.Hours_spend;
            }

            return hours_spendSum / cape.Count;
        }
    }
}
