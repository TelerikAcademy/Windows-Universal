using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovingBallWithAccelerometerDemo.ViewModels
{
    public class BallViewModel : ViewModelBase
    {
        private const double DefaultBallSpeed = 10;

        public BallViewModel(double radius, double x, double y)
            :this(radius, x, y, DefaultBallSpeed)
        {
        }
        public BallViewModel(double radius, double x, double y, double speed)
        {
            this.Diameter = radius;
            this.Position = new PositionViewModel(x, y);
            this.Speed = speed;
        }

        public double Diameter { get; set; }

        public PositionViewModel Position { get; set; }

        public double Speed { get; set; }
    }
}
