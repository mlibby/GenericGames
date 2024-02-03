using Microsoft.AspNetCore.Components.Forms;

namespace GenericGames.Pages;

public partial class Join
{
    private FormModel? model;
    private EditContext? editContext;

    protected override async Task OnInitializedAsync()
    {
        model = new FormModel();
        //model.FormChanged += HandleFormChanged;
        editContext = new EditContext(model);
    }

    public class FormModel
    {
        private string playerName = "";
        public string PlayerName
        {
            get => playerName;
            set
            {
                playerName = value;
                OnFormChanged();
            }
        }

        public event EventHandler? FormChanged = default!;
        private void OnFormChanged() => FormChanged?.Invoke(this, EventArgs.Empty);
    }
}
