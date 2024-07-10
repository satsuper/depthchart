using DepthChart.Core;
using DepthChart.Core.Display;

namespace DepthChart.Examples.NFL
{
    public class NflDepthCharts
    {
        private readonly Dictionary<string, DepthChart<NflPositions, Player>> _teamCharts = [];
        private readonly ConsoleDepthChartDisplay<NflPositions, Player> _depthChartDisplay = new();

        public NflDepthCharts()
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
            var players = new Dictionary<NflPositions, Player[]>()
            {
                {NflPositions.LWR, new Player[] { new(13, "Mike Evans"), new(18, "Rakim Jarrett"), new(28, "Cephus Johnson III"), new(83, "Cody Thompson") }},
                {NflPositions.RWR, new Player[] { new(10, "Trey Palmer"), new(25, "Sterling Shepard"), new(81, "Ryan Miller"), new(85, "Latreal Jones"), new(80, "Tanner Knue") }},
                {NflPositions.SWR, new Player[] { new(14, "Chris Godwin"), new(15, "Jalen McMillan"), new(17, "Raleigh Webb"), new(9, "Kameron Johnson") }},
                {NflPositions.LT, new Player[] { new(78, "Tristan Wirfs"), new(77, "Justin Skule"), new(61, "Silas Dzansi") }},
                {NflPositions.LG, new Player[] { new(68, "Ben Bredeson"), new(79, "Elijah Klein"), new(60, "Xavier Delgado") }},
                {NflPositions.C, new Player[] { new(62, "Graham Barton"), new(70, "Robert Hainsey"), new(66, "Avery Jones") }},
                {NflPositions.RG, new Player[] { new(69, "Cody Mauch"), new(76, "Sua Opeta"), new(72, "Luke Haggard"), new(71, "Lorenz Metz") }},
                {NflPositions.RT, new Player[] { new(67, "Luke Goedeke"), new(73, "Brandon Walton") }},
                {NflPositions.TE, new Player[] { new(88, "Cade Otton"), new(41, "Ko Kieft"), new(87, "Payne Durham"), new(82, "Devin Culp"), new(89, "David Wells"), new(84, "Tanner Taula") }},
                {NflPositions.QB, new Player[] { new(6, "Baker Mayfield"), new(2, "Kyle Trask"), new(11, "John Wolford"), new(19, "Zack Annexstad") }},
                {NflPositions.RB, new Player[] { new(1, "Rachaad White"), new(7, "Bucky Irving"), new(22, "Chase Edmonds"), new(44, "Sean Tucker"), new(30, "D.J. Williams"), new(45, "Ramon Jefferson") }},
                {NflPositions.LDE, new Player[] { new(90, "Logan Hall"), new(92, "William Gholston"), new(95, "C.J. Brewer"), new(75, "Lwal Uguak"), new(74, "Earnest Brown") }},
                {NflPositions.NT, new Player[] { new(50, "Vita Vea"), new(96, "Greg Gaines") }},
                {NflPositions.RDE, new Player[] { new(94, "Calijah Kancey"), new(91, "Mike Greene"), new(93, "Eric Banks"), new(59, "Judge Culpepper") }},
                {NflPositions.LOLB, new Player[] { new(9, "Joe Tryon-Shoyinka"), new(98, "Anthony Nelson"), new(33, "Jose Ramirez"), new(58, "Markees Watts"), new(57, "Daniel Grzesiak") }},
                {NflPositions.LILB, new Player[] { new(52, "K.J. Britt"), new(51, "J.J. Russell"), new(53, "Vi Jones"), new(48, "Antonio Grier Jr.") }},
                {NflPositions.RILB, new Player[] { new(54, "Lavonte David"), new(8, "SirVocea Dennis"), new(46, "Kalen DeLoach") }},
                {NflPositions.ROLB, new Player[] { new(0, "Yaya Diaby"), new(43, "Chris Braswell"), new(56, "Randy Gregory"), new(49, "Shaun Peterson Jr.") }},
                {NflPositions.LCB, new Player[] { new(27, "Zyon McCollum"), new(34, "Bryce Hall"), new(24, "Tyrek Funderburk"), new(21, "Andrew Hayes") }},
                {NflPositions.SS, new Player[] { new(3, "Jordan Whitehead"), new(23, "Tykee Smith"), new(38, "Rashad Wisdom") }},
                {NflPositions.FS, new Player[] { new(31, "Antoine Winfield Jr."), new(26, "Kaevon Merriweather"), new(39, "Marcus Banks") }},
                {NflPositions.RCB, new Player[] { new(35, "Jamel Dean"), new(32, "Josh Hayes"), new(16, "Keenan Isaac"), new(36, "Chris McDonald") }},
                {NflPositions.NB, new Player[] { new(29, "Christian Izien"), new(37, "Tavierre Thomas") }}
            };
            _teamCharts["Tampa Bay Buccaneers"] = CreateChart(players);

            players = new Dictionary<NflPositions, Player[]>
            {
                { NflPositions.LWR, new Player[] { new(9, "Christian Watson"), new(80, "Bo Melton"), new(2, "Alex McGough"), new(81, "Julian Hicks") }},
                { NflPositions.RWR, new Player[] { new(87, "Romeo Doubs"), new(18, "Malik Heath"), new(86, "Grant DuBose"), new(19, "Dimitri Stanley") }},
                { NflPositions.SWR, new Player[] { new(11, "Jayden Reed"), new(13, "Dontayvion Wicks"), new(83, "Samori Toure") }},
                { NflPositions.LT, new Player[] { new(63, "Rasheed Walker"), new(72, "Caleb Jones"), new(79, "Travis Glover"), new(76, "Kadeem Telfort") }},
                { NflPositions.LG, new Player[] { new(74, "Elgton Jenkins"), new(70, "Royce Newman"), new(67, "Donovan Jennings") }},
                { NflPositions.C, new Player[] { new(71, "Josh Myers"), new(62, "Jacob Monk"), new(61, "Lecitus Smith") }},
                { NflPositions.RG, new Player[] { new(77, "Jordan Morgan"), new(75, "Sean Rhyan") }},
                { NflPositions.RT, new Player[] { new(50, "Zach Tom"), new(73, "Andre Dillard"), new(78, "Luke Tenuta") }},
                { NflPositions.TE, new Player[] { new(88, "Luke Musgrave"), new(85, "Tucker Kraft"), new(84, "Tyler Davis"), new(89, "Ben Sims"), new(82, "Joel Wilson"), new(43, "Messiah Swinson") }},
                { NflPositions.QB, new Player[] { new(10, "Jordan Love"), new(6, "Sean Clifford"), new(17, "Michael Pratt") }},
                { NflPositions.RB, new Player[] { new(8, "Josh Jacobs"), new(32, "MarShawn Lloyd"), new(28, "AJ Dillon"), new(31, "Emanuel Wilson"), new(38, "Ellis Merriweather"), new(35, "Jarveon Howard") }},
                { NflPositions.FB, new Player[] { new(44, "Henry Pearson") }},
                { NflPositions.LDE, new Player[] { new(52, "Rashan Gary"), new(90, "Lukas Van Ness"), new(96, "Colby Wooden"), new(51, "Keshawn Banks"), new(98, "Kenneth Odumegwu") }},
                { NflPositions.NT, new Player[] { new(97, "Kenny Clark"), new(93, "T.J. Slaton"), new(99, "Jonathan Ford") }},
                { NflPositions.DT, new Player[] { new(95, "Devonte Wyatt"), new(94, "Karl Brooks"), new(64, "Spencer Waege"), new(65, "James Ester") }},
                { NflPositions.RDE, new Player[] { new(91, "Preston Smith"), new(55, "Kingsley Enagbare"), new(57, "Brenton Cox Jr."), new(53, "Arron Mosby"), new(49, "Deslin Alexandre") }},
                { NflPositions.WLB, new Player[] { new(7, "Quay Walker"), new(59, "Ty'Ron Hopper"), new(45, "Eric Wilson"), new(46, "Christian Young") }},
                { NflPositions.MLB, new Player[] { new(56, "Edgerrin Cooper"), new(58, "Isaiah McDuffie"), new(54, "Kristian Welch"), new(44, "Ralen Goforth") }},
                { NflPositions.LCB, new Player[] { new(21, "Eric Stokes"), new(37, "Carrington Valentine"), new(22, "Robert Rochell"), new(41, "Gemon Green") }},
                { NflPositions.SS, new Player[] { new(29, "Xavier McKinney"), new(27, "Kitan Oladapo"), new(39, "Zayne Anderson"), new(24, "Tyler Coyle") }},
                { NflPositions.FS, new Player[] { new(20, "Javon Bullard"), new(33, "Evan Williams"), new(36, "Anthony Johnson Jr."), new(48, "Benny Sapp III") }},
                { NflPositions.RCB, new Player[] { new(23, "Jaire Alexander"), new(26, "Corey Ballentine"), new(34, "Kalen King") }},
                { NflPositions.NB, new Player[] { new(25, "Keisean Nixon"), new(30, "Zyon Gilbert") }}
            };

            _teamCharts["Green Bay Packers"] = CreateChart(players);
        }

        private static DepthChart<NflPositions, Player> CreateChart(Dictionary<NflPositions, Player[]> playerList)
        {
            var chart = new DepthChart<NflPositions, Player>();
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
