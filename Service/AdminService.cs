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

    public class AdminService
    {
        private readonly IAdminRepository repository;

        public AdminService(IAdminRepository repository)
        {
            this.repository = repository;
        }

        public Admin GetAdminInfo(int adminId, ref List<string> errors)
        {
            return this.repository.GetAdminInfo(adminId, ref errors);
        }

        public void UpdateAdminInfo(Admin admin, ref List<string> errors)
        {
            if (admin == null)
            {
                errors.Add("Admin cannot be null");
                throw new ArgumentException();
            }

            this.repository.UpdateAdminInfo(admin, ref errors);
        }
    }
}
