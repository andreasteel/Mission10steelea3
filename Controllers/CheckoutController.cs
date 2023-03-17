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
        private IDonationRepository repo { get; set; }
        private Basket basket { get; set; }
        public CheckoutController (IDonationRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Donation());
        }

        [HttpPost]
        public IActionResult Checkout(Donation donation)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }
            if (ModelState.IsValid)
            {
                donation.Lines = basket.Items.ToArray();
                repo.SaveDonation(donation);
                basket.ClearBasket();

                return RedirectToPage("/CheckoutCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
