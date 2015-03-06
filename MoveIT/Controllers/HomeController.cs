using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MoveIT.Models;

namespace MoveIT.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new MoveInfoViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(MoveInfoViewModel model)
        {
            
            Mapper.CreateMap<MoveInfoViewModel, PriceInfoViewModel>()
                .ForMember(x => x.OffNo, opt => opt.Ignore())
                .ForMember(x => x.EstimatedPrice, opt => opt.Ignore())
                .ForMember(x => x.Link, opt => opt.Ignore());

            var piModel = Mapper.Map<MoveInfoViewModel, PriceInfoViewModel>(model);

            return this.RedirectToAction("PricePresentation", "Home", piModel);
        }

        [HttpGet]
        public ActionResult OldView(PriceInfoViewModel model)
        {
            Mapper.CreateMap<PriceInfoViewModel, MoveInfoViewModel>();
            MoveInfoViewModel m = Mapper.Map<PriceInfoViewModel, MoveInfoViewModel>(model);
            return View("Index",m);
        }

        [HttpPost]
        public ActionResult OldView(MoveInfoViewModel model)
        {

            Mapper.CreateMap<MoveInfoViewModel, PriceInfoViewModel>()
                .ForMember(x => x.OffNo, opt => opt.Ignore())
                .ForMember(x => x.EstimatedPrice, opt => opt.Ignore())
                .ForMember(x => x.Link, opt => opt.Ignore());

            var piModel = Mapper.Map<MoveInfoViewModel, PriceInfoViewModel>(model);

            return this.RedirectToAction("PricePresentation", "Home", piModel);
        }

        [HttpGet]
        public ActionResult PricePresentation(PriceInfoViewModel model)
        {
            model = GetOffer(model);
            return View(model);
        }

        public PriceInfoViewModel GetOffer(PriceInfoViewModel model)
        {
            model.EstimatedPrice = GetPriceBasedOnDistance(model.Distance);
            model.EstimatedPrice = GetPriceBasedOnArea(model.MainArea, model.ExtraArea, model.EstimatedPrice);
            model.EstimatedPrice = (model.Piano) ? model.EstimatedPrice + 5000 : model.EstimatedPrice;
            return model;
        }


        public int GetPriceBasedOnDistance(int distance)
        {
            if (distance < 50)
            {
                return 1000 + (10*distance);
            }
            if (distance >= 50 && distance < 100)
            {
                return 5000 + (8*distance);
            }
            return 10000 + (7*distance);
        }

        public int GetPriceBasedOnArea(int mainArea, int extraArea, int currentPrice)
        {
            var totArea = mainArea + (2*extraArea);
            int cars = 1; // = (totArea + 50 - 1)/50; //dubbelkolla
            while (totArea >= 50)
            {
                cars++;
                totArea -= 50;
            }
            return currentPrice*cars;
        }

    }
}