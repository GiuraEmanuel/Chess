namespace Chess.Engine
{
    public class Rook : Piece
    {
        public bool CanCastle { get; private set; } = true;

        public override List<Move> GetMoves(int row, int column, Board board, bool attackMovesOnly)
        {
            var validMoves = new List<Move>();

            AddAllDirectionMoves(row, column, -1, 0, validMoves, board); // up
            AddAllDirectionMoves(row, column, 1, 0, validMoves, board); // down
            AddAllDirectionMoves(row, column, 0, 1, validMoves, board); // right
            AddAllDirectionMoves(row, column, 0, -1, validMoves, board); // left

            return validMoves;
        }

        public override void Move(int fromRow, int fromColumn, int toRow, int toColumn, Board board)
        {
            base.Move(fromRow, fromColumn, toRow, toColumn, board);
            CanCastle = false;
        }
    }
}
