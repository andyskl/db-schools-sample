using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCourseProject
{
    public class BasicSimpleEntity : CustomEntity
    {        
        public void Apply()
        {
            EntitiesHolder.Entities.SaveChanges();
        }        

        protected bool IsUnique(string value)
        {
            var rawData = GetRawNameData();
            var listData = rawData.ToList<string>();
            return !listData.Contains(value);
        }

        protected virtual IQueryable<string> GetRawNameData() { return null; }

        protected virtual void AddValue(string value) { }

        protected virtual void SetValue(string oldValue, string newValue) { }

        protected virtual void DeleteValue(string value) { }        

        protected virtual decimal Length
        {
            get
            {
                return 0;
            }
        }

        public void Add(string value)
        {
            CheckCapacity();
            if (!IsUnique(value))
                throw new ValueAlreadyExistsException();            
            if (value.Length > Length)
                throw new LongArgumentException();
            AddValue(value);
        }

        public void Set(string oldValue, string newValue)
        {
            if (newValue != oldValue && !IsUnique(newValue))
                throw new ValueAlreadyExistsException();
            if (IsUnique(oldValue))
                throw new NoSuchValueException();
            if (newValue.Length > Length)
                throw new LongArgumentException();
            SetValue(oldValue, newValue);
        }

        public void Delete(string value)
        {
            if (IsUnique(value))
                throw new NoSuchValueException();
            DeleteValue(value);
        }
    }
}
