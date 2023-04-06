using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core;
using ProjectManagement.Persistence;
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
        /// The locally stored selected <see cref="Pool"/>
        /// </summary>
        private Pool? mSelectedPool = null;

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
            get => mSelectedPool!;
            set {
                mSelectedPool = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to create a new pool
        /// </summary>
        public ICommand CreatePoolCommand { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to edit the selected pool
        /// </summary>
        public ICommand EditPoolCommand { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to open the config
        /// </summary>
        public ICommand OpenConfigCommand { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to delete the selected pool
        /// </summary>
        public ICommand DeletePoolCommand { get; set; }

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
            CreatePoolCommand = new RelayCommand(CreatePool);
            EditPoolCommand = new RelayCommand(EditPool);
            OpenConfigCommand = new RelayCommand(OpenConfig);
            DeletePoolCommand = new RelayCommand(DeletePool);

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
            // Clear the pools
            mPools.Clear();

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
                mContext.SaveChanges();
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
        /// Create a new pool
        /// </summary>
        private void CreatePool()
        {
            // Create the pool and show the editor
            var p = mUiService.ShowPoolEditor(new Pool());

            // If the name of the pool is empty...
            if (string.IsNullOrEmpty(p.Name))
                // Return
                return;

            // Add the pool
            mPools.Add(p);
            NotifyPropertyChanged(nameof(Pools));

            // Save the pool to the database
            mContext.Pools.Add(p);
            mContext.SaveChanges();
                
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
            mContext.SaveChanges();

            // Notify changes
            NotifyPropertyChanged(nameof(Pools));
            NotifyPropertyChanged(nameof(SelectedPool));
        }

        /// <summary>
        /// Opens the config window
        /// </summary>
        private void OpenConfig()
        {
            // Show the config
            mUiService.ShowConfig();

            NotifyPropertyChanged(nameof(Pools));
            NotifyPropertyChanged(nameof(SelectedPool));
        }
        
        /// <summary>
        /// Delete the selected pool
        /// </summary>
        private async void DeletePool()
        {
            // TConfirm the deletion of the currently selected pool and it's tasks
            if (mUiService.ShowConfirmationPopup($"Are you sure you want to delete '{SelectedPool.Name}' and all it's associated tasks?"))
            {
                // Remove the tasks
                mContext.RemoveRange(SelectedPool.Tasks);

                // Remove the pool
                mContext.Remove(SelectedPool);

                // Save the changes
                await mContext.SaveChangesAsync();

                // Load the data
                LoadData();
            }
        }

        #endregion
    }
}
