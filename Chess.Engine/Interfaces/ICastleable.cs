namespace Chess.Engine.Interfaces
{
    public interface ICastleable
    {
        bool CanCastle { get; set; }

        void Castle();
    }
}
