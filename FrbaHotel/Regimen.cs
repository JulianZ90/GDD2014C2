﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel
{
    class Regimen
    {
        public int id { get; set; }
        public decimal precio_base { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
    }
}