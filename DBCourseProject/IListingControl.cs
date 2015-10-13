using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCourseProject
{
    public interface IListingControl
    {
        void OutputData(object dataSource);
        int Index { get; }
        int ElementCount { get; }
        void Refresh();
    }
}
