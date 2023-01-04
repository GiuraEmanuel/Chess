namespace Chess.Engine
{
    public class Pawn : Piece
    {
        public override List<Move> GetMoves(int row, int column, Board board, bool attackMovesOnly)
        {
            var validMoves = new List<Move>();

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

            if (board.GetPieceAt(row + forward, column) == null && !attackMovesOnly)
            {
                validMoves.Add(new Move(row + forward, column));

                if (row == startingRow && board.GetPieceAt(row + forward * 2, column) == null)
                {
                    validMoves.Add(new Move(row + forward * 2, column));
                }
            }

            if (column < 7)
            {
                if (attackMovesOnly)
                {
                    validMoves.Add(new Move(row + forward, column + 1));
                }
                else
                {
                    var rightCapturablePiece = board.GetPieceAt(row + forward, column + 1);

                    // captures right side
                    if (rightCapturablePiece != null && Color != rightCapturablePiece.Color)
                    {
                        validMoves.Add(new Move(row + forward, column + 1));
                    }
                }
            }

            if (column > 0)
            {
                if (attackMovesOnly)
                {
                    validMoves.Add(new Move(row + forward, column - 1));
                }
                else
                {
                    var leftCapturablePiece = board.GetPieceAt(row + forward, column - 1);

                    // captures left side
                    if (leftCapturablePiece != null && Color != leftCapturablePiece.Color)
                    {
                        validMoves.Add(new Move(row + forward, column - 1));
                    }
                }
            }

            return validMoves;
        }

        public override void Move(int fromRow, int fromColumn, int toRow, int toColumn, Board board)
        {
            base.Move(fromRow, fromColumn, toRow, toColumn, board);

            if (toRow == 0 || toRow == 7)
            {
                board.SetPieceAt(toRow, toColumn, new Queen { Color = Color });
            }
        }
    }
}