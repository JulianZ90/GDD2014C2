﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel
{
    class Factura
    {
        public class Item
        {
            public int cant { get; set; }
            public string desc { get; set; }
            public decimal precio { get; set; }  
      
            public decimal importe()
            {
                return cant*precio;
            }
        }

        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string detalles { get; set; }
        public string medios_de_pagos { get; set; }
        public Reserva reserva { get; set; }
        public List<Item> items { get; set; }
        public long tarjeta { get; set; }

        public Factura(Reserva r) 
        {
            reserva = r;
            this.items = new List<Item>();

            foreach (Habitacion hab in reserva.Habitaciones)
            {
                Item item = new Item();
                item.cant = 1;
                item.desc = string.Format("Habitación {0}",hab.Tipo.ToString());

                ///// CALCULO DE PRECIO DE HABITACION
                item.precio = (reserva.Regimen.precio_base * hab.Tipo.Porcentual) + (reserva.hotel.cantidad_estrella * reserva.hotel.recarga_estrella);
                
                items.Add(item);
            }

            decimal importeConsumiblesTotal = 0;
            foreach (consumible con in reserva.consumibles)
            {
                Item item = new Item();
                item.cant = con.cantidad;
                item.desc = con.descripcion;
                item.precio = con.precio;

                importeConsumiblesTotal += item.precio * item.cant;

                items.Add(item);
            }

            if (reserva.Regimen.esAllInclusive())
            {
                Item item = new Item();
                item.cant = 1;
                item.desc = "Descuento por régimen All Incluive";
                item.precio = -importeConsumiblesTotal;
                items.Add(item);
            }
        }

        public decimal total()
        {
            return items.Sum(item => item.importe());
        }

        public void insert() { }
    }
}