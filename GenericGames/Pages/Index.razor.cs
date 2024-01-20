using GenericGames.Helpers;

namespace GenericGames.Pages;

public partial class Index
{
    public string ServerUrl = "localhost";

    protected override async Task OnInitializedAsync()
    {
        var baseUri = new Uri(this.NavigationManager.BaseUri);
        var target = $"{baseUri.Scheme}://{ConnectionHelper.GetIpAddress()}:{baseUri.Port}/join";
        var targetUri = new Uri(target);
        ServerUrl = targetUri.ToString();
    }
}
