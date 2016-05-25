namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IGraduateCourseAppRepository
    {
        void InsertGraduateCourseApp(GraduateCourseApp graduateCourse, ref List<string> errors);

        void UpdateGraduateCourseApp(GraduateCourseApp graduateCourse, ref List<string> errors);

        List<GraduateCourseApp> GetGraduateCourseApp(int scheduleId, ref List<string> errors);

        List<GraduateCourseApp> GetAllGraduateCourseApp(ref List<string> errors);
    }
}
