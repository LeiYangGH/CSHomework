using System;
namespace Model
{
    public class Ticket
    {
        public int PositionId { get; set; } 
        public byte CustomerTypeId { get; set; } 
        public decimal SellPrice { get; set; } 
        public DateTime SellDateTime { get; set; } 
        public string PlayId { get; set; } 
        public string ScheduleName { get; set; } 
        public int Scheduleid { get; set; } 
        public string MovieName { get; set; } 
        public string MovieId { get; set; } 
        public DateTime PlayDate { get; set; } 
        public DateTime PlayBeginTime { get; set; } 
        public short HallId { get; set; } 
        public string HallName { get; set; } 
        public int RowNum { get; set; } 
        public int ColNum { get; set; } 
        public string PositionTypeName { get; set; } 
        public byte PositionTypeId { get; set; } 
    }
}
