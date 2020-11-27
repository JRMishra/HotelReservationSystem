using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationSystemDALayer
{
    class ReservationContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
    }
}
