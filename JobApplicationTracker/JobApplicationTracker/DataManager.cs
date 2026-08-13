using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JobApplicationTracker
{
    public static class DataManager
    {
        private static readonly string FilePath = "data.json";

        public static void SaveApplications(List<JobApplication> applications)
        {
            string jsonString = JsonSerializer.Serialize(applications);
            File.WriteAllText(FilePath, jsonString);
        }

        public static List<JobApplication> LoadApplications()
        {
            if (!File.Exists(FilePath))
            {
                return new List<JobApplication>();
            }

            string jsonString = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<JobApplication>>(jsonString) ?? new List<JobApplication>();
        }
    }
}