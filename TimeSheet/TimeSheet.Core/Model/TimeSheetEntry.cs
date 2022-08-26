using System;

namespace TimeSheet.Core.Model
{
    public class TimeSheetEntry
    {
        public TimeSheetEntry(int id, int categoryId, int projectId, string description, DateTime date, double time,int? overtime)
        {
            Id = id;
            CategoryId = categoryId;
            ProjectId = projectId;
            Description = description;
            Date = date;
            Time = time;
            Overtime = overtime.GetValueOrDefault();
        }
        public int CategoryId { get; set; }
        public int ProjectId { get; set; }
        public int TeamMemberId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Time { get; set; }
        public int Overtime { get; set; }
        public int Id { get; set; }
    }
}
