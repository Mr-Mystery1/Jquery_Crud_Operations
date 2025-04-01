using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JQueryCrud.Models;
using JQueryCrud.Data;

namespace JQueryCrud.Controllers;

public class HomeController : Controller
{
    private readonly DataAccessLayer dal;
    public HomeController()
    {
        dal = new DataAccessLayer();
        
    }
    public IActionResult Index()
    {
        return View();
    }
    public JsonResult Display()
    {
        List<Employee> emp = dal.getAllEmployees();
        return Json(emp);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create([FromBody] Employee emp)
    {
        try
        {
            dal.AddEmployee(emp);
            return Json(new {success= true,message="Employee added"});
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message }); // ✅ Return error message
        }

    }

    

    public JsonResult Update(int id)
    {
        var data = dal.getEmployeeById(id);
        return new JsonResult(data);
    }

    [HttpPost]
    public IActionResult Update([FromBody] Employee emp)
    {
        try
        {
            dal.UpdateEmployee(emp);
            return Json(new { success = true, message = "Employee updated" });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message }); // ✅ Return error message
        }

    }
    //public IActionResult Update(Employee emp)
    //{
    //    try
    //    {
    //        dal.UpdateEmployee(emp);
    //        return RedirectToAction("Index");
    //    }
    //    catch
    //    {
    //        return View();
    //    }

    //}

    [HttpPost]
    public JsonResult Delete(int id)
    {
        try
        {
            dal.DeleteEmployee(id);
            return Json("Deleted");
        }
        catch
        {
            return Json("Error occurred");
        }
    }

    
}
