//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Person
    {
        public int personaId { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public int identification { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public System.DateTime createdAt { get; set; }
        public System.DateTime updatedAt { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }
        public int PayrollRolId { get; set; }
    }
}
