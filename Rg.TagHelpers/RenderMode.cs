using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rg.TagHelpers
{
    /// <summary>
    /// choose render mode style,
    /// <para>Bootstrap4: HTML5 div with Bootstrap4 support</para>
    /// <para>Bootstrap5: HTML5 div with Bootstrap5 support</para>
    /// </summary>
    public enum RenderMode
    {
        /// <summary>
        /// HTML5 div with Bootstrap 4 support
        /// </summary>
        Bootstrap4 = 0,
        /// <summary>
        /// HTML5 div with Bootstrap 5 support
        /// </summary>
        Bootstrap5 = 1
    }
}
