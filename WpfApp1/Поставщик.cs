//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Поставщик
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Поставщик()
        {
            this.История_поставок = new HashSet<История_поставок>();
            this.Продукция = new HashSet<Продукция>();
        }
    
        public int ID_Поставщика { get; set; }
        public string Наименование { get; set; }
        public string Тип_поставщика { get; set; }
        public string ИНН { get; set; }
        public string Рейтинг_качества { get; set; }
        public Nullable<System.DateTime> Дата_начала_работы_с_поставщиком { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<История_поставок> История_поставок { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Продукция> Продукция { get; set; }
    }
}
