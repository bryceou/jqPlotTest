using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace jqPlotTest.Controllers
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class DataInputController : Controller
    {
        // GET: DataInput
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult GetStudents()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student() { Name = "lucy", Age = 20 });
            students.Add(new Student() { Name = "jack", Age = 22 });
            students.Add(new Student() { Name = "lili", Age = 20 });
            students.Add(new Student() { Name = "tom", Age = 24 });

            List<object> result = ToChartArray<Student>(students, nameof(Student.Name), nameof(Student.Age));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public List<object> ToChartArray<T>(List<T> list, string xPropertyName, string yPropertyName)
        {
            List<object> seriesData = new List<object>();
            if (list == null || list.Count == 0 || string.IsNullOrEmpty(xPropertyName) || string.IsNullOrEmpty(yPropertyName))
                return seriesData;

            try
            {
                Type type = typeof(T);
                PropertyInfo firstProperty = type.GetProperties().FirstOrDefault(p => p.Name == xPropertyName);
                PropertyInfo secondProperty = type.GetProperties().FirstOrDefault(p => p.Name == yPropertyName);
                if (firstProperty == null || secondProperty == null) return seriesData;

                object firstPropertyValue;
                object secondPropertyValue;
                List<Array> oneSerieData = new List<Array>();
                foreach (T item in list)
                {
                    firstPropertyValue = firstProperty.GetValue(item);
                    secondPropertyValue = secondProperty.GetValue(item);
                    oneSerieData.Add(new dynamic[] { firstPropertyValue, secondPropertyValue });
                }
                seriesData.Add(oneSerieData);
            }
            catch
            {
            }
            return seriesData;
        }
    }
}