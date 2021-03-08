using System;
using System.Collections.ObjectModel;

namespace NICHIAS.Core.Domain
{
    public class AuthorityGroup : Base
    {
        #region Fields
        public GlobalConstants.AuthorityGroupValue Id { get; set; }
        public string AuthorityGroupName { get; set; }
        public int? Sort { get; set; }
        public GlobalConstants.StatusValue Status { get; set; }
        #endregion

        #region FK
        public AuthorityGroup()
        {
            userAuthoritys = new ObservableCollection<UserAuthority>();
        }

        public virtual ObservableCollection<UserAuthority> userAuthoritys { get; set; }
        #endregion
    }
}
