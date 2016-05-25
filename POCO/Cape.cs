namespace POCO
{
    public class Cape
    {
        public int CourseId { get; set; }

        public string CourseTitle { get; set; }

        public float Easiness { get; set; }

        public float Helpfulness { get; set; }

        public float Clarity { get; set; }

        public float Hours_spend { get; set; }

        public float AvgEasiness { get; set; }

        public float AvgHelpfulness { get; set; }

        public float AvgClarity { get; set; }

        public float AvgHours_spend { get; set; }

        public override string ToString()
        {
            return this.CourseId + "-" + this.AvgEasiness + "-" + this.AvgClarity + "-" + this.AvgHelpfulness + "-" + this.AvgHours_spend;
        }
    }
}