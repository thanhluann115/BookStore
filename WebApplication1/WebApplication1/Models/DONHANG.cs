//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONHANG()
        {
            this.KHACHHANGs = new HashSet<KHACHHANG>();
            this.SANPHAMs = new HashSet<SANPHAM>();
        }
    
        public string MADH { get; set; }
        public string MAGH { get; set; }
        public Nullable<System.DateTime> THOIGIAN { get; set; }
        public string TENKH { get; set; }
        public string SDTKHACHHANG { get; set; }
        public string SOTIEN { get; set; }
        public string SOLUONG { get; set; }
        public Nullable<System.DateTime> NGAYMUAHANG { get; set; }
    
        public virtual GIOHANG GIOHANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHACHHANG> KHACHHANGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }
    }
}