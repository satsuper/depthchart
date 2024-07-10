namespace DepthCharts.Core
{
    public record Player(int Number, string Name) : IPlayer
    {
        public override string ToString() => $"(#{Number}, {Name})";
    }
}
