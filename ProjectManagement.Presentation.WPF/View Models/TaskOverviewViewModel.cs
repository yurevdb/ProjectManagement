using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core;
using ProjectManagement.Persistance;
using ProjectManagement.Presentation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace ProjectManagement.Presentation.WPF
{
    /// <summary>
    /// View model for <see cref="TaskOverview"/>
    /// </summary>
    public class TaskOverviewViewModel : BaseViewModel
    {
        #region Private Members
        
        /// <summary>
        /// The locally stored list of pools
        /// </summary>
        private readonly IList<Pool> mPools;

        /// <summary>
        /// The locally stored task description input
        /// </summary>
        private string mTaskDescriptionInput = string.Empty;

        /// <summary>
        /// The locally stored selected <see cref="Pool"/>
        /// </summary>
        private Pool mSelectedPool;

        /// <summary>
        /// The locally stored <see cref="UiService"/>
        /// </summary>
        private readonly UiService mUiService;

        /// <summary>
        /// The locally stored <see cref="ApplicationDbContext"/>
        /// </summary>
        private readonly ApplicationDbContext mContext;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the pools
        /// </summary>
        public IEnumerable<Pool> Pools => mPools.ToList();

        /// <summary>
        /// Gets or sets the selected <see cref="Pool"/>
        /// </summary>
        public Pool SelectedPool 
        {
            get => mSelectedPool;
            set {
                mSelectedPool = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the task description input
        /// </summary>
        public string TaskDescriptionInput
        {
            get => mTaskDescriptionInput;
            set { 
                mTaskDescriptionInput = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to add a <see cref="Task"/>
        /// </summary>
        public ICommand AddTaskCommand { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to create a new pool
        /// </summary>
        public ICommand CreatePoolCommand { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to open the popout
        /// </summary>
        public ICommand OpenPopoutCommand { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to edit the selected pool
        /// </summary>
        public ICommand EditPoolCommand { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to open the config
        /// </summary>
        public ICommand OpenConfigCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TaskOverviewViewModel(UiService mUiService, ApplicationDbContext context) : base()
        {
            // Initialize the list
            mPools = new List<Pool>();

            // Set up commands
            AddTaskCommand = new RelayCommand(AddTask);
            CreatePoolCommand = new RelayCommand(CreatePool);
            OpenPopoutCommand = new RelayCommand(OpenPopout);
            EditPoolCommand = new RelayCommand(EditPool);
            OpenConfigCommand = new RelayCommand(OpenConfig);

            // Set services
            this.mUiService = mUiService;
            mContext = context;

            // Setup data
            LoadData();
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Load the data
        /// </summary>
        private void LoadData()
        {
            // If the database does not have any pools
            if(!mContext.Pools.Any())
            {
                // Create a default pool
                var p = new Pool()
                {
                    Name = "Default Pool"
                };

                // Add to the local list
                mPools.Add(p);

                // Add to the database
                mContext.Pools.Add(p);
                mContext.SaveChangesAsync();
            }
            else
            {
                // Query the pools 
                var pools = mContext.Pools.Where(p => p.CreationUser == Environment.UserName)
                                          .Include(p => p.Tasks)
                                          .OrderBy(p => p.CreationTime);

                // Add pools to local pools
                foreach (var pool in pools)
                    mPools.Add(pool);
            }

            // Set the selected pool
            SelectedPool = Pools.First();

            // Notify changes
            NotifyPropertyChanged(nameof(Pools));
        }

        /// <summary>
        /// Adds a new <see cref="Task"/> based on the <see cref="TaskDescriptionInput"/>
        /// </summary>
        private void AddTask()
        {
            // Check if description has words
            if (string.IsNullOrEmpty(TaskDescriptionInput))
                return;

            // Create and add a new task
            var task = new Task()
            {
                Description = TaskDescriptionInput,
                Status = TaskStatus.NotYetStarted
            };

            // Add the task to the pool
            SelectedPool.AddTask(task);

            // Save the data to the database
            mContext.Tasks.Add(task);
            mContext.SaveChangesAsync();

            // Set the description input to empty
            TaskDescriptionInput = string.Empty;

            // Notify that the collection has been updated
            NotifyPropertyChanged(nameof(Pools));
            NotifyPropertyChanged(nameof(SelectedPool));
        }

        /// <summary>
        /// Create a new pool
        /// </summary>
        private void CreatePool()
        {
            // Create the pool and show the editor
            var p = mUiService.ShowPoolEditor(new Pool());

            // If the name of the pool is emtpy...
            if (string.IsNullOrEmpty(p.Name))
                // Return
                return;

            // Add the pool
            mPools.Add(p);
            NotifyPropertyChanged(nameof(Pools));

            // Save the pool to the database
            mContext.Pools.Add(p);
            mContext.SaveChangesAsync();

            // Set the new pool as the selected pool
            SelectedPool = p;
            NotifyPropertyChanged(nameof(SelectedPool));
        }

        /// <summary>
        /// Edits the selected pool
        /// </summary>
        private void EditPool()
        {
            // Show the editor
            mUiService.ShowPoolEditor(SelectedPool);

            // Save changes to the database
            mContext.SaveChangesAsync();

            // Notify changes
            NotifyPropertyChanged(nameof(Pools));
            NotifyPropertyChanged(nameof(SelectedPool));
        }

        /// <summary>
        /// Opens the pop out for task input
        /// </summary>
        private void OpenPopout()
        {
            // Show the task input with the selected pool
            mUiService.ShowTaskInput(SelectedPool);

            // Notify any changes
            NotifyPropertyChanged(nameof(Pools));
            NotifyPropertyChanged(nameof(SelectedPool));
        }

        /// <summary>
        /// Opens the config window
        /// </summary>
        private void OpenConfig()
        {
            mUiService.ShowConfig();
        }
        
        #endregion
    }
}
