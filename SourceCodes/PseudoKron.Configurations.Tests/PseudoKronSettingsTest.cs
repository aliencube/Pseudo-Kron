using Aliencube.PseudoKron.Configurations.Interfaces;
using NUnit.Framework;
using System;
using System.Configuration;
using System.Linq;

namespace Aliencube.PseudoKron.Configurations.Tests
{
    [TestFixture]
    public class PseudoKronSettingsTest
    {
        private IPseudoKronSettings _settings;

        #region SetUp / TearDown

        [SetUp]
        public void Init()
        {
            this._settings = ConfigurationManager.GetSection("pseudoKron") as PseudoKronSettings;
        }

        [TearDown]
        public void Dispose()
        {
            this._settings.Dispose();
        }

        #endregion SetUp / TearDown

        #region Tests

        /// <summary>
        /// Tests the dummypage has URL value.
        /// </summary>
        [Test]
        public void GetDummyUrl_SendDummyPageElement_ReturnDummyUrl()
        {
            Assert.IsTrue(!String.IsNullOrWhiteSpace(this._settings.DummyPage.Url));
        }

        /// <summary>
        /// Tests each kron job has valid attributes.
        /// </summary>
        [Test]
        public void GetKronJob_SendKronJobElement_ReturnKronJobValues()
        {
            var jobs = this._settings.KronJobs.Cast<KronJobElement>().ToList();
            foreach (var job in jobs)
            {
                Assert.IsTrue(!String.IsNullOrWhiteSpace(job.Key));
                Assert.IsTrue(!String.IsNullOrWhiteSpace(job.Command));
                Assert.IsTrue(job.StartFrom > DateTime.MinValue);
                Assert.IsTrue(job.EndTo <= DateTime.MaxValue);
                Assert.IsTrue((job.Frequency > 0 && job.Interval == 0) || (job.Frequency == 0 || job.Interval > 0));
            }
        }

        #endregion Tests
    }
}