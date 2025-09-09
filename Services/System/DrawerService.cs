namespace Speccon.Learnership.FrontEnd.Services.System
{
    public class DrawerService
    {
        public event Action? OnChange;
        private bool _isDrawerOpen = true;

        public bool IsDrawerOpen
        {
            get => _isDrawerOpen;
            set
            {
                if (_isDrawerOpen == value) return;
                _isDrawerOpen = value;
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
