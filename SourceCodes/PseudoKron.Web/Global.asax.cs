using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.SessionState;

namespace PseudoKron.Web
{
    public class Global : System.Web.HttpApplication
    {
        private bool RegisterCacheEntry()
        {
            if (null != HttpContext.Current.Cache["PseudoKron"])
                return false;

            HttpContext.Current.Cache.Add("PseudoKron",
                                          "Value",
                                          null,
                                          Cache.NoAbsoluteExpiration,
                                          TimeSpan.FromMinutes(1),
                                          CacheItemPriority.Normal,
                                          CacheItemRemovedCallback);
            return true;
        }

        public void CacheItemRemovedCallback(string key, object value, CacheItemRemovedReason reason)
        {
            this.KeepCacheAliveByContactingADummyPage();
            this.DoScheduledJob();
        }

        private void DoScheduledJob()
        {
            throw new NotImplementedException();
        }

        private void KeepCacheAliveByContactingADummyPage()
        {
            var dummyUrl = "/home/dummy";
            using (var client = new WebClient())
            {
                client.DownloadString(dummyUrl);
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var dummyUrl = "/home/dummy";
            if (HttpContext.Current.Request.Url.AbsolutePath == dummyUrl)
                this.RegisterCacheEntry();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}