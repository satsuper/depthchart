namespace Core.Test;

public class DepthChartTests
{
    [Fact]
    public void AddPlayerToChart()
    {
        var chart = new DepthChart<string>();
        var players = new Player[] { new(12, "Tom Brady"), new(11, "Blaine Gabbert") };
        for (var i = 0; i < players.Length; i++)
        {
            chart.AddPlayer("QB", players[i], i);
        }

        var expectedPlayers = new Dictionary<string, Player[]>()
        {
            {"QB", players }
        };
        Assert.Equivalent(expectedPlayers, chart, strict: true);
    }

    [Fact]
    public void RemovePlayerFromChart()
    {
        var chart = new DepthChart<string>();
        var players = new Player[] { new(12, "Tom Brady"), new(11, "Blaine Gabbert") };
        for (var i = 0; i < players.Length; i++)
        {
            chart.AddPlayer("QB", players[i], i);
        }

        var removed = chart.RemovePlayer("QB", players[0]);
        Assert.Equal(players[0], removed);

        var remainingPlayers = new Dictionary<string, Player[]>()
        {
            {"QB", new [] { players[1] } }
        };
        Assert.Equivalent(remainingPlayers, chart, strict: true);
    }

    [Fact]
    public void GetBackupsFromChart()
    {
        var chart = new DepthChart<string>();
        var players = new Player[] { new(12, "Tom Brady"), new(11, "Blaine Gabbert") };
        for (var i = 0; i < players.Length; i++)
        {
            chart.AddPlayer("QB", players[i], i);
        }

        var backups = chart.GetBackups("QB", players[0]);

        Assert.Equivalent(new[] { players[1] }, backups, strict: true);
    }
}