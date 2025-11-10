using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using TaskManagement_To_Do_Api_.Models;

namespace TaskManagement_To_Do_Api_.Controllers
{
    public class TaskController : Controller
    {
        Uri api = new Uri("https://localhost:7265/api");
        private readonly HttpClient _client;

        public TaskController()
        {
            _client = new HttpClient();
            _client.BaseAddress = api;
        }
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public IActionResult List(string status, string search)
        {
            List<TaskModel> TaskList = new List<TaskModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Task/Get").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                TaskList = JsonConvert.DeserializeObject<List<TaskModel>>(data);
            }

            
            if (!string.IsNullOrEmpty(status))
            {
                if (Enum.TryParse<TaskManagement_To_Do_Api_.Models.TaskStatus>(status, out var parsedStatus))
                {
                    TaskList = TaskList.Where(t => t.Status == parsedStatus).ToList();
                }
            }


            if (!string.IsNullOrEmpty(search))
            {
                TaskList = TaskList
                    .Where(t => t.Title != null && t.Title.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            ViewBag.SelectedStatus = status;
            ViewBag.SearchQuery = search;
            return View(TaskList);
        }

        [HttpGet]
        public IActionResult CreateTasks()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CreateTasks(TaskModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Task/Post", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = "Task Created!" });
                }
                else
                {
                    return Json(new { success = false, message = "Failed to add task." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        

        public IActionResult EditTasks(int id)
        {
            try
            {
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Task/Get/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    var model = JsonConvert.DeserializeObject<TaskModel>(data);
                    return Json(model); 
                }
                return Json(new { error = "Task not found" });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }


        [HttpPost]
        public IActionResult EditTasks(TaskModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Task/Put", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = "Task Updated!" });
                }
                else
                {
                    return Json(new { success = false, message = "Failed to Update task." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }




       

        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Task/Delete/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                return Json(new { success = true, message = "Task deleted successfully!" });
            }

            return Json(new { success = false, message = "Failed to delete the task." });
        }




    }
}
