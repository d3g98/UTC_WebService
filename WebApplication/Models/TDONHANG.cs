//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TDONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TDONHANG()
        {
            this.TDONHANGCHITIETs = new HashSet<TDONHANGCHITIET>();
        }
    
        public string ID { get; set; }
        public Nullable<int> LOAI { get; set; }
        public string NAME { get; set; }
        public Nullable<System.DateTime> NGAY { get; set; }
        public string DKHACHHANGID { get; set; }
        public string DNHACUNGCAPID { get; set; }
        public string DKHUYENMAIID { get; set; }
        public Nullable<decimal> TIENHANG { get; set; }
        public Nullable<decimal> TILEGIAMGIA { get; set; }
        public Nullable<decimal> TIENGIAMGIA { get; set; }
        public Nullable<decimal> TONGCONG { get; set; }
        public Nullable<decimal> TIENTHANHTOAN { get; set; }
        public Nullable<int> TRANGTHAI { get; set; }
        public string GHICHU { get; set; }
        public string TENNGUOINHAN { get; set; }
        public string DIACHI { get; set; }
        public string DIENTHOAI { get; set; }
        public string DTINHTHANHID { get; set; }
        public string DQUANHUYENID { get; set; }
        public string DPHUONGXAID { get; set; }
        public Nullable<int> HINHTHUCTHANHTOAN { get; set; }
        public Nullable<int> DATHANHTOAN { get; set; }
    
        public virtual DKHACHHANG DKHACHHANG { get; set; }
        public virtual DNHACUNGCAP DNHACUNGCAP { get; set; }
        public virtual DPHUONGXA DPHUONGXA { get; set; }
        public virtual DQUANHUYEN DQUANHUYEN { get; set; }
        public virtual DTINHTHANH DTINHTHANH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TDONHANGCHITIET> TDONHANGCHITIETs { get; set; }
    }
}
