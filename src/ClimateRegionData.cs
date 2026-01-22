//  Author: Robert Scheller, Melissa Lucash

using Landis.Core;
using Landis.Library.Climate;
using System.Linq;
using Landis.Library.DensityCohorts;

namespace Landis.Extension.Succession.Density
{
    public class ClimateRegionData
    {
        public static Library.Parameters.Ecoregions.AuxParm<AnnualClimate> AnnualWeather;

        //---------------------------------------------------------------------
        //public static void Initialize(IInputParameters parameters)
        public static void Initialize()
        {
            AnnualWeather = new Library.Parameters.Ecoregions.AuxParm<AnnualClimate>(PlugIn.ModelCore.Ecoregions);

            Climate.GenerateEcoregionClimateData(45.0);
        }

        public static void SetAllEcoregions_FutureAnnualClimate(int year)
        {

            foreach (var ecoregion in PlugIn.ModelCore.Ecoregions.Where(x => x.Active))
            {
                AnnualWeather[ecoregion] = Climate.FutureEcoregionYearClimate[ecoregion.Index][year];      // Climate data year index is 1-based
            }
            //int actualYear = Climate.Future_MonthlyData.Keys.Min() + year - 1;
            //foreach (IEcoregion ecoregion in PlugIn.ModelCore.Ecoregions)
            //{
            //    if (ecoregion.Active)
            //    {
            //        //PlugIn.ModelCore.UI.WriteLine("Retrieving {0} for year {1}.", spinupOrfuture.ToString(), actualYear);
            //        if (Climate.Future_MonthlyData.ContainsKey(actualYear))
            //        {
            //            AnnualWeather[ecoregion] = Climate.Future_MonthlyData[actualYear][ecoregion.Index];
            //        }

            //        //PlugIn.ModelCore.UI.WriteLine("Utilizing Climate Data: Simulated Year = {0}, actualClimateYearUsed = {1}.", actualYear, AnnualWeather[ecoregion].Year);
            //    }

            //}
        }
    }
}
