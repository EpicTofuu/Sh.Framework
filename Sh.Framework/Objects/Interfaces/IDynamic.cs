using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sh.Framework.Objects.Interfaces
{
    /// <summary>
    /// Dynamic objects move
    /// </summary>
    public interface IDynamic : IStationary
    {
        /// <summary>
        /// called once per frame
        /// </summary>
        void Update();
    }
}
