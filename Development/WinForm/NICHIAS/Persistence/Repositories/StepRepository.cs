using NICHIAS.Core.Domain;
using NICHIAS.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;
using NICHIAS.Core;
using NICHIAS.Core.Helper;

namespace NICHIAS.Persistence.Repositories
{
    public class StepRepository : Repository<Step>
    {
        public string id = "";

        public StepRepository(ProjectDataContext projectDataContext) : base(projectDataContext)
        {
        }

        public ProjectDataContext ProjectDataContext
        {
            get { return Context as ProjectDataContext; }
        }

        public void Save(Step step)
        {
            if (String.IsNullOrEmpty(step.Id))
            {
                step.Id = GetAutoID();
                step.CreatedAt = DateTime.Now;
                step.CreatedBy = GlobalConstants.username;
                Add(step);
                id = step.Id;
            }
            else
            {
                Update(step);
            }
        }

        public void Update(Step step)
        {
            error = false;
            errorMessage = "";
            try
            {
                var raw = FirstOrDefault(_ => _.Id.Equals(step.Id));
                if (raw != null)
                {
                    raw.CollectInformation(step);
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