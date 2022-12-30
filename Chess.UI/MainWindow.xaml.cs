using Chess.Engine;
using Chess.UI.Controls;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Chess.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitChessBoard();
            UpdateChessBoard();
        }


        private Board _board = new Board();
        BoardPosition[,] _boardPositions = new BoardPosition[8, 8];
        private PlayerColor _playerColor = PlayerColor.White;

        private BoardPosition? _selectedPosition;

        public void InitChessBoard()
        {
            int totalRows = 8;
            int totalColumns = 8;

            for (int row = 0; row < totalRows; row++)
            {
                BoardGrid.ColumnDefinitions.Add(new ColumnDefinition());
                BoardGrid.RowDefinitions.Add(new RowDefinition());

                for (int column = 0; column < totalColumns; column++)
                {
                    var boardPosition = new BoardPosition();

                    boardPosition.MouseLeftButtonDown += BoardPosition_MouseLeftButtonDown;

                    _boardPositions[row, column] = boardPosition;

                    BoardGrid.Children.Add(boardPosition);
                    Grid.SetColumn(boardPosition, column);
                    Grid.SetRow(boardPosition, row);

                    if ((row + column) % 2 == 0)
                    {
                        boardPosition.Background = Brushes.Wheat;
                    }
                    else
                    {
                        boardPosition.Background = Brushes.Black;
                    }
                }
            }
        }

        private void BoardPosition_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var clickedPosition = (BoardPosition)sender;

            if (_selectedPosition == null)
            {
                // no square has been selected yet
                if (clickedPosition.Piece == null || clickedPosition.Piece.Color != _playerColor)
                {
                    // Only allow selecting a piece that is your own color
                    return;
                }

                _selectedPosition = clickedPosition;
                _selectedPosition.IsHighlighted = true;
            }
            else if (_selectedPosition == clickedPosition)
            {
                // clicking on an already selected square deselects it
                _selectedPosition = null;
                clickedPosition.IsHighlighted = false;

            }
            else // a position was already selected but a different position was clicked
            {
                if (clickedPosition.Piece == null || clickedPosition.Piece.Color != _playerColor)
                {
                    // an empty position or opponent's piece was clicked

                    var fromRow = Grid.GetRow(_selectedPosition);
                    var fromColumn = Grid.GetColumn(_selectedPosition);

                    var toRow = Grid.GetRow(clickedPosition);
                    var toColumn = Grid.GetColumn(clickedPosition);

                    var validMoves = _board.GetValidMoves(fromRow, fromColumn, _board);

                    if (!validMoves.Any(vm => vm.Row == toRow && vm.Column == toColumn))
                    {
                        return;
                    }

                    _board.Move(fromRow, fromColumn, toRow, toColumn);


                    _selectedPosition.IsHighlighted = false;
                    _selectedPosition = null;
                    UpdateChessBoard();

                    if (_playerColor == PlayerColor.White)
                    {
                        _playerColor = PlayerColor.Black;
                    }
                    else
                    {
                        _playerColor = PlayerColor.White;
                    }
                    CurrentPlayer.Text = $"Current player: {_playerColor}";
                }
                else
                {
                    // a different piece that is the player's own piece was clicked
                    _selectedPosition.IsHighlighted = false;
                    _selectedPosition = clickedPosition;
                    _selectedPosition.IsHighlighted = true;
                }
            }

            UpdateHighlights();
        }

        private void UpdateHighlights()
        {
            foreach (var boardPosition in _boardPositions)
            {
                boardPosition.IsHighlighted = false;
            }

            if (_selectedPosition != null)
            {
                _selectedPosition.IsHighlighted = true;

                var fromRow = Grid.GetRow(_selectedPosition);
                var fromColumn = Grid.GetColumn(_selectedPosition);

                var validMoves = _board.GetValidMoves(fromRow, fromColumn, _board);

                foreach (var vm in validMoves)
                {
                    _boardPositions[vm.Row, vm.Column].IsHighlighted = true;
                }
            }
        }

        private void UpdateChessBoard()
        {
            int totalRows = 8;
            int totalColumns = 8;

            for (int row = 0; row < totalRows; row++)
            {
                for (int column = 0; column < totalColumns; column++)
                {
                    _boardPositions[row, column].Piece = _board.GetPieceAt(row, column);
                }
            }
        }
    }
}


