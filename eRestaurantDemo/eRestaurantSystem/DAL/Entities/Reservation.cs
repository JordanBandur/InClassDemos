using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
#endregion


namespace eRestaurantSystem.DAL.Entities
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; } 
        public int NumberInParty { get; set; }
        public string ContactPhone { get; set; }
        public string ReservationStatus { get; set; }
        public string EventCode { get; set; }

        //Navigation properties
        public virtual SpecialEvent Event { get; set; }

        //the Reservations table (sql) is a many to many relationship to the Tables table (sql)
        //sql solves this proble by having an associate table that has a compound primary key
        //created from Reservations and tables

        //we will not be creating an entity for this associate table.
        //instead we will create an overload map in our DbContext class however, we can still
        //create the virtual navigation property to accodmodate this relationship
        public virtual ICollection<Table> Tables { get; set; }
    }
}
