using System.Data.Common;

namespace Chess.Engine
{
    public abstract class Piece
    {
        public PlayerColor Color { get; set; }

        public abstract List<ValidMove> GetValidMoves(int row, int column, Board board);

        // Adds all the moves in the given direction (rook, bishop, queen)
        protected void AddAllDirectionMoves(int row, int column, int rowOffset, int columnOffset, List<ValidMove> validMoves, Board board)
        {
            int resultRow = row + rowOffset;
            int resultColumn = column + columnOffset;


            while (resultRow <= 7 && resultRow >= 0 && resultColumn <= 7 && resultColumn >= 0)
            {
                var capturablePiece = board.GetPieceAt(resultRow, resultColumn);

                if (capturablePiece == null || Color != capturablePiece.Color)
                {
                    validMoves.Add(new ValidMove(resultRow, resultColumn));
                }

                if (capturablePiece != null)
                {
                    return;
                }

                resultRow += rowOffset;
                resultColumn+= columnOffset;
            }
        }

        protected void AddMove(int row, int column, int rowOffset, int columnOffset, List<ValidMove> validMoves, Board board)
        {
            int resultRow = row + rowOffset;
            int resultColumn = column + columnOffset;

            if (resultRow <= 7 && resultRow >= 0 && resultColumn <= 7 && resultColumn >= 0)
            {
                var capturablePiece = board.GetPieceAt(resultRow, resultColumn);
                if (capturablePiece == null || Color != capturablePiece.Color)
                {
                    validMoves.Add(new ValidMove(resultRow, resultColumn));
                }
            }
        }
    }
}
