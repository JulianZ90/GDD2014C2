using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel
{
    class Factura
    {
        class Item
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

        public Factura(Reserva r) 
        {
            reserva = r;

            foreach (Habitacion hab in reserva.Habitaciones)
            {
                Item item = new Item();
                item.cant = 1;
                item.desc = string.Format("Habitación {1}",hab.Tipo.ToString());

                ///// CALCULO DE PRECIO DE HABITACION
                item.precio = (reserva.Regimen.precio_base * hab.Tipo.Porcentual) + (reserva.hotel.cantidad_estrella * reserva.hotel.recarga_estrella);
            }

            decimal importeConsumiblesTotal = 0;
            foreach (consumible con in reserva.consumibles)
            {
                Item item = new Item();
                item.cant = con.cantidad;
                item.desc = con.descripcion;
                item.precio = con.precio;

                importeConsumiblesTotal += item.precio * item.cant;
            }

            if (reserva.Regimen.esAllInclusive())
            {
                Item item = new Item();
                item.cant = 1;
                item.desc = "Descuento por régimen All Incluive";
                item.precio = -importeConsumiblesTotal;
            }




            //detalles en limpio
            
            detalles = "";
            detalles += string.Format("{0} {1}.....................{2}:{3}", reserva.Cliente.nombre, reserva.Cliente.apellido, reserva.Cliente.tipo_identidad.ToString(), reserva.Cliente.nro_identidad, Environment.NewLine);
            detalles += string.Format("{0} {1} {2} {3} {4}", reserva.Cliente.calle, reserva.Cliente.nro_calle, reserva.Cliente.piso, reserva.Cliente.depto, reserva.Cliente.ciudad, Environment.NewLine);

            detalles += string.Format("cant.\t\tDesc.\t\tPrecio unit.\t\tImporte", Environment.NewLine);

            foreach (Item i in items)
            {
                detalles += string.Format("{0}\t\t{1}\t\t{2}\t\t{3}",i.cant, i.desc, i.precio, i.importe(),  Environment.NewLine);
            }

            detalles += string.Format("                     Total $   {0}", total(), Environment.NewLine);
        }

        private decimal total()
        {
            return items.Sum(item => item.importe());
        }
    }
}
