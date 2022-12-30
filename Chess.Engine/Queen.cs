namespace Chess.Engine
{
    public class Queen : Piece
    {
        public override List<ValidMove> GetValidMoves(int row, int column, Board board)
        {
            var validMoves = new List<ValidMove>();

            AddAllDirectionMoves(row, column, -1, 0, validMoves, board); // up
            AddAllDirectionMoves(row, column, 1, 0, validMoves, board); // down
            AddAllDirectionMoves(row, column, 0, 1, validMoves, board); // right
            AddAllDirectionMoves(row, column, 0, -1, validMoves, board); // left
            AddAllDirectionMoves(row, column, -1, 1, validMoves, board); // top right
            AddAllDirectionMoves(row, column, -1, -1, validMoves, board); // top left
            AddAllDirectionMoves(row, column, 1, 1, validMoves, board); // bottom right
            AddAllDirectionMoves(row, column, 1, -1, validMoves, board); // bottom left

            return validMoves;
        }
    }
}
