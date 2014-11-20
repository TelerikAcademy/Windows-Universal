using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using TheDragonGame.ViewModels.Creatures;
using Windows.UI.Xaml;

namespace TheDragonGame.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private const int GameTimerIntervalInMilliseconds = 50;
        private const int MaxEnemiesCount = 10;
        private static readonly Random rand = new Random();

        private double width;
        private double height;
        private ObservableCollection<GameObjectViewModel> enemies;
        private ObservableCollection<GameObjectViewModel> gameObjects;
        private ObservableCollection<GameObjectViewModel> fireballs;

        private DispatcherTimer GameTimer { get; set; }

        public GameObjectViewModel Player { get; set; }

        public IEnumerable<GameObjectViewModel> Enemies
        {
            get
            {
                return this.enemies;
            }
            set
            {
                if (this.enemies == null)
                {
                    this.enemies = new ObservableCollection<GameObjectViewModel>();
                }
                this.enemies.Clear();
                this.enemies.AddRange(value);
            }
        }

        public IEnumerable<GameObjectViewModel> GameObjects
        {
            get
            {
                return this.gameObjects;
            }
            set
            {
                if (this.gameObjects == null)
                {
                    this.gameObjects = new ObservableCollection<GameObjectViewModel>();
                }
                this.gameObjects.Clear();
                this.gameObjects.AddRange(value);
            }
        }

        public ObservableCollection<GameObjectViewModel> Fireballs
        {
            get
            {
                return this.fireballs;
            }
            set
            {
                if (this.fireballs == null)
                {
                    this.fireballs = new ObservableCollection<GameObjectViewModel>();
                }
                this.fireballs.Clear();
                this.fireballs.AddRange(value);
            }
        }

        public GameViewModel(double width, double height)
        {

            this.Width = width;
            this.Height = height;
            this.GameTimer = new DispatcherTimer();
            this.GameTimer.Tick += this.GameTimerTick;
            this.GameTimer.Interval = TimeSpan.FromMilliseconds(GameTimerIntervalInMilliseconds);

            this.Player = new PlayerViewModel(0, 0);
            this.Enemies = new ObservableCollection<GameObjectViewModel>();
            this.GameObjects = new ObservableCollection<GameObjectViewModel>();
            this.Fireballs = new ObservableCollection<GameObjectViewModel>();
        }

        private void InitGame()
        {

            var playerTop = this.Height / 2;
            var playerLeft = 10;
            this.Player.Top = playerTop;
            this.Player.Left = playerLeft;

            this.gameObjects.Clear();
            this.gameObjects.Add(this.Player);

            this.enemies.Clear();

            var enemiesCount = MaxEnemiesCount;
            var enemyIndex = 0;
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += (snd, args) =>
            {
                if (enemyIndex >= enemiesCount - 1)
                {
                    timer.Stop();
                }
                var enemy = this.AddEnemyAtRandomPosition();
                this.enemies.Add(enemy);
                this.gameObjects.Add(enemy);
                enemyIndex++;
            };
            timer.Start();
            if (this.GameTimer.IsEnabled)
            {
                this.GameTimer.Stop();
            }
            this.GameTimer.Start();
        }

        public void Start()
        {
            this.InitGame();
        }

        public GameObjectViewModel AddEnemyAtRandomPosition()
        {
            var left = this.Width;
            var top = rand.Next(0, (int)this.Height - 150);
            var enemy = new EnemyViewModel(top, left);
            return enemy;
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

        public void MovePlayer(double deltaTop)
        {
            this.Player.Top += deltaTop;
        }

        private void GameTimerTick(object sender, object e)
        {
            //move enemies
            bool shouldGenerateEnemy = false;
            foreach (var enemy in this.Enemies)
            {
                var deltaTop = rand.Next(30) - 15;
                if (0 <= enemy.Top + deltaTop &&
                    enemy.Top + deltaTop <= this.Height - 100)
                {
                    enemy.Top += deltaTop;
                }
                enemy.Left += -5;
                if (enemy.Left < 0)
                {
                    enemy.IsAlive = false;
                    shouldGenerateEnemy = true;
                }
            }

            //move fireballs
            foreach (var fireball in this.Fireballs)
            {
                fireball.Left += FireballViewModel.Speed;
                if (this.Width < fireball.Left)
                {
                    fireball.IsAlive = false;
                }
                var hitEnemies = this.Enemies.Where(enemy => fireball.IsOver(enemy));
                if (hitEnemies.Any())
                {
                    foreach (var hitEnemy in hitEnemies)
                    {
                        hitEnemy.IsAlive = false;
                    }
                    if (!(fireball is InfernoViewModel))
                    {
                        fireball.IsAlive = false;
                    }
                    shouldGenerateEnemy = true;
                }
            }

            //remove destroyed game objects

            var gameObjectsToRemove = this.gameObjects.Where(go => !go.IsAlive).ToList();
            this.RemoveGameObjects(gameObjectsToRemove);

            if (shouldGenerateEnemy)
            {
                this.GenerateNewEnemies();
            }
        }

        private void GenerateNewEnemies()
        {
            while (this.enemies.Count < MaxEnemiesCount)
            {
                var enemy = this.AddEnemyAtRandomPosition();
                this.enemies.Add(enemy);
                this.gameObjects.Add(enemy);
            }
        }

        private void RemoveGameObjects(IEnumerable<GameObjectViewModel> gameObjectsToRemove)
        {
            if (!gameObjectsToRemove.Any())
            {
                return;
            }
            foreach (var gameObject in gameObjectsToRemove)
            {
                this.gameObjects.Remove(gameObject);
                if (gameObject is FireballViewModel)
                {
                    this.fireballs.Remove(gameObject);
                }
                else if (gameObject is EnemyViewModel)
                {
                    this.enemies.Remove(gameObject);
                }
            }
        }

        public void Attack()
        {
            var top = this.Player.Top;
            var left = this.Player.Left + this.Player.Width;
            var ultraAttackChance = 5;
            FireballViewModel fireball;

            if (rand.Next(100) < ultraAttackChance)
            {
                fireball = new InfernoViewModel(top, left);
            }
            else
            {
                fireball = new FireballViewModel(top, left);
            }
            this.gameObjects.Add(fireball);
            this.fireballs.Add(fireball);
        }

        public void UltraAttack()
        {
            var top = this.Player.Top;
            var left = this.Player.Left + this.Player.Width;

            var inferno = new InfernoViewModel(top, left);

            this.gameObjects.Add(inferno);
            this.fireballs.Add(inferno);

        }
    }
}
