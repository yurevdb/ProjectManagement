using ProjectManagement.Core;
using ProjectManagement.Presentation.Core;
using System.Collections.Generic;
using System.Windows.Input;

namespace ProjectManagement.Presentation.WPF
{
    public class TaskViewerViewModel : BaseViewModel
    {
        private readonly UiService mUiService;

        private IEnumerable<Task> mTasks;

        public void SetTasks(IEnumerable<Task> tasks)
        {
            mTasks = tasks;
            NotifyPropertyChanged(nameof(Tasks));
        }

        public IEnumerable<Task> Tasks => mTasks;


        /// <summary>
        /// Opens the <see cref="TaskEditor"/> with the given <see cref="Task"/>
        /// </summary>
        /// <param name="task">The <see cref="Task"/> to edit/view</param>
        private void OpenTaskEditor(Task task)
        {
            mUiService.ShowTaskEditor(task);
        }


        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to open the task editor
        /// </summary>
        public ICommand OpenTaskEditorCommand { get; set; }


        public TaskViewerViewModel(UiService uiService)
        {
            mUiService = uiService;
            OpenTaskEditorCommand = new RelayParameterizedCommand(t => OpenTaskEditor((Task)t));
        }
    }
}
