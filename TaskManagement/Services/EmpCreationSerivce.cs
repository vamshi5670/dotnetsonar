using TaskManagement.Models.DBModels;
using TaskManagement.Models.ReqModels;

namespace TaskManagement.Services
{
    public class EmpCreationSerivce
    {
        private readonly TaskManagementContext _context;

        public EmpCreationSerivce(TaskManagementContext context)
        {
            _context = context;
        }


        public List<EmpCreationReq> CreateEmployee(EmpCreationReq req)
        {
            try
            {
                EmpDetail empCreate = new EmpDetail()
                {
                    FirstName = req.FirstName,
                    MiddleName = req.MiddleName,
                    LastName = req.LastName,
                    DesgId = req.DesgId,
                };

                _context.EmpDetails.Add(empCreate);
                _context.SaveChanges();
                return new List<EmpCreationReq> { req };
            }
            catch (Exception ex)
            {
                throw new Exception("Incorrect Details", ex);
            }
        }

        public List<EmpDetail> GetAllEmp()
        {
            var allEmp = _context.EmpDetails.ToList();

            return allEmp;
        }

        public List<EmpDesignation> GetDesg()
        {
            var allDesg = _context.EmpDesignations.ToList() ?? new List<EmpDesignation>();
            return allDesg;
        }

        public List<EmpCreationReq> UpdateEmployee(int id, EmpCreationReq updateEmp)
        {
            try
            {
                var update = _context.EmpDetails.Find(id);
                if (update != null)
                {
                    update.FirstName = updateEmp.FirstName;
                    update.LastName = updateEmp.LastName;
                    update.MiddleName = updateEmp.MiddleName;
                    update.DesgId = updateEmp.DesgId;
                    
                    _context.SaveChanges();

                    return new List<EmpCreationReq>();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to Update", ex);
            }
        }

        public List<EmpDetail> DeleteEmployee(int id)
        {
            var deleteEmp = _context.EmpDetails.Find(id);
            if (deleteEmp != null)
            {
                _context.EmpDetails.Remove(deleteEmp);
                _context.SaveChanges();
                return new List<EmpDetail> { deleteEmp };
            }
            else
            {
                throw new Exception("EmpId is not found");
            }
        }

        public List<EmpDetail> GetEmployee(int id)
        {
            var getEmp = _context.EmpDetails.Find(id);
            return new List<EmpDetail> { getEmp };
        }


    }
}
