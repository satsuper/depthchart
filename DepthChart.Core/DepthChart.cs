using System.Collections;

namespace DepthChart.Core;

public class DepthChart<TPosition, TPlayer> : IEnumerable<KeyValuePair<TPosition, IEnumerable<TPlayer>>>
    where TPosition : notnull
    where TPlayer : class, IPlayer
{
    private readonly Dictionary<TPosition, List<TPlayer>> _positionLookup = [];

    public void AddPlayer(TPosition position, TPlayer player, int? depth = null)
    {
        ArgumentNullException.ThrowIfNull(position);
        ArgumentNullException.ThrowIfNull(player);

        if (!_positionLookup.TryGetValue(position, out var playerList))
        {
            playerList = [];
        }

        if (playerList.Any(p => player.Number == p.Number))
        {
            throw new ArgumentException(
                $"Player at position {position} with number {player.Number} already exists in the depth chart",
                nameof(player));
        }

        if (depth.HasValue)
        {
            if (depth < 0)
            {
                throw new ArgumentException(
                    "Position depth cannot be negative",
                    nameof(depth));
            }
            else if (depth > playerList.Count)
            {
                throw new ArgumentException(
                    $"Player at position {position} cannot be inserted at depth {depth} which is greater than current depth {playerList.Count}",
                    nameof(depth));
            }

            playerList.Insert(depth.Value, player);
        }
        else
        {
            playerList.Add(player);
        }

        // Add player list to position lookup at the end in case this is a new position and an error was encountered adding the player
        _positionLookup[position] = playerList;
    }

    public TPlayer? RemovePlayer(TPosition position, TPlayer player)
    {
        ArgumentNullException.ThrowIfNull(position);
        ArgumentNullException.ThrowIfNull(player);

        if (!_positionLookup.TryGetValue(position, out var playerList))
        {
            return null;
        }

        TPlayer? removed = null;
        var index = playerList.FindIndex(p => p.Number == player.Number);
        if (index != -1)
        {
            removed = playerList[index];
            playerList.RemoveAt(index);
        }

        if (playerList.Count == 0)
        {
            _positionLookup.Remove(position);
        }

        return removed;
    }

    public IEnumerable<TPlayer> GetBackups(TPosition position, TPlayer player)
    {
        ArgumentNullException.ThrowIfNull(position);
        ArgumentNullException.ThrowIfNull(player);

        if (!_positionLookup.TryGetValue(position, out var playerList))
        {
            return [];
        }

        if (playerList.Count <= 1)
        {
            return [];
        }

        IEnumerable<TPlayer>? backups = null;
        var index = playerList.FindIndex(p => p.Number == player.Number);
        if (index != -1)
        {
            var startIndex = index + 1;
            backups = playerList.GetRange(startIndex, playerList.Count - startIndex);
        }

        return backups ?? [];
    }

    public IEnumerator<KeyValuePair<TPosition, IEnumerable<TPlayer>>> GetEnumerator()
    {
        foreach (var positionList in _positionLookup)
        {
            yield return new KeyValuePair<TPosition, IEnumerable<TPlayer>>(positionList.Key, positionList.Value);
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
