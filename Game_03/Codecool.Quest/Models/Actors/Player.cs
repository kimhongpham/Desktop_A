using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Codecool.Quest.Models.Actors
{

    public class Player : Actor {
        public override string TileName { get; set; } = "player";
    
        public override int Health { get; set; } = 3;

        public readonly int maxHealth = 3;

        public int Score { get; set; } = 0;

        //public override int Defense { get; set; } = 0;
        public override bool canMove { get; set; } = true;
        public override bool isAlive { get; set; } = true;

        public bool gameWin = false;

        public Player(Cell cell) : base(cell) 
        {
        }

        public void checkPlayerDead()
        {
            if( this.Health <= 0)
            {
                isAlive = false;
            }
        }
    }
}
