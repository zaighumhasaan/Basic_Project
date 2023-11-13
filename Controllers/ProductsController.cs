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
    public class ProductsController : Controller
    {
        private readonly InventoryManagementContext _dbcontext;

        public ProductsController(InventoryManagementContext context)
        {
            _dbcontext = context;
        }
      
        [HttpGet]
        public IActionResult Add_Product()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add_Product(Product product)
        {
            try
            {
                if (product != null)
                {
                    _dbcontext.Products.Add(product);
                    _dbcontext.SaveChanges();
                    ViewBag.SMESSAGE = "Product Added Successfully";
                }
                else
                {
                    ViewBag.EMESSAGE = "Some Error Occured Please Try Again....!";
                }

                return View();

            }
            catch (Exception ex)
            {
                ViewBag.EMESSAGE = "Drug Added Successfully";
                return View();
            }
            
        }

        [HttpGet]

        public IActionResult Detail_Product(int id)
        {
           

            return View(_dbcontext.Products.Find(id));
        }

        [HttpGet]

        public IActionResult Delete_Product(int id)
        {
            try
            {
                Product product = _dbcontext.Products.Find(id);

                if (product != null)
                {

                    _dbcontext.Products.Remove(product);
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
            return RedirectToAction("Display_Products");
        }


        [HttpGet]

        public IActionResult Update_Product(int id)
        {
            ViewBag.SMessage = TempData["SMessage"];
            ViewBag.EMessage = TempData["EMessage"];

            return View(_dbcontext.Products.Find(id));
        }
        [HttpPost]

        public IActionResult Update_Product(Product product)
        {

            try
            {
                if(product!=null)
                {
                    _dbcontext.Products.Update(product);
                    _dbcontext.SaveChanges();
                    TempData["SMessage"] = "Product Updated Successfully.";
                }
                else
                {

                    TempData["SMessage"] = "Product Not Found.";
                }
                

            }
            catch (Exception ex)
            {
                TempData["EMessage"] = "Some Error Occured Please Try Again...!";
            }


            return RedirectToAction("Display_Products");
        }

        [HttpGet]

        public IActionResult Display_Products()
        {
            //var lCategories = _dbcontext.ItemCategories.ToList();
            ViewBag.SMESSAGE = TempData["SMessage"];
            ViewBag.EMESSAGE = TempData["EMessage"];
            var LCategories = _dbcontext.Products.ToList();
            return View(LCategories);
        }

        public IActionResult Cards()
        {
            //Drug drug = _dbcontext.Drugs.Find(15);

            //IList<ViewDrugs> OlistDrugs = (from drug in _dbcontext.Drugs.Where(d=>d.Quantity>0)
            //                               //from cat in _dbcontext.DrugCategories.Where(m => m.drug.Quantity >= 10)
            //                               select new ViewDrugs
            //                               {
            //                                   DrugId =drug.DrugId,
            //                                   Quantity = drug.Quantity,
            //                                   DrugName = drug.DrugName,

            //                                   ScientificName = !string.IsNullOrWhiteSpace(drug.ScientificName) ? drug.ScientificName : "",


            //                               }).ToList();

            ////ViewBag.no_of_min_drugs = OlistDrugs.Count();
            //String json = JsonConvert.SerializeObject(drug);


            return View();
        }
       public IActionResult Fresh_Stock()
        {

            var fresh_stock = _dbcontext.Products.Where(p => p.MfgDate <= DateTime.Now.AddDays(10)).ToList();

                return View(fresh_stock);
            
            


        }
        public IActionResult Get_Min_Stock()
        {
           

            //  lCategories = _dbcontext.ItemCategories.Where(o => o.CatLevel !=1).ToList();

            var minstock = _dbcontext.Products.Where(p => p.ProductQnty <=15).ToList();

            int count = minstock.Count();
            if (count == null)
            {
                count = 0;
            }

            return Ok(count);

        }

        [HttpGet]
        public IActionResult Low_stock()
        {


            //  lCategories = _dbcontext.ItemCategories.Where(o => o.CatLevel !=1).ToList();

            var minstock = _dbcontext.Products.Where(p => p.ProductQnty <= 15).ToList();

            int count = minstock.Count();

            if (count !=0)
            {
                return View(minstock);
            }
            else
            {
                return View(minstock);
            }

           

        }

        public IActionResult Near_To_Expire()
        {
            
            var today = DateTime.Now.AddMonths(1);
            var near_to_exp = _dbcontext.Products.Where(p => p.ExpDate <= today).ToList();
          
            int count = near_to_exp.Count();
            //.Where(u => u.OffDate <= DateTime.Now);
            if(count==null)
            {
                count = 0;
                return Ok(count);
            }
            else
            {
                return Ok(count);
            }
           
        }
        [HttpGet]

        public IActionResult About_To_Expire()
        {
            var today = DateTime.Now.AddMonths(1);
            var near_to_exp = _dbcontext.Products.Where(p => p.ExpDate <= today).ToList();
            int count = near_to_exp.Count();
            if (count != 0)
            {
                return View(near_to_exp);
            }
            else
            {

                return View(near_to_exp);
            }


        }

        public IActionResult Expired()
        {

          

            var today = DateTime.Now;
            var expired = _dbcontext.Products.Where(p => p.ExpDate <= today).ToList();
            int count = expired.Count();
            if(count==null)
            {
                count = 0;
            }



            return Ok(count);
        }

        [HttpGet]
        public IActionResult Expired_Products()
        {

            var today = DateTime.Now;
            var expired_products = _dbcontext.Products.Where(p => p.ExpDate <= today).ToList();
            int count = expired_products.Count();
            if (count != 0)
            {
                return View(expired_products);
            }
            else
            {
                
                return View(expired_products);
            }

        }

    }
}
