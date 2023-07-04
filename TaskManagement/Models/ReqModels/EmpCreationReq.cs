namespace TaskManagement.Models.ReqModels
{
    public class EmpCreationReq
    {

        public int EmpId { get; set; }

        public string FirstName { get; set; } = null!;

        public string? MiddleName { get; set; }

        public string LastName { get; set; } = null!;

        public int? DesgId { get; set; }

    }
}
