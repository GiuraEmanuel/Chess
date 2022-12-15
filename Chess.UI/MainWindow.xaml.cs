using Chess.Engine;
using Chess.UI.Controls;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
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
        BoardPosition[,] _boardPositions = new BoardPosition[8,8];

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