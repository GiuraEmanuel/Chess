namespace Chess.Engine
{
    public abstract class Piece
    {
        public PlayerColor Color { get; set; }

        public abstract List<Move> GetMoves(int row, int column, Board board, bool attackMovesOnly);

        public virtual void Move(int fromRow, int fromColumn, int toRow, int toColumn, Board board)
        {
            board.SetPieceAt(toRow, toColumn, this);
            board.SetPieceAt(fromRow, fromColumn, null);
        }

        // Adds all the moves in the given direction (rook, bishop, queen)
        protected void AddAllDirectionMoves(int row, int column, int rowOffset, int columnOffset, List<Move> validMoves, Board board)
        {
            int resultRow = row + rowOffset;
            int resultColumn = column + columnOffset;


            while (resultRow <= 7 && resultRow >= 0 && resultColumn <= 7 && resultColumn >= 0)
            {
                var capturablePiece = board.GetPieceAt(resultRow, resultColumn);

                if (capturablePiece == null || Color != capturablePiece.Color)
                {
                    validMoves.Add(new Move(resultRow, resultColumn));
                }

                if (capturablePiece != null)
                {
                    return;
                }

                resultRow += rowOffset;
                resultColumn += columnOffset;
            }
        }

        protected void AddMove(int row, int column, List<Move> validMoves, Board board)
        {
            if (row <= 7 && row >= 0 && column <= 7 && column >= 0)
            {
                var capturablePiece = board.GetPieceAt(row, column);

                if (capturablePiece == null || Color != capturablePiece.Color)
                {
                    validMoves.Add(new Move(row, column));
                }
            }
        }
    }
}
