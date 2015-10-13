using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCourseProject
{
    class ToolTypeSimpleEntity : BasicSimpleEntity, ISimpleEntity
    {

        public int TextLength
        {
            get
            {
                return 50;
            }
        }

        protected override void AddValue(string value)
        {
            ToolType tt = new ToolType();
            tt.idToolType = FreeIndex;
            tt.nameToolType = value;
            EntitiesHolder.Entities.ToolType.AddObject(tt);
        }

        protected override void SetValue(string oldValue, string newValue)
        {
            var tt =
                (from entry in EntitiesHolder.Entities.ToolType
                 where entry.nameToolType == oldValue
                 select entry).First();
            tt.nameToolType = newValue;
        }

        protected override void DeleteValue(string value)
        {
            var tt =
                (from entry in EntitiesHolder.Entities.ToolType
                 where entry.nameToolType == value
                 select entry).First();
            EntitiesHolder.Entities.ToolType.DeleteObject(tt);
        }

        public System.Linq.IQueryable<string> Values
        {
            get
            {
                return
                    (from entry in EntitiesHolder.Entities.v_toolsNames
                     select entry.nameToolType);
            }
        }

        protected override IQueryable<decimal> GetRawIndexData()
        {
            return
                (from entry in EntitiesHolder.Entities.ToolType
                 select entry.idToolType);
        }

        protected override IQueryable<string> GetRawNameData()
        {
            return
                (from entry in EntitiesHolder.Entities.ToolType
                 select entry.nameToolType);
        }

        protected override decimal Capacity
        {
            get
            {
                return 10;
            }
        }

        protected override decimal Length
        {
            get
            {
                return 50;
            }
        }
    }
}
