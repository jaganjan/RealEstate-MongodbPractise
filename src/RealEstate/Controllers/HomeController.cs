using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using RealEstate.DbContext;
using RealEstate.Rentals;

namespace RealEstate.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRealEstateDbContext _dbContext;

        public HomeController(IRealEstateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult About()
        {
          
            return View();
        }
        public  IActionResult Index()
        {
            var filter=new BsonDocument();
            var rentals =  _dbContext.RentalsCollection.Find(filter).ToEnumerable();
            return View(rentals);
        }

      
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult PostRental()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PostRental(PostRental postrental)
        {
            var rental=new RentalModel(postrental);
            _dbContext.RentalsCollection.InsertOne(rental);

            return RedirectToAction("Index");
        }

        public IActionResult AdjustPrice(string id)
        {
            var rentals = GetRentals(id);
            return View(rentals);
        }

        private RentalModel GetRentals(string id)
        {
            var rentals = _dbContext.RentalsCollection.Find(t => t.Id == id).SingleOrDefault();
            return rentals;
        }
        [HttpPost]
        public IActionResult AdjustPrice(string id,AdjustPrice adjustprice)
        {
            //var rentals = GetRentals(id);
            //rentals.AdjustPrice(adjustprice);
            //var filter = new BsonDocument(rentals.ToBsonDocument());
            //var update = Builders<BsonDocument>.Update.Set("Price", rentals.Price);
            //var rental = _dbContext.RentalsCollection.UpdateOne(f => f.Id == id, rentals);
            return View();
            //return View(rentals);
        }
    }
}
