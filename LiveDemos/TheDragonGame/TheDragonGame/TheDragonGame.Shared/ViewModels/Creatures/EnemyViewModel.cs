using System;
using System.Collections.Generic;
using System.Text;

namespace TheDragonGame.ViewModels.Creatures
{
    public class EnemyViewModel : GameObjectViewModel
    {
        private const string EnemyImageSource = "images/ponny.png";
        public EnemyViewModel(double top, double left)
            : base(top, left, 75, EnemyImageSource)
        {
        }
    }
}
