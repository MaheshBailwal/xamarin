using System;
using System.Data;
using System.IO;
using Xamarin.Forms.PlatformConfiguration;

namespace App2.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsReminderEnabled { get; set; }
        public string Notes { get; set; }
        public int VerbirationDuration { get; set; }
        public int IntervalInMinutes { get; set; }
        public string AudioFileName { get; set; }

        public bool CanViberation { get; set; }
        public bool CanPlayAudio { get; set; }
        public bool CanShowMessage { get; set; }

    }
}