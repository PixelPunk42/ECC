using System;
using System.Collections.Generic;
using System.Text;

namespace ECC
{
    /// <summary>
    /// Contains the basic CRUD operations
    /// </summary>
    class DeviceRepository
    {
        private DeviceContext context;

        public DeviceRepository()
        {
            context = new DeviceContext();
        }

        public Device GetDevice(int id)
        {
            return context.Devices.Find(id);
        }

        public void AddDevice(Device device)
        {
            context.Devices.Add(device);
            context.SaveChanges();
        }

        public void AddDevice(string location, string type, string device_health, string last_used, string price, string color)
        {
            Device device = new Device
            {
                location = location,
                type = type,
                device_health = device_health,
                last_used = last_used,
                price = price,
                color = color
            };
            context.Devices.Add(device);
            context.SaveChanges();
        }

        public void UpdateDevice(Device device)
        {
            context.Devices.Update(device);
            context.SaveChanges();
        }

        /// <summary>
        /// Deletes a device object from the database. 
        /// Note: since the view doesn't update properly after deleting, it is possible to mark the same device 
        /// for deletion again. This will crash the app.
        /// </summary>
        /// <param name="device">the device object to delete</param>
        public void DeleteDevice(Device device)
        {
            /* the following attempt to fix leads to this beauty, needs further:
             * System.InvalidOperationException: 'The instance of entity type 'Device' cannot be tracked 
             * because another instance with the same key value for {'ID'} is already being tracked. 
             * When attaching existing entities, ensure that only one entity instance with a given key value is attached. 
             */
            //if (context.Devices.Find(device.ID) != null)
            //{
                context.Devices.Remove(device);
            //}
            context.SaveChanges();
        }
    }
}
