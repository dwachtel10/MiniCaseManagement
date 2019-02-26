//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CaseManagementv4Code.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CaseDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CaseDetail()
        {
            this.Charges = new HashSet<Charge>();
        }
    
        public int DetailsID { get; set; }
        public int CaseID { get; set; }
        public string DefendantLastName { get; set; }
        public string DefendantFirstName { get; set; }
        public string DefendantAddress { get; set; }
        public string DefendantCity { get; set; }
        public string DefendantState { get; set; }
    
        public virtual CaseMaster CaseMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Charge> Charges { get; set; }
    }
}