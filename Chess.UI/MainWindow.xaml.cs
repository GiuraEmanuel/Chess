using Chess.Engine;
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
            DrawChessBoard();
        }

        public void DrawChessBoard()
        {
            int totalRows = 8;
            int totalColumns = 8;

            for (int row = 0; row < totalRows; row++)
            {
                BoardGrid.ColumnDefinitions.Add(new ColumnDefinition());
                BoardGrid.RowDefinitions.Add(new RowDefinition());

                for (int column = 0; column < totalColumns; column++)
                {
                    var border = new Border
                    {
                        Height = 50,
                        Width = 50,
                        BorderThickness = new Thickness(1, 1, 1, 1),
                         
                    };
                    BoardGrid.Children.Add(border);
                    Grid.SetColumn(border, column);
                    Grid.SetRow(border, row);

                    if ((row + column) % 2 == 0)
                    {
                        border.Background = Brushes.White;
                    }
                    else
                    {
                        border.Background = Brushes.Black;
                    }
                }
            }
        }
    }
}