//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityCoches
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehiculo()
        {
            this.CompraVentas = new HashSet<CompraVenta>();
        }
    
        public int Id { get; set; }
        public int Marca { get; set; }
        public int Modelo { get; set; }
        public int Color { get; set; }
        public int npuertas { get; set; }
        public int km { get; set; }
        public string Tipo { get; set; }
        public int Garantia { get; set; }
        public string urlFotografia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompraVenta> CompraVentas { get; set; }
    }
}
