using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    [Route("api/[controller]")]
    public class PieDataController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public PieDataController(IPieRepository pieRepository) {
            _pieRepository = pieRepository;
        }

        [HttpGet] 
        public IEnumerable<PieViewModel> LoadMorePies()
        { 
            IEnumerable<Pie>  dbPies = _pieRepository.Pies.OrderBy(p => p.PieId).Take(10); 
            List<PieViewModel> pies = new List<PieViewModel>();
            return dbPies.Select(s => MapDbPieToPieViewModel(s)); 
        }

        private PieViewModel MapDbPieToPieViewModel(Pie dbPie)
        {
            return new PieViewModel()
            {
                PieId = dbPie.PieId,
                Name = dbPie.Name,
                Price = dbPie.Price,
                ShortDescription = dbPie.ShortDescription,
                ImageThumbnailUrl = dbPie.ImageThumbnailUrl
            };
        }
    }
}