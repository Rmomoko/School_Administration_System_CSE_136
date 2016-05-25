namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface ICapeRepository
    {
       void InsertCapeData(Cape cape, ref List<string> errors);

        void UpdateCape(Cape cape, int courseId, ref List<string> errors);

        List<Cape> GetCape(ref List<string> errors);
    }
}
