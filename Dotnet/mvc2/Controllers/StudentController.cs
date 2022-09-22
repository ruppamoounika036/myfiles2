using Microsoft.AspNetCore.Mvc;
namespace mvc.Controllers;

public class StudentController : Controller
{
   public ActionResult Index()
    {
        IList<Student> studentList = new List<Student>();
        studentList.Add(new Student(){ StudentName = "Bill" });
        studentList.Add(new Student(){ StudentName = "Steve" });
        studentList.Add(new Student(){ StudentName = "Ram" });

        ViewData["students"] = studentList;
        ViewData["Header"] = "Student Details";
        return View();
    }
}
