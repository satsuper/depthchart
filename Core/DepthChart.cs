using System.Collections;

namespace Core;

public class DepthChart<P> : IEnumerable<KeyValuePair<P, IEnumerable<Player>>> where P : notnull
{
    private readonly Dictionary<P, List<Player>> _positionLookup = [];

    public void AddPlayer(P position, Player player, int? depth)
    {
        throw new NotImplementedException();
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
