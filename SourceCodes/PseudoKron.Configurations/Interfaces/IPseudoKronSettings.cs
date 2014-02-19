using System;

namespace Aliencube.PseudoKron.Configurations.Interfaces
{
    /// <summary>
    /// This provides interfaces to the PseudoKorn class.
    /// </summary>
    public interface IPseudoKronSettings : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets or sets the dummy page element.
        /// </summary>
        DummyPageElement DummyPage { get; set; }

        /// <summary>
        /// Gets or sets the collection of generator element groups.
        /// </summary>
        KronJobElementCollection KronJobs { get; set; }

        #endregion Properties
    }
}