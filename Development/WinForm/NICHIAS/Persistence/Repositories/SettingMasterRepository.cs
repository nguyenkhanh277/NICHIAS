using NICHIAS.Core.Domain;
using NICHIAS.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;
using NICHIAS.Core;
using NICHIAS.Core.Helper;

namespace NICHIAS.Persistence.Repositories
{
    public class SettingMasterRepository : Repository<SettingMaster>
    {
        public string id = "";

        public SettingMasterRepository(ProjectDataContext projectDataContext) : base(projectDataContext)
        {
        }

        public ProjectDataContext ProjectDataContext
        {
            get { return Context as ProjectDataContext; }
        }

        public void Save(SettingMaster settingMaster)
        {
            if (String.IsNullOrEmpty(settingMaster.Id))
            {
                settingMaster.Id = GetAutoID();
                settingMaster.CreatedAt = DateTime.Now;
                settingMaster.CreatedBy = GlobalConstants.username;
                Add(settingMaster);
                id = settingMaster.Id;
            }
            else
            {
                Update(settingMaster);
            }
        }

        public void Update(SettingMaster settingMaster)
        {
            error = false;
            errorMessage = "";
            try
            {
                var raw = FirstOrDefault(_ => _.Id.Equals(settingMaster.Id));
                if (raw != null)
                {
                    raw.CollectInformation(settingMaster);
                    raw.EditedAt = DateTime.Now;
                    raw.EditedBy = GlobalConstants.username;
                    this.id = raw.Id;
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