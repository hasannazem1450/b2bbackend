using B2B.Framework.Contracts.Abstracts;
using B2B.Framework.Contracts.Common.Enums;

namespace B2B.Domain.ProductBase
{
    public class Product : Entity<int>
    {
        public Product()
        {
        }

        public int SmeProfileId { get; protected set; }
        public string Title { get; protected set; }

        public string Name { get; protected set; }
        public string Brand { get; protected set; }
        public string Model { get; protected set; }
        public StandardType StandardType { get; protected set; }
        public string StandardIssuer { get; protected set; }
        public string Usage { get; protected set; }
        public string MadeIn { get; protected set; }
        //todo
        public string ShippingMethod { get;protected set; }
        public string SampleAmount { get;protected set; }
        public bool FreeSample { get; protected set; }
        public string CustomizationDescription { get; protected set; }
        public string PaymentDescription { get; protected set; }
        public string FactorBasedOn { get; protected set; }
        public string MinimumOrderDesc { get; protected set; }
        public int GetReadyDays { get; protected set; }
        public string BuildMethod { get; protected set; }
        public string RawMaterials { get; protected set; }
        public string SupplyCapacity { get; protected set; }
        public string Dimensions { get; protected set; }
        public string Weight { get; protected set; }
        public string PackagingDimensions { get; protected set; }
        public string PackagingWeight { get; protected set; }
        public string PackagingType { get; protected set; }
        public string Description { get; protected set; }
        public string MainPhoto { get; protected set; }
    }
}
