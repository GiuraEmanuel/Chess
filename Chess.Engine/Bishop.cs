namespace Chess.Engine
{
    public class Bishop : Piece
    {
        public override List<ValidMove> GetValidMoves(int row, int column, Board board)
        {
            var validMoves = new List<ValidMove>();

            AddAllDirectionMoves(row, column, -1, 1, validMoves, board); // top right
            AddAllDirectionMoves(row, column, -1, -1, validMoves, board); // top left
            AddAllDirectionMoves(row, column, 1, 1, validMoves, board); // bottom right
            AddAllDirectionMoves(row, column, 1, -1, validMoves, board); // bottom left


            return validMoves;
        }
    }
}
