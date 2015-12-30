namespace RealEstate.Rentals
{
    /// <summary>
    /// Class PriceAdjustments.
    /// </summary>
    public class PriceAdjustments
    {
        /// <summary>
        /// Gets or sets the old price.
        /// </summary>
        /// <value>The old price.</value>
        public decimal OldPrice { get; set; }
        /// <summary>
        /// Gets or sets the new price.
        /// </summary>
        /// <value>The new price.</value>
        public decimal NewPrice { get; set; }
        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>The reason.</value>
        public string Reason { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PriceAdjustments"/> class.
        /// </summary>
        /// <param name="adjustPrice">The adjust price.</param>
        /// <param name="oldPrice">The old price.</param>
        public PriceAdjustments(AdjustPrice adjustPrice,decimal oldPrice)
        {
            OldPrice = oldPrice;
            NewPrice = adjustPrice.NewPrice;
            Reason = adjustPrice.Reason;
        }
    }
}