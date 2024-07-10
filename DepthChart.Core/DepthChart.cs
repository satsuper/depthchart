using System.Collections;

namespace DepthChart.Core;

public class DepthChart<P> : IEnumerable<KeyValuePair<P, IEnumerable<Player>>> where P : notnull
{
    private readonly Dictionary<P, List<Player>> _positionLookup = [];

    public void AddPlayer(P position, Player player, int? depth = null)
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
            if(depth < 0)
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

    public Player RemovePlayer(P position, Player player)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Player> GetBackups(P position, Player player)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<KeyValuePair<P, IEnumerable<Player>>> GetEnumerator()
    {
        foreach (var positionList in _positionLookup)
        {
            yield return new KeyValuePair<P, IEnumerable<Player>>(positionList.Key, positionList.Value);
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
