using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace FrbaHotel
{
    class Factura
    {
        SqlConnection connect = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);

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
        public decimal totalAPagar { get; set; }

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

            totalAPagar = items.Sum(item => item.importe());
        }

        public decimal total()
        {
            return this.totalAPagar;
        }

        public void insert() 
        {
            SqlCommand query = new SqlCommand("insert into GAME_OF_QUERYS.factura (fecha, medio_de_pago, reserva_id, tarjeta, total) values(@fecha, @medio, @reserva_id, @tarjeta, @total); SELECT SCOPE_IDENTITY()", connect);
            query.Parameters.AddWithValue("fecha", fecha);
            query.Parameters.AddWithValue("medio", medios_de_pagos);
            query.Parameters.AddWithValue("reserva_id", reserva.Id);
            query.Parameters.AddWithValue("tarjeta", tarjeta);
            query.Parameters.AddWithValue("total", totalAPagar);

            connect.Open();
            int factura_id = Convert.ToInt32(query.ExecuteScalar());
            foreach (Item i in items)
            {
                query = new SqlCommand("insert into GAME_OF_QUERYS.item (factura_id,cant,descripcion,precio) values (@factura_id, @cant, @desc, @precio)", connect);
                query.Parameters.AddWithValue("factura_id",factura_id);
                query.Parameters.AddWithValue("cant", i.cant);
                query.Parameters.AddWithValue("desc", i.desc);
                query.Parameters.AddWithValue("precio", i.precio);
                query.ExecuteNonQuery();
            }
            connect.Close();


        }
    }
}
