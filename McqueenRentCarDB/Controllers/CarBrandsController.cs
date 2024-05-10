using McqueenRentCarDB.Models;
using McqueenRentCarDB.Utility;
using Microsoft.AspNetCore.Mvc;

namespace McqueenRentCarDB.Controllers
{
    public class CarBrandsController : Controller
    {
        private readonly UygulamaDbContext _uygulamaDbContext;

        public CarBrandsController(UygulamaDbContext context)
        {
            _uygulamaDbContext = context;
        }

        public IActionResult Index()
        {
            List<CarBrands> objCarBrandsList = _uygulamaDbContext.Car_Brand.ToList();
            return View(objCarBrandsList);
        }

        public IActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBrand(CarBrands carBrands)
        {
            if (ModelState.IsValid)
            {
                _uygulamaDbContext.Car_Brand.Add(carBrands);
                _uygulamaDbContext.SaveChanges();
                TempData["Succeed"] = "Brand added successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult UpdateBrand(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            CarBrands carbrandDb = _uygulamaDbContext.Car_Brand.Find(id);
            if (carbrandDb == null)
            {
                return NotFound();
            }
            return View(carbrandDb);
        }

        [HttpPost]
        public IActionResult UpdateBrand(CarBrands carBrands)
        {
            if (ModelState.IsValid)
            {
                _uygulamaDbContext.Car_Brand.Update(carBrands);
                _uygulamaDbContext.SaveChanges();
                TempData["Succeed"] = "Brand update successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult DeleteBrand(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            CarBrands carbrandDb = _uygulamaDbContext.Car_Brand.Find(id);
            if (carbrandDb == null)
            {
                return NotFound();
            }
            return View(carbrandDb);
        }

        [HttpPost, ActionName("DeleteBrand")]
        public IActionResult DeleteBrandPOST(int? id)
        {
            CarBrands? carBrands = _uygulamaDbContext.Car_Brand.Find(id);
            if(carBrands == null)
            {
                return NotFound() ; 
            }
            _uygulamaDbContext.Car_Brand.Remove(carBrands);
            _uygulamaDbContext.SaveChanges();
            TempData["Succeed"] = "Brand remove successfully";
            return RedirectToAction("Index");
        }
    }
}
