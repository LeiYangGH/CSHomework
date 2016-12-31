using System;
namespace Model
{
    public class Discount
    {
        public byte CustomerTypeId { get; set; } 
        public byte DiscountModeId { get; set; } 
        public decimal Number { get; set; } 
        public DateTime StartDateTime { get; set; } 
        public int Duration { get; set; } 
        public string CoustomerTypeName { get; set; } 
        public string DiscountModeName { get; set; } 
    }
}
