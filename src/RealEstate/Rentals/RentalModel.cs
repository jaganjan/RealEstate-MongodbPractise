using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RealEstate.Rentals
{
    /// <summary>
    /// Class RentalModel.
    /// </summary>
    public class RentalModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the numberof rooms.
        /// </summary>
        /// <value>The numberof rooms.</value>
        public int NumberofRooms { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [BsonRepresentation(BsonType.Double)]
        public decimal Price { get; set; }

        /// <summary>
        /// The address
        /// </summary>
        public List<string> Address = new List<string>();
        public List<PriceAdjustments> Adjustments=new List<PriceAdjustments>(); 
        public RentalModel()
        {
            
        }
        public RentalModel(PostRental postRental)
        {
            Price = postRental.Price;
            NumberofRooms = postRental.NumberofRooms;
            Description = postRental.Desription;
            Address = (postRental.Address ?? string.Empty).Split('\n').ToList();
        }

        public void AdjustPrice(AdjustPrice adjustprice)
        {
            var adjustment=new PriceAdjustments(adjustprice,Price);
            Adjustments.Add(adjustment);
            Price = adjustprice.NewPrice;
        }
    }

    public class PostRental
    {
        public string Desription { get; set; }
        public int NumberofRooms { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
    }

    public class AdjustPrice
    {
        public decimal NewPrice { get; set; }
        public string Reason { get; set; }
    }
}