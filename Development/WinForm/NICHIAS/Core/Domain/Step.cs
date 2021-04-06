using System;
using System.Collections.ObjectModel;

namespace NICHIAS.Core.Domain
{
    public class Step : Base
    {
        #region Fields
        public int Id { get; set; }
        public string StepName { get; set; }
        /*
        1. Cuốn tròn		
        2. Sấy khô		
        3. Mài thô -thổi		
        4. Làm mát ngâm		
        5. Nung		
        6. Làm cứng bằng		
        7. Mài sau làm cứng + thổi		
        8. Sơn 2 mặt + sấy		
        9. Kiểm tra		
         */
        #endregion
    }
}
