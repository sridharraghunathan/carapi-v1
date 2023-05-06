using System;

namespace core.Dtos
{
    public class CompanyExecutiveTeamDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string Photo { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}