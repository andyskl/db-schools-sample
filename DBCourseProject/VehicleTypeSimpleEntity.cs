using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCourseProject
{
    class VehicleTypeSimpleEntity : BasicSimpleEntity, ISimpleEntity
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
            VehicleType vt = new VehicleType();
            vt.idVehicleType = FreeIndex;
            vt.nameVehicleType = value;
            EntitiesHolder.Entities.VehicleType.AddObject(vt);
        }

        protected override void SetValue(string oldValue, string newValue)
        {
            var vt =
                (from entry in EntitiesHolder.Entities.VehicleType
                 where entry.nameVehicleType == oldValue
                 select entry).First();
            vt.nameVehicleType = newValue;
        }

        protected override void DeleteValue(string value)
        {
            var vt =
                (from entry in EntitiesHolder.Entities.VehicleType
                 where entry.nameVehicleType == value
                 select entry).First();
            EntitiesHolder.Entities.VehicleType.DeleteObject(vt);
        }

        public System.Linq.IQueryable<string> Values
        {
            get
            {
                return
                    (from entry in EntitiesHolder.Entities.v_vehicleTypeNames
                     select entry.nameVehicleType);
            }
        }

        protected override IQueryable<decimal> GetRawIndexData()
        {
            return
                (from entry in EntitiesHolder.Entities.VehicleType
                 select entry.idVehicleType);
        }

        protected override IQueryable<string> GetRawNameData()
        {
            return
                (from entry in EntitiesHolder.Entities.VehicleType
                 select entry.nameVehicleType);
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
