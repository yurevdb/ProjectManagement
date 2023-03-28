namespace ProjectManagement.Presentation.WPF
{
    internal class ConfirmationPopupDesignViewModel : ConfirmationPopupViewModel
    {
        public static ConfirmationPopupDesignViewModel Instance { get; private set; } = Instance ?? new ConfirmationPopupDesignViewModel();


        private ConfirmationPopupDesignViewModel(): base("Test")
        {

        }
    }
}
