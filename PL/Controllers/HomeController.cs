using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL.DTO;
using BLL.Interfaces;
using PagedList;
using PL.Extenstions;
using PL.Infastructures;
using PL.Models;

namespace PL.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICarService _service;

        public HomeController(ICarService service)
        {
            _service = service;
        }

        public ActionResult Index(int? page, string MarkName, string ModelName, string sort)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            var marksList = _service.GetMarks();
            marksList.Insert(0, new MarkDto{ Name = "Все машины"} );
            ViewBag.Marks = new SelectList(marksList, "Name", "Name");

            ViewBag.SortList = _service.GetSortStatuses();
            ViewBag.SortStatus = sort;

            var carsDto = _service.SortCar(sort);

            var cars = _service.GetCarsList(carsDto , MarkName, ModelName);
            ViewBag.Models = new SelectList(_service.GetModels(), "Name", "Name");
            return View(cars.ToPagedList(pageNumber, pageSize));
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            var marks = new SelectList(_service.GetMarks(), "Name", "Name");
            ViewBag.Marks = marks;
            return View();
        }

        public JsonResult GetModelsByMarkName(string MarkName)
        {
            var models = _service.GetModels().Where(x => x.MarkName == MarkName).ToList();   
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(CarViewModel carViewModel, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                carViewModel.Image = carViewModel.Image = _service.GetCarImage(uploadImage);
                var carDto = carViewModel.ToCarDto();
                _service.AddCar(carDto);

                return RedirectToAction("Index");
            }
            return View(carViewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var carDto = _service.GetCar((int)id);
            var mark = _service.GetModel(carDto.ModelName);
            var car = carDto.ToCarViewModel(mark.MarkName);
            ViewBag.Image = car.Image;
            ViewBag.Mark = car.MarkName;
            
            return View(car);
        }

        [HttpPost]
        public ActionResult Edit(CarViewModel carViewModel, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                carViewModel.Image = _service.GetCarImage(uploadImage);
                var carDto = carViewModel.ToCarDto();

                _service.UpdateCar(carDto);
                
                return RedirectToAction("Index");
            }
            return View(carViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
            base.Dispose(disposing);
        }
    } 
}