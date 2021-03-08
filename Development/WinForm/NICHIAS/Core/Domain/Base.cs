using System;
using System.Linq;
using System.Reflection;
using NICHIAS.Core.Helper;
using NICHIAS.Persistence;

namespace NICHIAS.Core.Domain
{
    public abstract class Base
    {
        #region Fields
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? EditedAt { get; set; }
        public string EditedBy { get; set; }
        #endregion

        public void CollectInformation(Object model, bool withoutManagementInfo = false, bool withoutNullValue = false, bool withoutZeroValue = false)
        {
            if (
                !this.GetType().Equals(model.GetType())
                && !this.GetType().BaseType.Equals(model.GetType())
                && !model.GetType().Equals(this.GetType())
                && !model.GetType().BaseType.Equals(this.GetType())
                ) return;
            Type src = model.GetType();
            if (src != null)
            {
                PropertyInfo[] props = src.GetProperties(
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance
                );
                foreach (PropertyInfo prop in props)
                {
                    if (withoutManagementInfo && prop.Name.StartsWith("_")) continue;
                    var value = src.GetProperty(prop.Name).GetValue(model);
                    if (prop.CanRead && prop.CanWrite && value != null)
                    {
                        Object val = src.GetProperty(prop.Name).GetValue(model);
                        if (prop.PropertyType.Equals(typeof(DateTime)))
                        {
                            DateTime date = (DateTime)val;
                            if (!date.Equals(DateTime.MinValue))
                                prop.SetValue(this, val);
                        }
                        else if (GeneralHelper.IsNumericType(prop.PropertyType))
                        {
                            Type type = prop.PropertyType;
                            if ((val.ToString() != "0" && withoutZeroValue) || !withoutZeroValue)
                            {
                                prop.SetValue(this, src.GetProperty(prop.Name).GetValue(model));
                            }
                        }
                        else
                        {
                            if (this.GetType().GetProperties().Where(_ => _.Name == prop.Name && _.GetType() == prop.GetType()).Any())
                            {
                                if ((val != null && withoutNullValue) || !withoutNullValue)
                                    prop.SetValue(this, src.GetProperty(prop.Name).GetValue(model));
                            }
                        }
                    }
                }
            }
        }
    }
}