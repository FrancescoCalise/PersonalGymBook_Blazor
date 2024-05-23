using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using PersonalGymBook.Models;

namespace PersonalGymBook.Services
{
    public class WorkoutService
    {
        private readonly string _storagePath;

        public WorkoutService()
        {
            _storagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WorkoutPlans");
            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }
        }

        public async Task SaveWorkoutPlanAsync(WorkoutPlan plan)
        {
            string filePath = Path.Combine(_storagePath, $"{plan.Id}.json");
            var json = JsonSerializer.Serialize(plan);
            await File.WriteAllTextAsync(filePath, json);
        }

        public async Task<WorkoutPlan> GetWorkoutPlanAsync(Guid id)
        {
            string filePath = Path.Combine(_storagePath, $"{id}.json");
            if (!File.Exists(filePath)) return null;
            var json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<WorkoutPlan>(json);
        }

        public async Task<IEnumerable<WorkoutPlan>> GetAllWorkoutPlansAsync()
        {
            var plans = new List<WorkoutPlan>();
            var files = Directory.GetFiles(_storagePath, "*.json");
            foreach (var file in files)
            {
                var json = await File.ReadAllTextAsync(file);
                plans.Add(JsonSerializer.Deserialize<WorkoutPlan>(json));
            }
            return plans;
        }
    }
}
