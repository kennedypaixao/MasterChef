using MasterChef.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterChef.Web.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult Index()
        {
            //listar();
            return View();
        }

        //public List<RecipeDto> listar()
        //{
        //    return();
        //}

        
    }
}
