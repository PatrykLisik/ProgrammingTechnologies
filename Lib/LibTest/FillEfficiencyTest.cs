using System;
using System.Diagnostics;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibTest
{
    
    [TestClass]
    public class FillerAndDataRepositoryEfficiencyTest
    {
        //I can run it at 7 but out of memory exception may happen if google chrome is in use
        const int MaxExponentiation = 6;
        private IDataFiller SetUpRandomFiller(int amount)
        {
            IDataFiller filler = new RandomFiller(amount);
            return filler;
        }
        private IDataFiller SetUpConstFiller(int amount)
        {
            IDataFiller filler = new ConstFiller(amount);
            return filler;
        }
        private TimeSpan Time(Action toTime)
        {
            var timer = Stopwatch.StartNew();
            toTime();
            timer.Stop();
            return timer.Elapsed;
        }
       void FillRepo(IDataFiller filler)
        {
            var Repo = new DataRepository();
            Repo.SetFiller(filler);
            Repo.Fill();
        }
        void FillerEfficiency(Func<int,IDataFiller> filler)
        {
            for (int i = 0; i < MaxExponentiation; i++)
            {

                var Fill = new Action(() => FillRepo(filler(9 * (int)Math.Pow(10, i))));
                var timeSpan = Time(Fill);
                Assert.AreEqual(-1, TimeSpan.Compare(timeSpan, TimeSpan.FromSeconds(100)));
                Console.WriteLine(String.Format("TIME OF {0} TESTS {1}", i, timeSpan));
            }
        }
        [TestMethod]
        public void RandomFillerEfficiency()
        {

            FillerEfficiency(SetUpRandomFiller);


        }
        [TestMethod]
        public void ConstFillerEfficiency()
        {
            FillerEfficiency(SetUpConstFiller);
        }
    }
}
