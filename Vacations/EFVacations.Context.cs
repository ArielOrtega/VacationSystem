﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vacations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EntitiesVacation : DbContext
    {
        public EntitiesVacation()
            : base("name=EntitiesVacation")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Day> Day { get; set; }
        public virtual DbSet<Departament> Departament { get; set; }
        public virtual DbSet<HoliDays> HoliDays { get; set; }
        public virtual DbSet<Payroll> Payroll { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Person1> Person1 { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<VacationInfo> VacationInfo { get; set; }
    }
}