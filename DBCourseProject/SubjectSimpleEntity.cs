using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCourseProject
{
    class SubjectSimpleEntity : BasicSimpleEntity, ISimpleEntity
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
            Subj subject = new Subj();
            subject.idSubject = FreeIndex;
            subject.nameSubject = value;
            EntitiesHolder.Entities.Subj.AddObject(subject);
        }

        protected override void SetValue(string oldValue, string newValue)
        {            
            var subject =
                (from entry in EntitiesHolder.Entities.Subj
                 where entry.nameSubject == oldValue
                 select entry).First();
            subject.nameSubject = newValue;
        }

        protected override void DeleteValue(string value)
        {            
            var subject =
                (from entry in EntitiesHolder.Entities.Subj
                 where entry.nameSubject == value
                 select entry).First();
            EntitiesHolder.Entities.Subj.DeleteObject(subject);
        }

        public System.Linq.IQueryable<string> Values
        {
            get
            {
                return
                    (from entry in EntitiesHolder.Entities.v_subjNames
                     select entry.nameSubject);
            }
        }

        protected override IQueryable<decimal> GetRawIndexData()
        {
            return
                (from entry in EntitiesHolder.Entities.Subj
                 select entry.idSubject);
        }

        protected override IQueryable<string> GetRawNameData()
        {
            return
                (from entry in EntitiesHolder.Entities.Subj
                 select entry.nameSubject);
        }

        protected override decimal Capacity
        {
            get
            {
                return 100;
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
