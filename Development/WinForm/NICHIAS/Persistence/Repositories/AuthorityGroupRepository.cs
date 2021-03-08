using NICHIAS.Core.Domain;
using NICHIAS.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;
using NICHIAS.Core;
using NICHIAS.Core.Helper;

namespace NICHIAS.Persistence.Repositories
{
    public class AuthorityGroupRepository : Repository<AuthorityGroup>
    {
        public AuthorityGroupRepository(ProjectDataContext projectDataContext) : base(projectDataContext)
        {
        }

        public ProjectDataContext ProjectDataContext
        {
            get { return Context as ProjectDataContext; }
        }
    }
}