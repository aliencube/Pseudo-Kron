using System;
using System.Web;

namespace Aliencube.PseudoKron.Services.Interfaces
{
    /// <summary>
    /// This provides interfaces to the PseudoKronService class.
    /// </summary>
    public interface IPseudoKronService : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets or sets the HttpContextBase instance.
        /// </summary>
        HttpContextBase HttpContext { get; set; }

        #endregion Properties
    }
}