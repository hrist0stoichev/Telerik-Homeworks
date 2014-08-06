namespace Computers.Contracts
{
    public interface IVideoCard
    {
        bool IsMonochrome { get; set; }

        void Draw(string textToDraw);
    }
}
