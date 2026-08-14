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
        // Define the base path, folder path, and file path for storing the JSON data
        private static readonly string BasePath = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string FolderPath = Path.Combine(BasePath, "Applications");
        private static readonly string FilePath = Path.Combine(FolderPath, "data.json");

        // Method to save the list of job applications to a JSON file (Void runs without returning anything)
        public static void SaveApplications(List<JobApplication> applications)
        {
            // Check if the Applications folder exists, and if not, create it
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

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