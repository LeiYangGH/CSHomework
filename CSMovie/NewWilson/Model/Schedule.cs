using System;
namespace Model
{
    public class Schedule
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public DateTime BeginDate { get; set; } 
        public short Duration { get; set; } 
    }
}
