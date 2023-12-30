using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using APIDemo.DAL;

namespace APIDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : Controller
    {
        SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);

        #region Select All Person
        [HttpGet]
        public IActionResult GetStudent()
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("GetStudentDetails");
                List<StudentModel> student = new List<StudentModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        StudentModel studentModel = new StudentModel();
                        studentModel.StudentID = Convert.ToInt32(dr["StudentID"].ToString());
                        studentModel.StudentName = dr["StudentName"].ToString();
                        studentModel.StudentStandred = dr["StudentStandred"].ToString();
                        studentModel.StudentAge = Convert.ToInt32(dr["StudentAge"].ToString());
                        studentModel.StudentFatherName = dr["StudentFatherName"].ToString();
                        student.Add(studentModel);
                    }
                }
                Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
                if (student.Count > 0 && student != null)
                {
                    data.Add("status", true);
                    data.Add("message", "Data Found.");
                    data.Add("Data", student);
                    return Ok(data);
                }
                else
                {
                    data.Add("status", false);
                    data.Add("message", "Data Not Found.");
                    data.Add("Data", null);
                    return NotFound(data);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Student GetBy ID
        [HttpGet("{StudentID}")]
        public IActionResult StudentGetByID(int StudentID)
        {
            try
            {
                DbCommand command = sqlDatabase.GetStoredProcCommand("GetStudentByPK");
                sqlDatabase.AddInParameter(command, "@StudentID", SqlDbType.Int, StudentID);
                StudentModel student = new StudentModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(command))
                {
                    while (dr.Read())
                    {
                        student.StudentID = Convert.ToInt32(dr["StudentID"].ToString());
                        student.StudentName = dr["StudentName"].ToString();
                        student.StudentStandred = dr["StudentStandred"].ToString();
                        student.StudentAge = Convert.ToInt32(dr["StudentAge"].ToString());
                        student.StudentFatherName = dr["StudentFatherName"].ToString();
                    }
                }
                Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
                if (student.StudentID != 0)
                {
                    data.Add("status", true);
                    data.Add("message", "Data Found.");
                    data.Add("Data", student);
                    return Ok(data);
                }
                else
                {
                    data.Add("status", false);
                    data.Add("message", "Data Not Found.");
                    data.Add("Data", null);
                    return NotFound(data);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Student Insert
        [HttpPost]
        public IActionResult Insert([FromForm] StudentModel studentModel)
        {
            try
            {
                DbCommand command = sqlDatabase.GetStoredProcCommand("InsertStudent");
                sqlDatabase.AddInParameter(command, "@StudentName", SqlDbType.VarChar, studentModel.StudentName);
                sqlDatabase.AddInParameter(command, "@StudentAge", SqlDbType.Int, studentModel.StudentAge);
                sqlDatabase.AddInParameter(command, "@StudentStandred", SqlDbType.VarChar, studentModel.StudentStandred);
                sqlDatabase.AddInParameter(command, "@StudentFatherName", SqlDbType.VarChar, studentModel.StudentFatherName);
                Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(command)))
                {
                    data.Add("status", true);
                    data.Add("message", "Record Inserted Successfully");
                    return Ok(data);
                }
                else
                {
                    data.Add("status", false);
                    data.Add("message", "Some Error has been Occured");
                    return Ok(data);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Student Update
        [HttpPut("{StudentID}")]
        public IActionResult StudentUpdate(int StudentID, [FromForm] StudentModel studentModel)
        {
            try
            {
                DbCommand command = sqlDatabase.GetStoredProcCommand("UpdateStudent");
                sqlDatabase.AddInParameter(command, "@StudentID", SqlDbType.Int, StudentID);
                sqlDatabase.AddInParameter(command, "@NewStudentName", SqlDbType.VarChar, studentModel.StudentName);
                sqlDatabase.AddInParameter(command, "@NewStudentAge", SqlDbType.Int, studentModel.StudentAge);
                sqlDatabase.AddInParameter(command, "@NewStudentStandred", SqlDbType.VarChar, studentModel.StudentStandred);
                sqlDatabase.AddInParameter(command, "@NewStudentFatherName", SqlDbType.VarChar, studentModel.StudentFatherName);
                Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(command)))
                {
                    data.Add("status", true);
                    data.Add("message", "Data Updated Successfully");
                    return Ok(data);
                }
                else
                {
                    data.Add("status", false);
                    data.Add("message", "Some Error has been Occured");
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Student Delete
        [HttpDelete("{StudentID}")]
        public IActionResult Delete(int StudentID)
        {
            try
            {
                DbCommand command = sqlDatabase.GetStoredProcCommand("DeleteStudent");
                sqlDatabase.AddInParameter(command, "@StudentID", SqlDbType.Int, StudentID);
                Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(command)))
                {
                    data.Add("status", true);
                    data.Add("message", "Data Deleted Successfully");
                    return Ok(data);
                }
                else
                {
                    data.Add("status", false);
                    data.Add("message", "Some Error has been Occured");
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            #endregion
        }
    }
}
