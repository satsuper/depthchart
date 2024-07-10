using DepthCharts.Core;
using DepthCharts.Core.Display;

namespace DepthCharts.Examples.NBA
{
    public class NbaDepthCharts
    {
        private readonly Dictionary<string, DepthChart<NbaPositions, Player>> _teamCharts = [];
        private readonly ConsoleDepthChartDisplay<NbaPositions, Player> _depthChartDisplay = new();

        public NbaDepthCharts()
        {
            Initialise();
        }

        public void DisplayAllCharts()
        {
            foreach (var teamChart in _teamCharts)
            {
                Console.WriteLine(teamChart.Key);
                _depthChartDisplay.WriteChart(teamChart.Value);
                Console.WriteLine();
            }
        }

        private void Initialise()
        {
            var players = new Dictionary<NbaPositions, Player[]>
            {
                {NbaPositions.PG, new Player[] {new(1, "D. Russell"), new(7, "G. Vincent"), new(3, "B. James"), new(15, "A. Reaves"), new(0, "J. Hood-Schifino"), new(23, "L. James")} },
                {NbaPositions.SG, new Player[] {new(15, "A. Reaves"), new(10, "M. Christie"), new(7, "G. Vincent"), new(4, "D. Knecht"), new(5, "C. Reddish"), new(0, "J. Hood-Schifino"), new(23, "L. James")} },
                {NbaPositions.SF, new Player[] {new(23, "L. James"), new(5, "C. Reddish"), new(4, "D. Knecht"), new(28, "R. Hachimura"), new(10, "M. Christie"), new(15, "A. Reaves"), new(21, "M. Lewis"), new(36, "B. Hinson")} },
                {NbaPositions.PF, new Player[] {new(28, "R. Hachimura"), new(2, "J. Vanderbilt"), new(23, "L. James"), new(35, "C. Wood"), new(3, "A. Davis"), new(11, "J. Hayes"), new(21, "M. Lewis"), new(37, "A. Traore")} },
                {NbaPositions.C, new Player[] {new(3, "A. Davis"), new(2, "J. Vanderbilt"), new(11, "J. Hayes"), new(35, "C. Wood"), new(28, "R. Hachimura"), new(23, "L. James"), new(14, "C. Castleton")} }
            };

            _teamCharts["LA Lakers"] = CreateChart(players);
        }

        private static DepthChart<NbaPositions, Player> CreateChart(Dictionary<NbaPositions, Player[]> playerList)
        {
            var chart = new DepthChart<NbaPositions, Player>();
            foreach (var positionPlayerPair in playerList)
            {
                foreach (var player in positionPlayerPair.Value)
                {
                    chart.AddPlayer(positionPlayerPair.Key, player);
                }
            }
            return chart;
        }
    }
}
