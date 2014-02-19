using System;
using System.Configuration;

namespace Aliencube.PseudoKron.Configurations
{
    /// <summary>
    /// This represents the kron job element entity.
    /// </summary>
    public class KronJobElement : ConfigurationElement
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unique key of the kron job.
        /// </summary>
        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get { return (string)this["key"]; }
            set { this["key"] = value; }
        }

        /// <summary>
        /// Gets or sets the command for the kron job.
        /// </summary>
        [ConfigurationProperty("command", IsRequired = true)]
        public string Command
        {
            get { return (string)this["command"]; }
            set { this["command"] = value; }
        }

        /// <summary>
        /// Gets or sets the date/time when the kron job starts.
        /// </summary>
        /// <remarks>Default value is <c>DateTime.Today</c>.</remarks>
        [ConfigurationProperty("startFrom", DefaultValue = null, IsRequired = false)]
        public DateTime StartFrom
        {
            get
            {
                var result = DateTime.Today;
                try
                {
                    result = (DateTime) this["startFrom"];
                }
                catch { }
                return result;
            }
            set { this["startFrom"] = value; }
        }

        /// <summary>
        /// Gets or sets the date/time when the kron job ends.
        /// </summary>
        /// <remarks>Default value is <c>DateTime.MaxValue</c>.</remarks>
        [ConfigurationProperty("endTo", DefaultValue = null, IsRequired = false)]
        public DateTime EndTo
        {
            get
            {
                var result = DateTime.Today;
                try
                {
                    result = (DateTime)this["endTo"];
                }
                catch { }
                return result;
            }
            set { this["endTo"] = value; }
        }

        /// <summary>
        /// Gets or sets the frequency of a day, meaning how often the job runs for a day.
        /// </summary>
        /// <remarks>
        /// Default frequency is 48, meaning the job repreats every half an hour.
        /// If this is set to 0, <c>Interval</c> value is used instead.
        /// If both <c>Frequency</c> and <c>Interval</c> are 0, the kron job will take place at <c>StartFrom</c> only once.
        /// If both <c>Frequency</c> and <c>Interval</c> are not 0, the kron job will not be executed.
        /// </remarks>
        [ConfigurationProperty("frequency", DefaultValue = 48, IsRequired = false)]
        public int Frequency
        {
            get { return (int)this["frequency"]; }
            set { this["frequency"] = value; }
        }

        /// <summary>
        /// Gets or sets the interval in minutes.
        /// </summary>
        /// <remarks>
        /// Default interval is 30, meaning the job repeats every half an hour.
        /// If this is set to 0, <c>Frequency</c> value is used instead.
        /// If both <c>Interval</c> and <c>Frequency</c> are 0, the kron job will take place at <c>StartFrom</c> only once.
        /// If both <c>Interval</c> and <c>Frequency</c> are not 0, the kron job will not be executed.
        /// </remarks>
        [ConfigurationProperty("interval", DefaultValue = 30, IsRequired = false)]
        public int Interval
        {
            get { return (int)this["interval"]; }
            set { this["interval"] = value; }
        }

        #endregion Properties
    }
}