using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarworkshop;
using CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops;
using CarWorkshop.Application.CarWorkshop.Queries.GetCarWorkshopByEncodedName;

//using CarWorkshop.Application.Service;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CarWorkshopController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //get method for index view
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var CarWorkshops = await _mediator.Send(new GetAllCarWorkshopsQuery());
            return View(CarWorkshops);
        }

        //return view after create carWoirkshop
        public ActionResult Create()
        {
            return View();
        }

        [Route("CarWorkshop/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));
            return View(dto);
        }





        //[HttpGet]
        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));

            EditCarWorkshopCommand model = _mapper.Map<EditCarWorkshopCommand>(dto);

            return View(model);
        }

        [HttpPost]
        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditCarWorkshopCommand command)
        {
            if (!ModelState.IsValid)    //if model is not valid - temptate of validation is included in CarWorksghopDtoValidator
            {
                return View(command);
            }
            

            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));  //after creating carWorkshop redirect to index view
        }



        //this is the controller for the CarWorkshop entity, Post methods are used to create new CarWorkshop entities
        [HttpPost]
        public async Task<IActionResult> Create(CreateCarWorkshopCommand command)
        {
            if (!ModelState.IsValid)    //if model is not valid - temptate of validation is included in CarWorksghopDtoValidator
            {
                return View(command);
            }

            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));  //after creating carWorkshop redirect to index view
        }
    }
}
