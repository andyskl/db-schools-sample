using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCourseProject
{
    interface ISimpleEntity
    {
        void Add(string value);
        void Set(string oldValue, string newValue);
        void Delete(string value);
        void Apply();
        int TextLength { get; }
        System.Linq.IQueryable<string> Values { get; }
    }
}
