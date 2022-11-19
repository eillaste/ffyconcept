using System.Collections.Generic;
using Domain.App;

namespace WebApp.ViewModels.Test
{
    public class TestViewModel
    {
        public ICollection<StandardUnit> StandardUnits { get; set; } = default!;
    }
}