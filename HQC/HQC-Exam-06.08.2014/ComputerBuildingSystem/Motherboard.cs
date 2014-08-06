namespace Computers
{
    using global::Computers.Contracts;

    public class Motherboard : IMotherboard
    {
        public Motherboard(RandomAcessMemory ram, IVideoCard videoCard)
        {
            this.RandomAcessMemory = ram;
            this.VideoCard = videoCard;
        }

        public RandomAcessMemory RandomAcessMemory { get; set; }

        public IVideoCard VideoCard { get; set; }

        public int LoadRamValue()
        {
            return this.RandomAcessMemory.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.RandomAcessMemory.SaveValue(value);
        }

        public void DrawOnVideoCard(string data)
        {
            this.VideoCard.Draw(data);
        }
    }
}
