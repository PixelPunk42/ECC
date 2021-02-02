using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ECC
{
    /// <summary>
    /// Data model
    /// </summary>
    class Device
    {
        public int ID { get; set; }
        public string location { get; set; }
        public string type { get; set; }
        public string device_health { get; set; }
        public string last_used { get; set; }
        public string price { get; set; }
        public string color { get; set; }
    }
}
