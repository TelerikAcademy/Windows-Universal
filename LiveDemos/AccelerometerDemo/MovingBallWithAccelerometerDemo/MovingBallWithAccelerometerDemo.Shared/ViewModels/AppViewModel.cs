using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MovingBallWithAccelerometerDemo.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        private double width;
        private double height;


        public AppViewModel()
        {
            //this.Width = width;
            //this.Height = height;
            var balls = new ObservableCollection<BallViewModel>();

            balls.Add(new BallViewModel(40, 150, 150, 15));
            balls.Add(new BallViewModel(40, 150, 150, 35));

            this.Balls = balls;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
                this.RaisePropertyChanged(() => this.Width);
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
                this.RaisePropertyChanged(() => this.Height);
            }
        }

        private bool InRange(double value, double min, double max)
        {
            return (min <= value && value <= max);
        }

        public IEnumerable<BallViewModel> Balls { get; set; }

        public void MoveBallsWithDelta(double dx, double dy)
        {
            foreach (var ball in this.Balls)
            {
                var x = ball.Position.X + ball.Speed * dx;
                var y = ball.Position.Y + ball.Speed * dy;
                if (this.InRange(x, 0, this.Height - ball.Diameter))
                {
                    ball.Position.X = x;
                }

                if (this.InRange(y, 0, this.Width - ball.Diameter))
                {
                    ball.Position.Y = y;
                }
            }
        }

    }
}
