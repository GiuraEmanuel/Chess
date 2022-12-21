using Chess.Engine;
using Chess.UI.Controls;
using System;
using System.Data.Common;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Color = System.Windows.Media.Color;
using Size = System.Drawing.Size;

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
                    var boardPosition = new BoardPosition
                    {
                        Height = 50,
                        Width = 50,
                        BorderThickness = new Thickness(1, 1, 1, 1),
                    };

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
                clickedPosition.IsHighlighted = true;
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

                    // TODO: Move the piece
                    _selectedPosition.IsHighlighted = false;
                    _selectedPosition = null;
                    UpdateChessBoard();
                    if (_playerColor == PlayerColor.White)
                    {
                        _playerColor = PlayerColor.Black;
                    }
                    else
                    {
                        _playerColor= PlayerColor.White;
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
        }

        public void UpdateChessBoard()
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


