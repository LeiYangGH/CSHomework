//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSWarehouse
{
    using System;
    using System.Collections.Generic;
    
    public partial class InOut
    {
        public int MID { get; set; }
        public bool IsIn { get; set; }
        public int Quantity { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public int ID { get; set; }
    
        public virtual Material Material { get; set; }
    }
}
