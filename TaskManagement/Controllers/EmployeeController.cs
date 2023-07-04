using Microsoft.AspNetCore.Mvc;
using TaskManagement.Models.DBModels;
using TaskManagement.Models.ReqModels;
using TaskManagement.Services;

namespace TaskManagement.Controllers
{

    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly EmpCreationSerivce _empCreationSerivce;

        public EmployeeController(EmpCreationSerivce empCreationSerivce)
        {
            _empCreationSerivce = empCreationSerivce;
        }

        [HttpPost("createEmployee")]

        public ActionResult<List<EmpCreationReq>> CreateEmployee(EmpCreationReq req)
        {
            var createEmp = _empCreationSerivce.CreateEmployee(req);
            if (createEmp != null)
            {
                return Json(createEmp);
            }
            return Json(null);
        }

        [HttpGet("GetAllDesignation")]
        public ActionResult<List<EmpDesignation>> GetDesg()
        {
            var getAllDesg = _empCreationSerivce.GetDesg();
            return Json(getAllDesg);
        }


        [HttpGet("getAllEmployee")]

        public ActionResult<List<EmpDetail>> GetAllEmp()
        {
            var getAll = _empCreationSerivce.GetAllEmp();
            return Json(getAll);
        }


        [HttpDelete("Delete/{id}")]
        public ActionResult<EmpDetail> DeleteEmployee(int id)
        {
            var deleteEmp = _empCreationSerivce.DeleteEmployee(id);
            return Json(deleteEmp);
            // return View(deleteEmp);
        }


        [HttpPut("UpdateEmployee/{id}")]
        public ActionResult<List<EmpCreationReq>> UpdateEmployee(int id, EmpCreationReq updateEmp)
        {
            var update = _empCreationSerivce.UpdateEmployee(id, updateEmp);
            //return View(update);
            return Json(update);
        }

        [HttpGet("{id}")]
        public ActionResult<List<EmpDetail>> GetEmployee(int id)
        {
            var getEmp = _empCreationSerivce.GetEmployee(id);
            return Json(getEmp);
            //return View();
        }
    }
}
