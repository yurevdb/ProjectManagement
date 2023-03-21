using ProjectManagement.Core;
using ProjectManagement.Presentation.Core;
using System.Collections.Generic;

namespace ProjectManagement.Presentation.WPF
{
    internal class TaskViewerDesignViewModel : BaseViewModel
    {
        public static TaskViewerDesignViewModel Instance { get; private set; } = Instance ?? new TaskViewerDesignViewModel();

        public IEnumerable<Task> Tasks { get; private set; }

        private TaskViewerDesignViewModel()
        {

        }
    }
}
