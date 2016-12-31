using System;
namespace Model
{
    public class MovieSchedule
    {
        public string Id { get; set; } 
        public string MovieId { get; set; } 
        public int ScheduleId { get; set; } 
        public string MovieName { get; set; } 
        public byte MovieDuration { get; set; } 
        public byte MovieTypeId { get; set; } 
        public string MovieTypeName { get; set; } 
        public string ScheduleName { get; set; } 
        public DateTime ScheduleBeginDate { get; set; } 
        public short ScheduleDuration { get; set; } 
    }
}
