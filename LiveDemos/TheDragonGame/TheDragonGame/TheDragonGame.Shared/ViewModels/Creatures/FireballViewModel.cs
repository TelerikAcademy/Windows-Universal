using System;
using System.Collections.Generic;
using System.Text;

namespace TheDragonGame.ViewModels.Creatures
{
    public class FireballViewModel : GameObjectViewModel
    {
        private const string FireballImageSource = "images/fireball.png";
        private const double FireballWidth = 40.0;

        public const double Speed = 15;

        public FireballViewModel(double top, double left)
            : base(top, left, FireballWidth, FireballImageSource)
        {

        }
        public FireballViewModel(double top, double left, double width)
            : base(top, left, width, FireballImageSource)
        {

        }
    }
}
