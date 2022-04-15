using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eli
{
    internal interface IRequireController<T>
    {
        void AssignController(T controller);
    }
}
