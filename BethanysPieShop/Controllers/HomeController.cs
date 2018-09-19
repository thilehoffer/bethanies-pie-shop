using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class HomeController : Controller
    {
        private IPieRepository _pieRepository;
        public HomeController(IPieRepository pieRepository) {
            _pieRepository = pieRepository;
        }

        public ViewResult Index()
        {
            return View(new HomeViewModel { PiesOfTheWeek = _pieRepository.PiesOfTheWeek });
        }
    }
}