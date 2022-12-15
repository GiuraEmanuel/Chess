using Chess.Engine.Interfaces;

namespace Chess.Engine
{
    public class King : Piece, ICastleable
    {

        public override bool CanMove { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool CanBeCaptured { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool CanCastle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool canBeCheckMated { get; set; }

        public void Castle()
        {
            throw new NotImplementedException();
        }

        public override void GetValidMoves()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
