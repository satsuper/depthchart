using DepthChart.Core;

namespace DepthChart.Test;

public class DepthChartTests
{
    [Fact]
    public void AddPlayerToChart()
    {
        var chart = new DepthChart<string, Player>();
        var players = new Player[] { new(12, "Tom Brady"), new(11, "Blaine Gabbert") };
        for (var i = 0; i < players.Length; i++)
        {
            chart.AddPlayer("QB", players[i], i);
        }

        var expectedPlayers = new Dictionary<string, IEnumerable<Player>>()
        {
            {"QB", players }
        };
        Assert.Equal(expectedPlayers, chart.ToDictionary());
    }

    [Fact]
    public void AddSamePlayerToChartAtMultiplePositions()
    {
        var chart = new DepthChart<string, Player>();
        var player = new Player(72, "Josh Wells");
        chart.AddPlayer("LT", player);
        chart.AddPlayer("RT", player);

        var expectedPlayers = new Dictionary<string, IEnumerable<Player>>()
        {
            {"LT", [ player ] },
            {"RT", [ player ] }
        };
        Assert.Equal(expectedPlayers, chart.ToDictionary());
    }

    [Fact]
    public void AddPlayerToChartShiftsExistingPlayers()
    {
        var chart = new DepthChart<string, Player>();
        var players = new Player[] { new(12, "Tom Brady"), new(2, "Kyle Trask") };
        for (var i = 0; i < players.Length; i++)
        {
            chart.AddPlayer("QB", players[i], i);
        }
        var newPlayer = new Player(11, "Blaine Gabbert");
        chart.AddPlayer("QB", newPlayer, 1);

        var expectedPlayers = new Dictionary<string, IEnumerable<Player>>()
        {
            {"QB", [ players[0], newPlayer, players[1] ] }
        };
        Assert.Equal(expectedPlayers, chart.ToDictionary());
    }

    [Fact]
    public void AddPlayerWithoutDepthAddsAtEnd()
    {
        var chart = new DepthChart<string, Player>();
        var players = new Player[] { new(12, "Tom Brady"), new(2, "Kyle Trask") };
        for (var i = 0; i < players.Length; i++)
        {
            chart.AddPlayer("QB", players[i], i);
        }
        var newPlayer = new Player(11, "Blaine Gabbert");
        chart.AddPlayer("QB", newPlayer);

        var expectedPlayers = new Dictionary<string, IEnumerable<Player>>()
        {
            {"QB", [ players[0], players[1], newPlayer ] }
        };
        Assert.Equal(expectedPlayers, chart.ToDictionary());
    }

    [Fact]
    public void AddSamePlayerToChartTwice()
    {
        var chart = new DepthChart<string, Player>();
        var player = new Player(12, "Tom Brady");
        chart.AddPlayer("QB", player, 0);

        Assert.Throws<ArgumentException>(() => chart.AddPlayer("QB", new Player(12, "Tom Brady"), 1));

        var expectedPlayers = new Dictionary<string, IEnumerable<Player>>()
        {
            {"QB", [ player ] }
        };
        Assert.Equal(expectedPlayers, chart.ToDictionary());
    }

    [Fact]
    public void AddPlayerToChartAtInvalidDepth()
    {
        var chart = new DepthChart<string, Player>();

        Assert.Throws<ArgumentException>(() => chart.AddPlayer("QB", new Player(12, "Tom Brady"), 1));
        Assert.Throws<ArgumentException>(() => chart.AddPlayer("QB", new Player(12, "Tom Brady"), -1));

        var expectedPlayers = new Dictionary<string, IEnumerable<Player>>();
        Assert.Equal(expectedPlayers, chart.ToDictionary());
    }

    [Fact]
    public void RemovePlayerFromChart()
    {
        var chart = new DepthChart<string, Player>();
        var players = new Player[] { new(12, "Tom Brady"), new(11, "Blaine Gabbert"), new(2, "Kyle Trask") };
        for (var i = 0; i < players.Length; i++)
        {
            chart.AddPlayer("QB", players[i], i);
        }

        var removed = chart.RemovePlayer("QB", players[1]);
        Assert.Equal(players[1], removed);

        var remainingPlayers = new Dictionary<string, IEnumerable<Player>>()
        {
            {"QB", [ players[0], players[2] ] }
        };
        Assert.Equal(remainingPlayers, chart.ToDictionary());
    }

    [Fact]
    public void RemovePlayerThatDoesNotExistFromChart()
    {
        var chart = new DepthChart<string, Player>();
        var players = new Player[] { new(12, "Tom Brady"), new(11, "Blaine Gabbert") };
        for (var i = 0; i < players.Length; i++)
        {
            chart.AddPlayer("QB", players[i], i);
        }

        var removed = chart.RemovePlayer("QB", new Player(2, "Kyle Trask"));
        Assert.Null(removed);

        var remainingPlayers = new Dictionary<string, IEnumerable<Player>>()
        {
            {"QB", players}
        };
        Assert.Equal(remainingPlayers, chart.ToDictionary());
    }

    [Fact]
    public void RemovePlayerFromChartAtMultiplePositions()
    {
        var chart = new DepthChart<string, Player>();
        var player = new Player(72, "Josh Wells");
        chart.AddPlayer("LT", player);
        chart.AddPlayer("RT", player);

        var removed = chart.RemovePlayer("RT", player);
        Assert.Equal(player, removed);

        var expectedPlayers = new Dictionary<string, IEnumerable<Player>>()
        {
            {"LT", [ player ] }
        };
        Assert.Equal(expectedPlayers, chart.ToDictionary());
    }

    [Fact]
    public void GetBackupsFromChart()
    {
        var chart = new DepthChart<string, Player>();
        var players = new Player[] { new(12, "Tom Brady"), new(11, "Blaine Gabbert"), new(2, "Kyle Trask") };
        for (var i = 0; i < players.Length; i++)
        {
            chart.AddPlayer("QB", players[i], i);
        }

        var backups = chart.GetBackups("QB", players[0]);

        Assert.Equal([players[1]], backups);
    }
}