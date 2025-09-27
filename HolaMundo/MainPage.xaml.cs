using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace HolaMundo
{
    public partial class MainPage : ContentPage
    {
        private static readonly Regex Regla = new(@"^(?=.*\p{Lu})(?=.*\p{Ll})(?=.*\p{Nd})(?=.*[\p{P}\p{S}]).+$",
                                         RegexOptions.Compiled);
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnValidatePassword(object? sender, EventArgs e)
        {
            var errs = new List<string>();
            string password1 = PasswordEntry1.Text?.Trim() ?? "";
            string password2 = PasswordEntry2.Text?.Trim() ?? "";

            
            if (string.IsNullOrWhiteSpace(password1) || !Regla.IsMatch(password1)) errs.Add("Contraseña 1 inválida.");
            if (string.IsNullOrWhiteSpace(password2) || !Regla.IsMatch(password2)) errs.Add("Contraseña 2 inválida.");
            if (errs.Count == 0 && password1 != password2) errs.Add("No coinciden.");

            if (errs.Count > 0)
                await DisplayAlert("Errores", "• " + string.Join("\n• ", errs), "OK");
            else
                await DisplayAlert("OK", "Contraseña valida.", "Cerrar");
        }

    }


}
