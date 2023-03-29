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
        private const string CONFIG_FILE = @"%APPDATA%\Taskr\Taskr.yml";

        #endregion

        #region Public Properties

        /// <inheritdoc/>
        public bool ShowDoneTasks { get; set; } = true;

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
            var ser = new SerializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();

            // Write to file
            File.WriteAllText(CONFIG_FILE, ser.Serialize(this));
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
            var des = new DeserializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();

            // Return the yamlconfig
            return File.Exists(CONFIG_FILE) ? des.Deserialize<YamlConfig>(File.ReadAllText(CONFIG_FILE)) : new YamlConfig();
        }

        #endregion
    }
}
