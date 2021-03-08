using NICHIAS.Core.Domain;
using NICHIAS.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;
using NICHIAS.Core;
using NICHIAS.Core.Helper;

namespace NICHIAS.Persistence.Repositories
{
    public class LanguageLibraryRepository : Repository<LanguageLibrary>
    {
        public string id = "";

        public LanguageLibraryRepository(ProjectDataContext projectDataContext) : base(projectDataContext)
        {
        }

        public ProjectDataContext ProjectDataContext
        {
            get { return Context as ProjectDataContext; }
        }

        public void Save(LanguageLibrary languageLibrary)
        {
            if (String.IsNullOrEmpty(languageLibrary.Id))
            {
                languageLibrary.Id = GetAutoID();
                languageLibrary.CreatedAt = DateTime.Now;
                languageLibrary.CreatedBy = GlobalConstants.username;
                Add(languageLibrary);
                id = languageLibrary.Id;
            }
            else
            {
                Update(languageLibrary);
            }
        }

        public void Update(LanguageLibrary languageLibrary)
        {
            error = false;
            errorMessage = "";
            try
            {
                var raw = FirstOrDefault(_ => _.Id.Equals(languageLibrary.Id));
                if (raw != null)
                {
                    raw.CollectInformation(languageLibrary);
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