using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Basic_Project.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Basic_Project.Controllers
{
    public class SalesController : Controller
    {
        private readonly InventoryManagementContext _dbcontext;

        
        public SalesController(InventoryManagementContext context)
        {
            _dbcontext = context;
        }
        [HttpGet]
        public IActionResult Add_Sale()
        {
            ViewBag.SMeesage = TempData["SMessage"];
            ViewBag.EMessage = TempData["EMessage"];
            ViewBag.ListItems = _dbcontext.Products.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add_Sale(Sale obj)
        {
            try
            {
                int Bis_Id = 29;
                int P_Id = 31;

                Product Bis = _dbcontext.Products.Find(29);
                Product Para = _dbcontext.Products.Find(31);

                if(obj.SaleProduct==Bis.ProductName)
                {
                    Bis = Bis.ProductQnty - obj.SaleQnty;
                    _dbcontext.Products.Update(Bis);
                   
                    _dbcontext.Sales.Add(obj);
                    _dbcontext.SaveChanges();

                }
                else if(obj.SaleProduct==Para.ProductName)
                {
                    Para = Para.ProductQnty - obj.SaleQnty;
                    _dbcontext.Products.Update(Bis);
                    
                    _dbcontext.Sales.Add(obj);
                    _dbcontext.SaveChanges();
                }
               
                return View();

            }
            catch (Exception ex)
            {
                ViewBag.EMESSAGE = "Some Error Occured Please Try Agin Later....!";
                return View();
            }

        }

        [HttpGet]

        public IActionResult Detail_Sale(int id)
        {


            return View(_dbcontext.Sales.Find(id));
        }

        [HttpGet]

        public IActionResult Delete_Sale(int id)
        {
            try
            {
                Sale obj = _dbcontext.Sales.Find(id);

                if (obj != null)
                {
                    _dbcontext.Sales.Remove(obj);
                    _dbcontext.SaveChanges();
                    TempData["SMessage"] = "Data Updated Successfully";


                }
                else
                {
                    TempData["EMessage"] = "Data Not Found...!";
                }

            }
            catch (Exception ex)
            {
                TempData["EMessage"] = "Data Not Found...!";

            }
            return RedirectToAction("Display_Sale");
        }


        [HttpGet]

        public IActionResult Update_Sale(int id)
        {
            ViewBag.SMessage = TempData["SMessage"];
            ViewBag.EMessage = TempData["EMessage"];

            return View(_dbcontext.Sales.Find(id));
        }
        [HttpPost]

        public IActionResult Update_Sale(Sale obj)
        {

            try
            {
                if (obj != null)
                {
                    _dbcontext.Sales.Update(obj);
                    _dbcontext.SaveChanges();
                    TempData["SMessage"] = "Sale Updated Successfully.";
                }
                else
                {

                    TempData["SMessage"] = "Sale Not Found.";
                }


            }
            catch (Exception ex)
            {
                TempData["EMessage"] = "Some Error Occured Please Try Again...!";
            }


            return RedirectToAction("Display_Sale");
        }

        [HttpGet]

        public IActionResult Display_Sale()
        {
            ViewBag.SMESSAGE = TempData["SMessage"];
            ViewBag.EMESSAGE = TempData["EMessage"];
            var LCategories = _dbcontext.Sales.ToList();
            return View(LCategories);
        }


    }

    



}

