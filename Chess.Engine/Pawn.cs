namespace Chess.Engine
{
    public class Pawn : Piece
    {
        public override List<ValidMove> GetValidMoves(int row, int column, Board board)
        {
            var validMoves = new List<ValidMove>();

            int forward;
            int startingRow;

            if (Color == PlayerColor.White)
            {
                forward = -1;
                startingRow = 6;
            }
            else
            {
                forward = 1;
                startingRow = 1;
            }

            if (board.GetPieceAt(row + forward, column) == null)
            {
                validMoves.Add(new ValidMove(row + forward, column));

                if (row == startingRow && board.GetPieceAt(row + forward * 2, column) == null)
                {
                    validMoves.Add(new ValidMove(row + forward * 2, column));
                }
            }

            if (column < 7)
            {
                var rightCapturablePiece = board.GetPieceAt(row + forward, column + 1);

                // captures right side
                if (rightCapturablePiece != null && Color != rightCapturablePiece.Color)
                {
                    validMoves.Add(new ValidMove(row + forward, column + 1));
                }
            }

            if (column > 0)
            {
                var leftCapturablePiece = board.GetPieceAt(row + forward, column - 1);

                // captures left side
                if (leftCapturablePiece != null && Color != leftCapturablePiece.Color)
                {
                    validMoves.Add(new ValidMove(row + forward, column - 1));
                }
            }

            return validMoves;
        }
    }
}