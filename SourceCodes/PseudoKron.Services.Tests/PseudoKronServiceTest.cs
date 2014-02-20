using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Aliencube.PseudoKron.Configurations;
using Aliencube.PseudoKron.Configurations.Interfaces;
using Aliencube.PseudoKron.Services.Interfaces;
using NUnit.Framework;

namespace Aliencube.PseudoKron.Services.Tests
{
    [TestFixture]
    public class PseudoKronServiceTest
    {
        private IPseudoKronSettings _settings;
        private IPseudoKronService _service;

        #region SetUp / TearDown

        [SetUp]
        public void Init()
        {
            this._settings = ConfigurationManager.GetSection("pseudoKron") as IPseudoKronSettings;
            this._service = new PseudoKronService(this._settings);
        }

        [TearDown]
        public void Dispose()
        {
            this._service.Dispose();
            this._settings.Dispose();
        }

        #endregion

        #region Tests

        [Test]
        public void Test()
        {
        }

        #endregion
    }
}
