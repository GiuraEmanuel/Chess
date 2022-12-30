using Chess.Engine.Interfaces;

namespace Chess.Engine
{
    public class King : Piece
    {
        public override List<ValidMove> GetValidMoves(int row, int column, Board board)
        {
            var validMoves = new List<ValidMove>();

            AddMove(row, column,-1, 0, validMoves, board); // up
            AddMove(row, column,1, 0, validMoves,board); // down
            AddMove(row, column,0, 1, validMoves,board); // right
            AddMove(row, column,0, -1, validMoves, board); // left
            AddMove(row, column ,- 1, 1, validMoves,board); //top right
            AddMove(row, column, -1, -1, validMoves, board); // top left
            AddMove(row, column, 1, 1, validMoves, board); // bottom right
            AddMove(row, column, 1, -1, validMoves, board); // bottom left

            return validMoves;
        }
    }
}
