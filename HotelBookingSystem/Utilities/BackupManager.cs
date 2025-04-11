using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HotelBookingSystem.Utilities
{
    public static class BackupManager
    {
        public static void Backup<T>(List<T> data, string filename)
        {
            try
            {
                var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filename, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Feil under backup: {ex.Message}");
            }
        }

        public static List<T> Restore<T>(string filename)
        {
            try
            {
                if (!File.Exists(filename))
                {
                    Console.WriteLine($"⚠️ Filen '{filename}' ble ikke funnet.");
                    return new List<T>();
                }

                var json = File.ReadAllText(filename);
                return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Feil under gjenoppretting: {ex.Message}");
                return new List<T>();
            }
        }
    }
}