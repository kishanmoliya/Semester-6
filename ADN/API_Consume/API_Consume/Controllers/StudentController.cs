using API_Consume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API_Consume.Controllers
{
    public class StudentController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:13279/api/Student/");
        private readonly HttpClient _client;
        public StudentController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            return RedirectToAction("GET");
        }

        [HttpGet]
        public IActionResult GET()
        {
            List<StudentModel> students = new List<StudentModel>();
            HttpResponseMessage response = _client.GetAsync(baseAddress + "GetStudent").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                dynamic jsonObject = JsonConvert.DeserializeObject<dynamic>(data);
                var dataOfObject = jsonObject.Data;
                var extractedDataJson = JsonConvert.SerializeObject(dataOfObject, Formatting.Indented);
                students = JsonConvert.DeserializeObject<List<StudentModel>>(extractedDataJson);
            }
            return View("StudentList", students);
        }

        [HttpDelete]
        public IActionResult Delete(int StudentID)
        {
            HttpResponseMessage response = _client.GetAsync(baseAddress + "Delete/" + StudentID).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Student Deleted Successfully";
            }
            return RedirectToAction("GET");
        }
    }
}
