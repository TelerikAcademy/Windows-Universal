using System;
using System.Collections.Generic;
using System.Text;

namespace TheDragonGame.ViewModels.Creatures
{
    public class InfernoViewModel: FireballViewModel
    {
        private const double InfernoWidth = 100;
        public InfernoViewModel(double top, double left)
            : base(top, left, InfernoWidth)
        {

        }
    }
}
