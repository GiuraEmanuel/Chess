using Chess.Engine;
using System;
using System.Net.Http.Headers;
using System.Windows.Controls;
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

    }
}
