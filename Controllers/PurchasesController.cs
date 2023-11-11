using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Basic_Project.Models;

namespace Basic_Project.Controllers
{
    public class PurchasesController : Controller
    {
        private readonly InventoryManagementContext _dbcontext;

        public PurchasesController(InventoryManagementContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        public IActionResult Add_Purchase()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add_Purchase(Purchase purch)
        {
            try
            {
                if (purch != null)
                {
                    _dbcontext.Purchases.Add(purch);
                    _dbcontext.SaveChanges();
                    ViewBag.SMESSAGE = "Purchase Added Successfully";
                }
                else
                {
                    ViewBag.EMESSAGE = "Some Error Occured Please Try Again....!";
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

        public IActionResult Detail_Purchase(int id)
        {


            return View(_dbcontext.Purchases.Find(id));
        }

        [HttpGet]

        public IActionResult Delete_Purchase(int id)
        {
            try
            {
                Purchase purch = _dbcontext.Purchases.Find(id);

                if (purch != null)
                {

                    _dbcontext.Purchases.Remove(purch);
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
            return RedirectToAction("Display_Purchase");
        }


        [HttpGet]

        public IActionResult Update_Purchase(int id)
        {
            ViewBag.SMessage = TempData["SMessage"];
            ViewBag.EMessage = TempData["EMessage"];

            return View(_dbcontext.Purchases.Find(id));
        }
        [HttpPost]

        public IActionResult Update_Purchase(Purchase purch)
        {

            try
            {
                if (purch != null)
                {
                    _dbcontext.Purchases.Update(purch);
                    _dbcontext.SaveChanges();
                    TempData["SMessage"] = "Purchase Updated Successfully.";
                }
                else
                {

                    TempData["SMessage"] = "Purchase Not Found.";
                }


            }
            catch (Exception ex)
            {
                TempData["EMessage"] = "Some Error Occured Please Try Again...!";
            }


            return RedirectToAction("Display_Purchase");
        }

        [HttpGet]

        public IActionResult Display_Purchase()
        {
            //var lCategories = _dbcontext.ItemCategories.ToList();
            ViewBag.SMESSAGE = TempData["SMessage"];
            ViewBag.EMESSAGE = TempData["EMessage"];
            var LCategories = _dbcontext.Purchases.ToList();
            return View(LCategories);
        }



    }
}
