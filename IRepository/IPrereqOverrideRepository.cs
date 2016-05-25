namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IPrereqOverrideRepository
    {
        void InsertPrereqOverride(PrereqOverride prereq, ref List<string> errors);

        void UpdatePrereqOverride(PrereqOverride prereq, ref List<string> errors);

        List<PrereqOverride> GetPrereqOverride(int scheduleId, ref List<string> errors);

        List<PrereqOverride> GetAllPrereqOverride(ref List<string> errors);
    }
}
