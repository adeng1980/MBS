using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineMovieTicketBookingProject.Data;
using OnlineMovieTicketBookingProject.Models;

namespace OnlineMovieTicketBookingProject.Controllers
{
    [Authorize(Roles ="Admin,user")]
    public class CartTController : Controller
    {

        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _usermanager;

        public CartTController(ApplicationDbContext context, UserManager<ApplicationUser> usermanager)
        {

            _context = context;
            _usermanager = usermanager;
        }
        public IActionResult Index()
        {
            var item = _context.Cart.Where(a => a.UserId == _usermanager.GetUserId(HttpContext.User)).ToList();
            return View(item);
        }
        [HttpGet]
        public IActionResult cartEmpty()
        {
            TempData["cartempty"] = "Empty Cart";
            return View();
        }
        [HttpGet]
        public IActionResult proceed(Cart cart)
        {
            var CartList = _context.Cart.Where(a => a.UserId == _usermanager.GetUserId(HttpContext.User)).ToList();
            if (CartList.Count == 0)
            {

                return RedirectToAction("cartEmpty", "CartT");

            }
            else
            {

                return View(CartList);
            }
        }

        public IActionResult BookTicket(Cart cart)
        {
            List<BookingTable> bt = new List<BookingTable>();
            var CartList = _context.Cart.Where(a => a.UserId == _usermanager.GetUserId(HttpContext.User)).ToList();
            foreach (var item in CartList)
            {
                bt.Add(new BookingTable { Datetopresent = item.date, MovieDetailsId = item.MovieId, seatno = item.seatno, UserId = item.UserId, Amount = item.Amount });

            }
            foreach (var item in bt)
            {
                _context.BookingTable.Add(item);
                _context.SaveChanges();
            }
            if (cart!=null)
            {
                var itemList = _context.Cart.Where(a => a.UserId == _usermanager.GetUserId(HttpContext.User)).ToList();
                foreach (var item in itemList)
                {
                    _context.Cart.Remove(item);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var item = _context.Cart.Where(a => a.Id == Id).SingleOrDefault();
            return View(item);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCartItem(int Id)
        {
            var item = _context.Cart.Where(a => a.Id == Id).SingleOrDefault();
            _context.Cart.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index", "CartT");
        }
        
    }
}