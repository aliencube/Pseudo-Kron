using System.Configuration;

namespace Aliencube.PseudoKron.Configurations
{
    /// <summary>
    /// This represents the dummy page element entity.
    /// </summary>
    public class DummyPageElement : ConfigurationElement
    {
        #region Properties

        /// <summary>
        /// Gets or sets the dummy page URL to keep HttpContext instance.
        /// </summary>
        /// <remarks>Default page URL is <c>/Default.aspx</c>.</remarks>
        [ConfigurationProperty("url", DefaultValue = "/Default.aspx", IsRequired = false)]
        public string Url
        {
            get { return (string)this["url"]; }
            set { this["url"] = value; }
        }

        #endregion Properties
    }
}