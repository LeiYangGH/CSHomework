using System;
using System.Data.SqlClient;
namespace Model
{
    public class Play
    {
        public string Id { get; set; } 
        public short HallId { get; set; } 
        public DateTime Date { get; set; } 
        public DateTime BeginTime { get; set; } 
        public string MovieScheduleId { get; set; } 
        public string HallName { get; set; } 
        public int LayoutId { get; set; } 
        public string LayoutStyle { get; set; } 
        public string MovieId { get; set; } 
        public string MovieName { get; set; } 
        public byte MovieDuration { get; set; } 
        public byte MovieTypeId { get; set; } 
        public string MovieTypeName { get; set; } 
        public int ScheduleId { get; set; } 
        public string ScheduleName { get; set; } 
        public DateTime ScheduleBeginDate { get; set; } 
        public short ScheduleDuration { get; set; } 
    }
}
