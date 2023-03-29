using System.Text.Json;

namespace ProjectManagement.Persistence.Config.Implementations
{
    /// <summary>
    /// Implementation of the <see cref="IConfig"/> for JSON
    /// </summary>
    public class JsonConfig : IConfig
    {
        #region Private Members

        /// <summary>
        /// The config file path
        /// </summary>
        private static readonly string CONFIG_FILE = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Taskr", "Taskr.json");

        #endregion

        #region Public Properties

        /// <inheritdoc/>
        public bool ShowDoneTasks { get; set; } = true;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public JsonConfig()
        {

        }

        #endregion

        #region Public Functions

        /// <inheritdoc/>
        public void Save() => File.WriteAllText(CONFIG_FILE, JsonSerializer.Serialize<IConfig>(this));

        #endregion

        #region Static Functions

        /// <summary>
        /// Load the <see cref="JsonConfig"/> from the local file
        /// </summary>
        /// <returns>The deserialized <see cref="JsonConfig"/> from the <see cref="CONFIG_FILE"/> if it exists; A new <see cref="JsonConfig"/> otherwise</returns>
        public static JsonConfig Load()
        {
            // Check if the folder exists
            if (!Directory.Exists(Path.GetDirectoryName(CONFIG_FILE)))
                Directory.CreateDirectory(Path.GetDirectoryName(CONFIG_FILE));

            // Return the local config file or a new Config item
            return File.Exists(CONFIG_FILE) ? JsonSerializer.Deserialize<JsonConfig>(File.ReadAllText(CONFIG_FILE)) : new JsonConfig();
        }

        #endregion
    }
}
