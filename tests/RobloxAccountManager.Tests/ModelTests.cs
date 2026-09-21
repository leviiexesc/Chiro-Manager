using RobloxAccountManager.Models;

namespace RobloxAccountManager.Tests;

public sealed class ModelTests
{
    [Fact]
    public void AccountDisplayLabelPrefersDisplayName()
    {
        var account = new RobloxAccount { Username = "builderman", DisplayName = "Builder" };

        Assert.Equal("Builder", account.DisplayLabel);
    }

    [Fact]
    public void AccountDisplayLabelFallsBackToUsername()
    {
        var account = new RobloxAccount { Username = "builderman" };

        Assert.Equal("builderman", account.DisplayLabel);
    }
}