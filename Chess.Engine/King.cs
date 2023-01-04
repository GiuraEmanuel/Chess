namespace Chess.Engine
{
    public class King : Piece
    {
        public bool CanCastle { get; private set; } = true;

        public override List<Move> GetMoves(int row, int column, Board board, bool attackMovesOnly)
        {
            var validMoves = new List<Move>();
            var enemyColor = Color == PlayerColor.White ? PlayerColor.Black : PlayerColor.White;

            if (CanCastle && !attackMovesOnly && !board.CanAttackPosition(enemyColor, row, column))
            {
                var leftRook = board.GetPieceAt(row, 0) as Rook;
                var rightRook = board.GetPieceAt(row, 7) as Rook;

                if (leftRook != null && leftRook.CanCastle)
                {
                    if (board.GetPieceAt(row, 1) == null &&
                        board.GetPieceAt(row, 2) == null &&
                        board.GetPieceAt(row, 3) == null &&
                        !board.CanAttackPosition(enemyColor, row, 1) &&
                        !board.CanAttackPosition(enemyColor, row, 2) &&
                        !board.CanAttackPosition(enemyColor, row, 3))
                    {
                        validMoves.Add(new Move(row, 2));
                    }
                }

                if (rightRook != null && rightRook.CanCastle)
                {
                    if (board.GetPieceAt(row, 5) == null &&
                        board.GetPieceAt(row, 6) == null &&
                        !board.CanAttackPosition(enemyColor, row, 5) &&
                        !board.CanAttackPosition(enemyColor, row, 6))
                    {
                        validMoves.Add(new Move(row, 6));
                    }
                }
            }
            AddMove(row - 1, column, validMoves, board); // up
            AddMove(row + 1, column, validMoves, board); // down
            AddMove(row, column + 1, validMoves, board); // right
            AddMove(row, column - 1, validMoves, board); // left
            AddMove(row - 1, column + 1, validMoves, board); //top right
            AddMove(row - 1, column - 1, validMoves, board); // top left
            AddMove(row + 1, column + 1, validMoves, board); // bottom right
            AddMove(row + 1, column - 1, validMoves, board); // bottom left

            #region backup
            //if (attackMovesOnly || !board.CanAttackPosition(enemyColor, row - 1, column))
            //{
            //    AddMove(row - 1, column, validMoves, board); // up
            //}

            //if (attackMovesOnly || !board.CanAttackPosition(enemyColor, row + 1, column))
            //{
            //    AddMove(row + 1, column, validMoves, board); // down
            //}

            //if (attackMovesOnly || !board.CanAttackPosition(enemyColor, row, column + 1))
            //{
            //    AddMove(row, column + 1, validMoves, board); // right
            //}

            //if (attackMovesOnly || !board.CanAttackPosition(enemyColor, row, column - 1))
            //{
            //    AddMove(row, column - 1, validMoves, board); // left
            //}

            //if (attackMovesOnly || !board.CanAttackPosition(enemyColor, row - 1, column + 1))
            //{
            //    AddMove(row - 1, column + 1, validMoves, board); //top right
            //}

            //if (attackMovesOnly || !board.CanAttackPosition(enemyColor, row - 1, column - 1))
            //{
            //    AddMove(row - 1, column - 1, validMoves, board); // top left
            //}

            //if (attackMovesOnly || !board.CanAttackPosition(enemyColor, row + 1, column + 1))
            //{
            //    AddMove(row + 1, column + 1, validMoves, board); // bottom right
            //}

            //if (attackMovesOnly || !board.CanAttackPosition(enemyColor, row + 1, column - 1))
            //{
            //    AddMove(row + 1, column - 1, validMoves, board); // bottom left
            //}

            //AddMove(row, column, -1, 0, validMoves, board); // up
            //AddMove(row, column, 1, 0, validMoves, board); // down
            //AddMove(row, column, 0, 1, validMoves, board); // right
            //AddMove(row, column, 0, -1, validMoves, board); // left
            //AddMove(row, column, -1, 1, validMoves, board); //top right
            //AddMove(row, column, -1, -1, validMoves, board); // top left
            //AddMove(row, column, 1, 1, validMoves, board); // bottom right
            //AddMove(row, column, 1, -1, validMoves, board); // bottom left
            #endregion

            return validMoves;
        }

        public override void Move(int fromRow, int fromColumn, int toRow, int toColumn, Board board)
        {
            base.Move(fromRow, fromColumn, toRow, toColumn, board);
            var boardCopy = board;


            if (fromColumn - toColumn == 2)
            {
                boardCopy.Move(fromRow, 0, toRow, 3);
            }
            else if (toColumn - fromColumn == 2)
            {
                boardCopy.Move(fromRow, 7, toRow, 5);
            }

            CanCastle = false;
        }
    }
}
