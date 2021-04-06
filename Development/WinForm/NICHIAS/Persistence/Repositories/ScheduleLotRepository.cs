using NICHIAS.Core.Domain;
using NICHIAS.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;
using NICHIAS.Core;
using NICHIAS.Core.Helper;
using System.Threading;
using System.Data;

namespace NICHIAS.Persistence.Repositories
{
    public class ScheduleLotRepository : Repository<ScheduleLot>
    {
        public string id = "";

        public ScheduleLotRepository(ProjectDataContext projectDataContext) : base(projectDataContext)
        {
        }

        public ProjectDataContext ProjectDataContext
        {
            get { return Context as ProjectDataContext; }
        }

        public void Save(ScheduleLot scheduleLot)
        {
            if (String.IsNullOrEmpty(scheduleLot.Id))
            {
                scheduleLot.Id = GetAutoID();
                scheduleLot.CreatedAt = DateTime.Now;
                scheduleLot.CreatedBy = GlobalConstants.username;
                Add(scheduleLot);
                id = scheduleLot.Id;
            }
            else
            {
                Update(scheduleLot);
            }
        }

        public void Update(ScheduleLot scheduleLot)
        {
            error = false;
            errorMessage = "";
            try
            {
                var raw = FirstOrDefault(_ => _.Id.Equals(scheduleLot.Id));
                if (raw != null)
                {
                    raw.CollectInformation(scheduleLot);
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

        public string GetAutoID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}