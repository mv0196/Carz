﻿using System;

namespace Carz.AdvertisementService.Domain.Entities
{
    public class Variant
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string ModelVariant { get; set; }
        public int YearOfManufacturing { get; set; }
        public string Transmission { get; set; }
        public double KmRun { get; set; }
        public DateTime LastService { get; set; }
        public string Color { get; set; }
        public string ChahisNum { get; set; }
        public string RegisteredNum { get; set; }
        public string RegisteredState { get; set; }
        public string RTONum { get; set; }
        public string Category { get; set; }
        public DateTime InsuredTill { get; set; }
    }
}
