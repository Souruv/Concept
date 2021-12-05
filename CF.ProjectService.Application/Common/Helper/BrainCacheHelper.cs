using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Common.Helper
{
    public class BrainCacheHelper
    {

        private readonly IDictionary<string, string> _resultCache = new Dictionary<string, string>();

        public void Add(Guid tableid, Guid rowId, string columnName, string value)
        {
            Add("" + tableid + rowId + columnName, value);
        }
        public void Add(Guid tableid, string rowId, string columnName, string value)
        {
            Add("" + tableid + rowId + columnName, value);

        }
        public void Add(string key, string value)
        {
            if (!IsExist(key))
            {
                _resultCache.Add(key, value);
            }
        }
        public bool IsExist(string key)
        {
            return _resultCache.Keys.Contains(key);
        }
        public bool IsExist(Guid tableid, string rowId, string columnName)
        {
            return IsExist("" + tableid + rowId + columnName);
        }
        public bool IsExist(Guid tableid, Guid rowId, string columnName)
        {
            return IsExist("" + tableid + rowId + columnName);
        }
        public string GetValue(Guid tableid, Guid rowId, string columnName)
        {
            GetValue(tableid, "" + rowId, columnName);

            return null;
        }

        public string GetValue(Guid tableid, string rowId, string columnName)
        {
            if (IsExist("" + tableid + rowId + columnName))
            {
                return _resultCache["" + tableid + rowId + columnName];
            }

            return null;
        }
    }
}
