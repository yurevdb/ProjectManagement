using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ProjectManagement.Persistence
{
    /// <summary>
    /// Implementation of the <see cref="IConfig"/> for YAML files
    /// </summary>
    public class YamlConfig : IConfig
    {
        #region Private Members

        /// <summary>
        /// The config file path
        /// </summary>
        private static readonly string CONFIG_FILE = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Taskr", "Taskr.yml");

        #endregion

        #region Events

        /// <inheritdoc/>
        public event EventHandler ConfigUpdated;

        #endregion

        #region Public Properties

        /// <inheritdoc/>
        public bool ShowDoneTasks { get; set; } = true;

        /// <inheritdoc/>
        public SqlitePersistance? Sqlite { get; set; }

        /// <inheritdoc/>
        public SqlServerPersistence? SqlServer { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public YamlConfig() 
        {
        }

        #endregion

        #region Public Functions

        /// <inheritdoc/>
        public void Save() 
        {
            // Yaml serializer
            var ser = new SerializerBuilder().WithNamingConvention(PascalCaseNamingConvention.Instance).Build();

            // Write to file
            File.WriteAllText(CONFIG_FILE, ser.Serialize(this));

            // Trigger update
            ConfigUpdated(this, EventArgs.Empty);
        }

        #endregion

        #region Static Functions

        /// <summary>
        /// Loads the instance of the <see cref="YamlConfig"/>
        /// </summary>
        /// <returns></returns>
        public static YamlConfig Load()
        {
            // Check if the folder exists
            if (!Directory.Exists(Path.GetDirectoryName(CONFIG_FILE)))
                Directory.CreateDirectory(Path.GetDirectoryName(CONFIG_FILE));

            // YAML deserializer
            var des = new DeserializerBuilder().WithNamingConvention(PascalCaseNamingConvention.Instance).Build();

            // If a config is found
            if (File.Exists(CONFIG_FILE))
                // Return it
                return des.Deserialize<YamlConfig>(File.ReadAllText(CONFIG_FILE));

            // Return a newly created config
            return new YamlConfig() 
            { 
                Sqlite = new SqlitePersistance() { 
                    Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Taskr", "Taskr.db")
                } 
            };
        }

        #endregion
    }
}
