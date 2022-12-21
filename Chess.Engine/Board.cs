namespace Chess.Engine
{
    public class Board
    {
        private Piece?[,] _pieces = new Piece[8, 8];

        public Board()
        {
            // black
            _pieces[0, 0] = new Rook() { Color = PlayerColor.Black };
            _pieces[0, 1] = new Knight() { Color= PlayerColor.Black };
            _pieces[0, 2] = new Bishop() { Color = PlayerColor.Black };
            _pieces[0, 3] = new Queen() { Color = PlayerColor.Black };
            _pieces[0, 4] = new King() { Color = PlayerColor.Black };
            _pieces[0, 5] = new Bishop() { Color = PlayerColor.Black };
            _pieces[0, 6] = new Knight() { Color = PlayerColor.Black };
            _pieces[0, 7] = new Rook() { Color = PlayerColor.Black };

            _pieces[1, 0] = new Pawn() { Color = PlayerColor.Black };
            _pieces[1, 1] = new Pawn() { Color = PlayerColor.Black };
            _pieces[1, 2] = new Pawn() { Color = PlayerColor.Black }; 
            _pieces[1, 3] = new Pawn() { Color = PlayerColor.Black };
            _pieces[1, 4] = new Pawn() { Color = PlayerColor.Black };
            _pieces[1, 5] = new Pawn() { Color = PlayerColor.Black };
            _pieces[1, 6] = new Pawn() { Color = PlayerColor.Black };
            _pieces[1, 7] = new Pawn() { Color = PlayerColor.Black };

            //empty positions
            _pieces[2, 0] = null;
            _pieces[2, 1] = null;
            _pieces[2, 2] = null;
            _pieces[2, 3] = null;
            _pieces[2, 4] = null;
            _pieces[2, 5] = null;
            _pieces[2, 6] = null;
            _pieces[2, 7] = null;

            _pieces[3, 0] = null;
            _pieces[3, 1] = null;
            _pieces[3, 2] = null;
            _pieces[3, 3] = null;
            _pieces[3, 4] = null;
            _pieces[3, 5] = null;
            _pieces[3, 6] = null;
            _pieces[3, 7] = null;

            _pieces[4, 0] = null;
            _pieces[4, 1] = null;
            _pieces[4, 2] = null;
            _pieces[4, 3] = null;
            _pieces[4, 4] = null;
            _pieces[4, 5] = null;
            _pieces[4, 6] = null;
            _pieces[4, 7] = null;

            _pieces[5, 0] = null;
            _pieces[5, 1] = null;
            _pieces[5, 2] = null;
            _pieces[5, 3] = null;
            _pieces[5, 4] = null;
            _pieces[5, 5] = null;
            _pieces[5, 6] = null;
            _pieces[5, 7] = null;

            //white
            _pieces[6, 0] = new Pawn() { Color = PlayerColor.White };
            _pieces[6, 1] = new Pawn() { Color = PlayerColor.White };
            _pieces[6, 2] = new Pawn() { Color = PlayerColor.White };
            _pieces[6, 3] = new Pawn() { Color = PlayerColor.White };
            _pieces[6, 4] = new Pawn() { Color = PlayerColor.White };
            _pieces[6, 5] = new Pawn() { Color = PlayerColor.White };
            _pieces[6, 6] = new Pawn() { Color = PlayerColor.White };
            _pieces[6, 7] = new Pawn() { Color = PlayerColor.White };

            _pieces[7, 0] = new Rook() { Color = PlayerColor.White };
            _pieces[7, 1] = new Knight() { Color = PlayerColor.White };
            _pieces[7, 2] = new Bishop() { Color = PlayerColor.White };
            _pieces[7, 3] = new Queen() { Color = PlayerColor.White };
            _pieces[7, 4] = new King() { Color = PlayerColor.White };
            _pieces[7, 5] = new Bishop() { Color = PlayerColor.White };
            _pieces[7, 6] = new Knight() { Color = PlayerColor.White };
            _pieces[7, 7] = new Rook() { Color = PlayerColor.White };
        }

        public Piece? GetPieceAt(int row, int column)
        {
            return _pieces[row, column];
        }
    }
}
