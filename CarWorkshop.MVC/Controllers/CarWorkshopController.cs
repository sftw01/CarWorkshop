﻿using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly ICarWorkshopService _carWorkshopService;

        public CarWorkshopController(ICarWorkshopService carWorkshopService)
        {
            _carWorkshopService = carWorkshopService;
        }

        //return view after create carWoirkshop
        public ActionResult Create()
        {
            return View();
        }

        //this is the controller for the CarWorkshop entity, Post methods are used to create new CarWorkshop entities
        [HttpPost]
        public async Task<IActionResult> Create(CarWorkshopDto carWorkshop)
        {
            await _carWorkshopService.Create(carWorkshop);

            return RedirectToAction(nameof(Create)); //TODO: refactor
        }

    }
}
