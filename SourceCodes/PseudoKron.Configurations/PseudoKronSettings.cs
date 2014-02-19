using Aliencube.PseudoKron.Configurations.Interfaces;
using System.Configuration;

namespace Aliencube.PseudoKron.Configurations
{
    /// <summary>
    /// This represents a configuration settings entity for Pseudo Kron.
    /// </summary>
    public class PseudoKronSettings : ConfigurationSection, IPseudoKronSettings
    {
        #region Properties

        /// <summary>
        /// Gets or sets the dummy page element.
        /// </summary>
        [ConfigurationProperty("dummyPage", IsRequired = true)]
        public DummyPageElement DummyPage
        {
            get { return (DummyPageElement)this["dummyPage"]; }
            set { this["dummyPage"] = value; }
        }

        /// <summary>
        /// Gets or sets the collection of generator element groups.
        /// </summary>
        [ConfigurationProperty("kronJobs", IsRequired = true)]
        public KronJobElementCollection KronJobs
        {
            get { return (KronJobElementCollection)this["kronJobs"]; }
            set { this["kronJobs"] = value; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }

        #endregion Methods
    }
}