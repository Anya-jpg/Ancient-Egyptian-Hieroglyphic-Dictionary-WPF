//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EgyptianDictionary.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Translation
    {
        public short id { get; set; }
        public Nullable<short> clientId { get; set; }
        public Nullable<short> translatorId { get; set; }
        public string originalText { get; set; }
        public string task { get; set; }
        public string result { get; set; }
        public string clientName { get; set; }
        public string translatorName{ get; set; }

        public virtual Client Client { get; set; }
        public virtual Translator Translator { get; set; }
    }
}
