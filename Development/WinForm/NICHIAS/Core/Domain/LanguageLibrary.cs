using System;
using System.Collections.ObjectModel;

namespace NICHIAS.Core.Domain
{
    public class LanguageLibrary : Base
    {
        #region Fields
        public string Id { get; set; }
        public string Vietnamese { get; set; }
        public string English { get; set; }
        #endregion
    }
}
