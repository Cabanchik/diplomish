//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace diplomish
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            this.file = new HashSet<file>();
            this.task = new HashSet<task>();
            this.task1 = new HashSet<task>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public Nullable<System.DateTime> birth_date { get; set; }
        public byte[] user_pic { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Nullable<int> gender_id { get; set; }
        public Nullable<int> role_id { get; set; }
        public Nullable<int> branch_id { get; set; }
        public Nullable<int> company_id { get; set; }
    
        public virtual branch branch { get; set; }
        public virtual company company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<file> file { get; set; }
        public virtual gender gender { get; set; }
        public virtual role role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<task> task { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<task> task1 { get; set; }
    }
}
