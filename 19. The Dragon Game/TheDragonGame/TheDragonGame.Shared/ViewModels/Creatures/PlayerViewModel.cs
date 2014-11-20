using System;
using System.Collections.Generic;
using System.Text;

namespace TheDragonGame.ViewModels.Creatures
{
    public class PlayerViewModel : GameObjectViewModel
    {
        private const string PlayerImageSource = "images/dragon.png";

        public PlayerViewModel(double top, int left)
            : base(top, left, PlayerImageSource)
        {
        }
    }
}
