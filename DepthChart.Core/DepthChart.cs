using System.Collections;

namespace DepthChart.Core;

public class DepthChart<TPosition, TPlayer> : IEnumerable<KeyValuePair<TPosition, IEnumerable<TPlayer>>>
    where TPosition : notnull
    where TPlayer : IPlayer
{
    private readonly Dictionary<TPosition, List<TPlayer>> _positionLookup = [];

    public void AddPlayer(TPosition position, TPlayer player, int? depth = null)
    {
        if (!_positionLookup.TryGetValue(position, out var playerList))
        {
            playerList = [];
            _positionLookup[position] = playerList;
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
    }

    public TPlayer RemovePlayer(TPosition position, TPlayer player)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TPlayer> GetBackups(TPosition position, TPlayer player)
    {
        throw new NotImplementedException();
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
