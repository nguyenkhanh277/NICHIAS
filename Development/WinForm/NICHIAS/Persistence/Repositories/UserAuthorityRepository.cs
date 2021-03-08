using NICHIAS.Core.Domain;
using NICHIAS.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;
using NICHIAS.Core;
using NICHIAS.Core.Helper;

namespace NICHIAS.Persistence.Repositories
{
    public class UserAuthorityRepository : Repository<UserAuthority>
    {
        public string id = "";

        public UserAuthorityRepository(ProjectDataContext projectDataContext) : base(projectDataContext)
        {
        }

        public ProjectDataContext ProjectDataContext
        {
            get { return Context as ProjectDataContext; }
        }

        public void Save(UserAuthority userAuthority)
        {
            if (String.IsNullOrEmpty(userAuthority.Id))
            {
                userAuthority.Id = GetAutoID();
                userAuthority.CreatedAt = DateTime.Now;
                userAuthority.CreatedBy = GlobalConstants.username;
                Add(userAuthority);
                id = userAuthority.Id;
            }
            else
            {
                Update(userAuthority);
            }
        }

        public void Update(UserAuthority userAuthority)
        {
            error = false;
            errorMessage = "";
            try
            {
                var raw = FirstOrDefault(_ => _.Id.Equals(userAuthority.Id));
                if (raw != null)
                {
                    raw.CollectInformation(userAuthority);
                    raw.EditedAt = DateTime.Now;
                    raw.EditedBy = GlobalConstants.username;
                    id = raw.Id;
                }
            }
            catch (Exception ex)
            {
                error = true;
                errorMessage = ex.ToString();
            }
        }

        public void DeleteByUserId(string userID)
        {
            Remove(FirstOrDefault(_ => _.UserId.Equals(userID)));
        }

        public string GetAutoID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}