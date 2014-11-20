using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheDragonGame.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private double width;
        private double height;
        public GameViewModel Game { get; set; }

        public MainPageViewModel(double width, double height)
        {
            this.Width = width;
            this.Height = height;

            this.Game = new GameViewModel(this.Width, this.Height);
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
                if (this.Game != null)
                {
                    this.Game.Width = this.Width;
                }
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
                if (this.Game != null)
                {
                    this.Game.Height = this.Height;
                }
            }
        }

        public void StartGame()
        {
            this.Game.Start();
        }

        public void MovePlayer(double deltaTop)
        {
            this.Game.MovePlayer(deltaTop);
        }

        public void PlayeAttack()
        {
            this.Game.Attack();
        }

        public void PlayerUltraAttack()
        {
            this.Game.UltraAttack();
        }
    }
}
