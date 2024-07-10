namespace DepthCharts.Core.Display
{
    public class ConsoleDepthChartDisplay<TPosition, TPlayer>
        where TPosition : notnull
        where TPlayer : class, IPlayer
    {
        public void WriteChart(DepthChart<TPosition, TPlayer> chart)
        {
            ArgumentNullException.ThrowIfNull(chart);

            foreach (var positionPlayerPair in chart)
            {
                var position = positionPlayerPair.Key;
                var players = string.Join(", ", positionPlayerPair.Value);
                Console.WriteLine($"{position} - {players}");
            }
        }
    }
}
