using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovingBallWithAccelerometerDemo.ViewModels
{
    public class PositionViewModel : ViewModelBase
    {
        private double x;
        private double y;
        public double X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
                this.RaisePropertyChanged(() => this.X);
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
                this.RaisePropertyChanged(() => this.Y);
            }
        }

        public PositionViewModel(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
