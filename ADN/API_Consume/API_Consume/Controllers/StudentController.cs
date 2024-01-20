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
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "GetStudent").Result;
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

        [HttpGet]
        public IActionResult Delete(int StudentID)
        {
            HttpResponseMessage response = _client.DeleteAsync($"{_client.BaseAddress}Delete/{StudentID}").Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Student Deleted Successfully";
            }
            return RedirectToAction("GET");
        }

        [HttpGet]
        public IActionResult AddEdit(int? StudentID)
        {
            StudentModel student = new StudentModel();
            if (StudentID != null)
            {
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "StudentGetByID/" + StudentID).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    dynamic jsonObject = JsonConvert.DeserializeObject<dynamic>(data);
                    var dataOfObject = jsonObject.Data;
                    var extractedDataJson = JsonConvert.SerializeObject(dataOfObject, Formatting.Indented);
                    student = JsonConvert.DeserializeObject<StudentModel>(extractedDataJson);
                }
            }

            return View("StudentAddEdit", student);
        }

        [HttpPost]
        public async Task<IActionResult> Save(StudentModel studentModel)
        {
                try
                {
                    MultipartFormDataContent formData = new MultipartFormDataContent();
                    formData.Add(new StringContent(studentModel.StudentName), "StudentName");
                    formData.Add(new StringContent(studentModel.StudentAge.ToString()), "StudentAge");
                    formData.Add(new StringContent(studentModel.StudentFatherName), "StudentFatherName");
                    formData.Add(new StringContent(studentModel.StudentStandred), "StudentStandred");

                    if (studentModel.StudentID == 0)
                    {
                        HttpResponseMessage response = await _client.PostAsync($"{_client.BaseAddress}Insert", formData);
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("GET");
                        }
                    }
                    else
                    {
                        HttpResponseMessage response = await _client.PutAsync($"{_client.BaseAddress}StudentUpdate/{studentModel.StudentID}", formData);
                        if (response.IsSuccessStatusCode)
                        {
                            ViewBag.StudentID = studentModel.StudentID;
                            return RedirectToAction("GET");
                        }
                    }
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Some Error Occured" + ex.Message;
                }
            return RedirectToAction("GET");
        }
    }
}
