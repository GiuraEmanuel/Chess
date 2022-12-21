namespace Chess.Engine
{
    public abstract class Piece
    {
        public PlayerColor Color { get; set; }

        public abstract bool CanMove { get; set; }

        public abstract bool CanBeCaptured { get; set; }

        public abstract void Move();

        public abstract void GetValidMoves();
    }
}
