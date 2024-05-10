//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RieltorsAPP.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Document
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Document()
        {
            this.PersonalInformation = new HashSet<PersonalInformation>();
        }
    
        public int Id { get; set; }
        public string Owner { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Nullable<int> Document_for_housing { get; set; }
        public Nullable<int> IdApartment { get; set; }
    
        public virtual Apartments Apartments { get; set; }
        public virtual Report Report { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalInformation> PersonalInformation { get; set; }
    }
}
