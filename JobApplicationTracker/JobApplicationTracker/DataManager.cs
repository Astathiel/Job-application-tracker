using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
// Necessary Libraries

// Container
namespace JobApplicationTracker
{
    // Static class so it is accessible without instantiation
    public static class DataManager
    {
        // File path for storing the job applications data (Inside the app's exe folder)
        private static readonly string FilePath = "data.json";

        // Method to save the list of job applications to a JSON file (Void runs without returning anything)
        public static void SaveApplications(List<JobApplication> applications)
        {
            // Serialize the list of job applications to a JSON string and write it to the file
            string jsonString = JsonSerializer.Serialize(applications);
            File.WriteAllText(FilePath, jsonString);
        }

        // Reads Data file and returns objects to the program
        public static List<JobApplication> LoadApplications()
        {
            // If file doesn't exist, return an empty list of job applications
            if (!File.Exists(FilePath))
            {
                return new List<JobApplication>();
            }

            // Reads JSON and saves it into a string variable
            string jsonString = File.ReadAllText(FilePath);
            // Translates (Deserializes) the JSON string back into a list of job applications and returns it
            return JsonSerializer.Deserialize<List<JobApplication>>(jsonString) ?? new List<JobApplication>();
            // ?? Safety checks if the deserialization returns null, and if so, it returns a new empty list instead
        }
    }
}