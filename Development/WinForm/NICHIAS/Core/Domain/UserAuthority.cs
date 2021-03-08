using System;
using System.Collections.ObjectModel;

namespace NICHIAS.Core.Domain
{
    public class UserAuthority : Base
    {
        #region Fields
        public string Id { get; set; }
        public string UserId { get; set; }
        public GlobalConstants.AuthorityGroupValue AuthorityGroupId { get; set; }
        #endregion
    }
}
