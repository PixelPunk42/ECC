using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace ECC
{
    /// <summary>
    /// Seeds the contents of a JSON file to the database
    /// </summary>
    public static class DbSeed
    {
        private static readonly string filePath = "ECC.Resources.data.json";
        public static void Create()
        {
            List<Device> devices = GetDeviceListFromJSON();
            using (var context = new DeviceContext())
            {
                context.Devices.AddRange(devices.ToArray());
                context.SaveChanges();
            }
        }

        private static List<Device> GetDeviceListFromJSON()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (StreamReader reader = new StreamReader(assembly.GetManifestResourceStream(filePath)))
            {
                string json = reader.ReadToEnd();
                return JsonSerializer.Deserialize<List<Device>>(json);
            }
        }
    }
}
