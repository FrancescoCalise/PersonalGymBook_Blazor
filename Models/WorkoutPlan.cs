using System;
using System.Collections.Generic;

namespace PersonalGymBook.Models
{
    public class WorkoutPlan
    {
        public Guid Id { get; set; }
        public int TotalDays { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Notes { get; set; }
        public List<Exercise> Exercises { get; set; }
    }

    public class Exercise
    {
        public string Name { get; set; }
        public string MuscleGroup { get; set; }
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public int RestTime { get; set; }
        public string Notes { get; set; }
        public int Day { get; set; }
    }
}
