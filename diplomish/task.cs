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
    
    public partial class task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public task()
        {
            this.file = new HashSet<file>();
        }
    
        public int id { get; set; }
        public string title { get; set; }
        public Nullable<System.DateTime> purpose_time { get; set; }
        public Nullable<System.DateTime> start_time { get; set; }
        public string annotation { get; set; }
        public Nullable<System.DateTime> end_time { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> status_id { get; set; }
        public Nullable<int> brach_id { get; set; }
        public Nullable<int> initiator_id { get; set; }
        public Nullable<byte> is_deleted { get; set; }
    
        public virtual branch branch { get; set; }
        public virtual status status { get; set; }
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<file> file { get; set; }
    }
}
