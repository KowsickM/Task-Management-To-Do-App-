using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Management_To_Do_App_.DataAccess;
using Task_Management_To_Do_App_.Models;

namespace Task_Management_To_Do_App_.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TodoDbContext _dataAccess;

        public TaskController(TodoDbContext dataAccess)
        {
            _dataAccess = dataAccess;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var Tasks = _dataAccess.TaskTbl.ToList();
                if (Tasks.Count == 0)
                {
                    return NotFound("Tasks Not Found");
                }
                return Ok(Tasks);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var Tasks = _dataAccess.TaskTbl.Find(id);
                if (Tasks == null)
                {
                    return NotFound($"Tasks Not found for this{id}");

                }
                return Ok(Tasks);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost]

        public IActionResult Post(TaskModel Model)
        {
            try
            {
                _dataAccess.TaskTbl.Add(Model);
                _dataAccess.SaveChanges();
                return Ok("Tasks Added");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(TaskModel Model)
        {
            if (Model == null || Model.Id == 0)
            {
                if (Model == null)
                {
                    return BadRequest("Model is Null");
                }
                else if (Model.Id == 0)
                {
                    return BadRequest("Model id is null");
                }
            }
            try
            {
                var Tasks = _dataAccess.TaskTbl.Find(Model.Id);
                Tasks.Title = Model.Title;
                Tasks.Description = Model.Description;
                Tasks.Status = Model.Status;
                Tasks.CreatedAt=Model.CreatedAt;
                _dataAccess.SaveChanges();
                return Ok("Tasks Updated");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Tasks = _dataAccess.TaskTbl.Find(id);
                if (Tasks == null)
                {
                    return NotFound("Tasks Not Found");
                }
                _dataAccess.TaskTbl.Remove(Tasks);
                _dataAccess.SaveChanges();
                return Ok("Tasks Deleted");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }
    }
}
