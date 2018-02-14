using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Testing
{
    public class SplitCamelCase
    {
        public int InitialScore { get; set; }
        public int ScoreGoal { get; set; }
        public string S { get; set; }
        //private IGator Gator;
        //private IActions Action;
        //private ILog Log;

        public SplitCamelCase(int score, int scoreGoal)
        {
            InitialScore = score;
            ScoreGoal = scoreGoal;
            //Gator = gator;
            //Action = gator.Action;
            //Log = gator.Log;
        }

        public static string CamelSplit(string inputString)
        {
            return Regex.Replace(
                   inputString,
                  "([^^])([A-Z])",
                  "$1 $2"
                  );
        }

        //public void RepetetiveSteps(string name, int wantedHandler)
        //{
        //    var s = CamelSplit(name);

        //    var nameSplit = s.Split(' ');
        //    var miniGame = String.Format("{0} {1}", nameSplit[0], nameSplit[1]);
        //    var MinigameMove = miniGame;

        //    Log.Info(String.Format("Starting Repeat Tier of {0} {1}.", nameSplit[0], nameSplit[1]));

        //    while (InitialScore < ScoreGoal)
        //    {
        //        var worldCompose = String.Format("world{0}{1}Select", nameSplit[0], nameSplit[1]);
        //        var secondCall = String.Format("{0} {1}", nameSplit[0], nameSplit[1]);

        //        int newScore = minAct.MinigameHandler(worldCompose, secondCall, wantedHandler);

        //        InitialScore = minAct.MinigameUpdateScore(InitialScore, newScore);
        //        Log.Info("Total score: " + InitialScore);

        //        var screenshotName = String.Format("Tier_{2}_{0}_{1}", nameSplit[2], nameSplit[0], nameSplit[1]);
        //        minAct.ScreenshotWithCount(screenshotName);

        //    }
        //}

        public static string GetMethodName(StackTrace st)
        {
            return st.GetFrame(0).GetMethod().Name;
        }


    }
}
