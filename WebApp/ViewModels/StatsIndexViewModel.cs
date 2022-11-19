using System.Collections.Generic;

namespace WebApp.ViewModels
{
    public class StatsIndexViewModel
    {
        public Dictionary<string, double> TolerableUpperIntakeLevels { get; set; } = default!;
        public Dictionary<string, double> PersonRecommendedUpperIntakeLevels { get; set; } = default!;
        public Dictionary<string, double> ConsumedFoodItems { get; set; } = default!;
        public Dictionary<string, double> ConsumedNutrients { get; set; } = default!;
        
    }
}