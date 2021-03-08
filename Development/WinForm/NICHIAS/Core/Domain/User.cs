using System;
using System.Collections.ObjectModel;

namespace NICHIAS.Core.Domain
{
    public class User : Base
    {
        #region Fields
        public string Id { get; set; }
        public string Username { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public GlobalConstants.GenderValue Gender { get; set; }
        public string Note { get; set; }
        public GlobalConstants.StatusValue Status { get; set; }
        #endregion

        #region FK
        public User()
        {
            userAuthoritys = new ObservableCollection<UserAuthority>();
        }

        public virtual ObservableCollection<UserAuthority> userAuthoritys { get; set; }
        #endregion
    }
}
