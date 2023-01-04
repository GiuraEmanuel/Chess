namespace Chess.Engine
{
    public class Board
    {
        private Piece?[,] _pieces;

        public Board()
        {
            _pieces = new Piece[8, 8];

            // black
            _pieces[0, 0] = new Rook() { Color = PlayerColor.Black };
            _pieces[0, 1] = new Knight() { Color = PlayerColor.Black };
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

        public Board(Board sourceBoard)
        {
            _pieces = (Piece[,])sourceBoard._pieces.Clone();
        }

        public Piece? GetPieceAt(int row, int column)
        {
            return _pieces[row, column];
        }

        internal void SetPieceAt(int row, int column, Piece? piece)
        {
            _pieces[row, column] = piece;
        }

        public List<Move> GetValidMoves(int row, int column, Board board)
        {
            var piece = GetPieceAt(row, column);

            if (piece == null)
            {
                throw new ArgumentException("There's no piece at the selected position.");
            }

            var validMoves = piece.GetMoves(row, column, board, false); // gets valid moves for the currently selected piece

            foreach (var move in validMoves)
            {
                var boardCopy = new Board(this);

                boardCopy.Move(row, column, move.Row, move.Column);

                if (boardCopy.CanAttackPosition(piece.Color, move.Row, move.Column))
                {

                }
            }

            return validMoves;
        }

        //private (int Row, int Column) FindKing(PlayerColor color)
        //{
        //    return 
        //}

        #region back up GetValidMoves()
        //public List<Move> GetValidMoves(int row, int column, Board board)
        //{
        //    var validMoves = new List<Move>();

        //    var piece = GetPieceAt(row, column);

        //    if (piece != null)
        //        validMoves = piece.GetMoves(row, column, board, false);

        //    return validMoves;
        //}
        #endregion

        public void Move(int fromRow, int fromColumn, int toRow, int toColumn)
        {
            var piece = _pieces[fromRow, fromColumn];

            if (piece == null)
            {
                throw new ArgumentException("There's no piece at the selected position.");
            }

            piece.Move(fromRow, fromColumn, toRow, toColumn, this);
        }

        //row, column - position that is threatened by opponent's piece
        internal bool CanAttackPosition(PlayerColor color, int row, int column)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var piece = _pieces[i, j];


                    if (piece != null && piece.Color == color)
                    {
                        var moves = piece.GetMoves(i, j, this, true);

                        foreach (var move in moves)
                        {
                            if (move.Row == row && move.Column == column)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
