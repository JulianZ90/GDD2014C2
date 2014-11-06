﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel
{
    public class EstadoReserva
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(Descripcion))
                return "";
            else
                return Descripcion;
        }

        public bool isCancel()
        {
            return Descripcion.Contains("cancelada");
        }
    }
}
