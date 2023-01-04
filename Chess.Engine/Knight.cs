namespace Chess.Engine
{
    public class Knight : Piece
    {
        public override List<Move> GetMoves(int row, int column, Board board, bool attackMovesOnly)
        {
            var validMoves = new List<Move>();

            AddMove(row - 2, column + 1, validMoves, board); // up: 2 rows, right 1 column
            AddMove(row - 2, column - 1, validMoves, board); // up: 2 rows, left 1 column
            AddMove(row + 2, column + 1, validMoves, board); // down: 2 rows, right 1 column
            AddMove(row + 2, column - 1, validMoves, board); // down: 2 rows, left 1 column
            AddMove(row - 1, column + 2, validMoves, board); // right: 1 row up, right 2 columns 
            AddMove(row + 1, column + 2, validMoves, board); // right: 1 row down,right 2 columns
            AddMove(row - 1, column - 2, validMoves, board); // left: 1 row up, left 2 columns 
            AddMove(row + 1, column - 2, validMoves, board); // left: 1 row down, left 2 columns

            return validMoves;
        }
    }
}
