using Chess.Engine;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chess.UI.Controls
{
    /// <summary>
    /// Interaction logic for BoardPosition.xaml
    /// </summary>
    public partial class BoardPosition : UserControl
    {
        public BoardPosition()
        {
            InitializeComponent();
        }

        private Piece? _piece;

        private bool _isHighlighted;

        public Piece? Piece
        {
            get => _piece;
            set
            {
                _piece = value;

                if (value == null)
                {
                    PieceImage.Source = null;
                    return;
                }

                var imagePath = value.Color.ToString().Substring(0,1) + "-" + value.GetType().Name + ".png";
                var uriSource = new Uri(@"/Chess.UI;component/Images/" + imagePath, UriKind.Relative);
                PieceImage.Source = new BitmapImage(uriSource);
            }
        }

        public bool IsHighlighted
        {
            get => _isHighlighted;
            set
            {
                _isHighlighted = value;

                if (_isHighlighted)
                {
                    BorderBrush = Brushes.ForestGreen;
                    BorderThickness = new Thickness(3, 3, 3, 3);
                }
                else
                {
                    BorderBrush = null;
                    BorderThickness = new Thickness(0, 0, 0, 0);
                }    
            }
        }
    }
}
