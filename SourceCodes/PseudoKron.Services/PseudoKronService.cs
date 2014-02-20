using Aliencube.PseudoKron.Configurations.Interfaces;
using Aliencube.PseudoKron.Services.Interfaces;
using System;
using System.Net;
using System.Web;
using System.Web.Caching;

namespace Aliencube.PseudoKron.Services
{
    /// <summary>
    /// This represents the pseudo kron service entity.
    /// </summary>
    public class PseudoKronService : IPseudoKronService
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the PseudoKronService class.
        /// </summary>
        /// <param name="settings">PseudoKronSettings instance.</param>
        public PseudoKronService(IPseudoKronSettings settings)
        {
            this._settings = settings;
        }

        /// <summary>
        /// Initialises a new instance of the PseudoKronService class.
        /// </summary>
        /// <param name="settings">PseudoKronSettings instance.</param>
        /// <param name="httpContext">HttpContextBase instance.</param>
        public PseudoKronService(IPseudoKronSettings settings, HttpContextBase httpContext)
        {
            this._settings = settings;
            this.HttpContext = httpContext;
        }

        #endregion Constructors

        #region Properties

        private readonly IPseudoKronSettings _settings;

        /// <summary>
        /// Gets or sets the HttpContextBase instance.
        /// </summary>
        public HttpContextBase HttpContext { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Registers the cache entry for kron job.
        /// </summary>
        /// <returns>Returns <c>True</c>, if cache is added or returns <c>False</c>, if the cache item exists.</returns>
        public bool RegisterCacheEntry()
        {
            if (this.HttpContext.Cache["PseudoKron.Key"] != null)
                return false;

            var onCacheItemRemoved = new CacheItemRemovedCallback(this.OnCacheItemRemoved);
            this.HttpContext.Cache.Add("PseudoKron.Key",
                                       "PseudoKron.Value",
                                       null,
                                       Cache.NoAbsoluteExpiration,
                                       TimeSpan.FromMinutes(1),
                                       CacheItemPriority.Normal,
                                       onCacheItemRemoved);
            return true;
        }

        /// <summary>
        /// Performs when cach item is removed.
        /// </summary>
        /// <param name="key">Cache key.</param>
        /// <param name="value">Cache value.</param>
        /// <param name="reason">Cache item removed reason.</param>
        private void OnCacheItemRemoved(string key, object value, CacheItemRemovedReason reason)
        {
            //this.SaveLog(key, value, reason);
            this.KeepCacheAliveByCallingADummyPage();
            this.ProcessScheduledJobs();
        }

        /// <summary>
        /// Calls a dummy page to keep cache alive.
        /// </summary>
        private void KeepCacheAliveByCallingADummyPage()
        {
            var dummyPageUrl = this._settings.DummyPage.Url;
            using (var client = new WebClient())
            {
                client.DownloadString(dummyPageUrl);
            }
        }

        /// <summary>
        /// Processes list of scheduled jobs.
        /// </summary>
        private void ProcessScheduledJobs()
        {
            throw new NotImplementedException();
        }

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