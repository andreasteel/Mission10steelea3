using Microsoft.AspNetCore.Mvc;
using Mission9steelea3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9steelea3.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Checkout()
        {
            return View(new Donation());
        }
    }
}
