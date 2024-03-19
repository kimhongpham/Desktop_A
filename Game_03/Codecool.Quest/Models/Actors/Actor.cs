namespace Codecool.Quest.Models.Actors {
    
    public abstract class Actor : IDrawable {
        public Cell Cell { get; private set; }

        public virtual int Health { get; set; }

        public virtual bool isAlive { get; set; }
        public virtual bool canMove { get; set; }
        public virtual bool isHit { get; set; }
        public virtual int Score { get; set; }



        public int X { get => this.Cell.X; }
        public int Y { get => this.Cell.Y; }
        public abstract string TileName { get; set; }

        public Actor(Cell cell) {
            this.Cell = cell;
            this.Cell.Actor = this;
        }
        
        public void Move(int dx, int dy) {
            if (this.canMove)
            {
                Cell nextCell = this.Cell.GetNeighbor(dx, dy);
                this.Cell.Actor = null;
                nextCell.Actor = this;
                this.Cell = nextCell;
            }
        }

    }
}
