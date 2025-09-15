﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSimFT.Models
{
    public class UnitOfLength
    {
        public static UnitOfLength Kilometers = new UnitOfLength(1.0);
        public static UnitOfLength Miles = new UnitOfLength(0.621371);
        public static UnitOfLength NauticalMiles = new UnitOfLength(0.539957);

        private readonly double _fromKilometersFactor;

        private UnitOfLength(double fromKilometersFactor)
        {
            _fromKilometersFactor = fromKilometersFactor;
        }

        public double ConvertFromKilometers(double input)
        {
            return input * _fromKilometersFactor;
        }
    }
}
