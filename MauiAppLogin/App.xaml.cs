namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Define uma página inicial temporária
            MainPage = new Login();

            // Chama método assíncrono de forma segura fora do construtor
            VerificarUsuarioLogado();
        }

        private async void VerificarUsuarioLogado()
        {
            var usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

            if (usuario_logado == null)
            {
                MainPage = new Login();
            }
            else
            {
                MainPage = new Protegida();
            }
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Width = 400;
            window.Height = 600;
            return window;
        }
    }
}
