//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NosesService.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserSession
    {
        public int Id { get; set; }
        public string sessio_code { get; set; }
        public System.DateTime start_time { get; set; }
        public System.DateTime last_use { get; set; }
        public bool allowed { get; set; }
        public Nullable<int> user_id { get; set; }
    
        public virtual User User { get; set; }
    }
}
