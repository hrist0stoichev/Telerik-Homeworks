namespace Computers
{
    using System;

    using global::Computers.Contracts;

    public class VideoCard : IVideoCard
    {
        public VideoCard(bool isMonochrome)
        {
            this.IsMonochrome = isMonochrome;
        }

        public bool IsMonochrome { get; set; }

        public void Draw(string textToDraw)
        {
            if (this.IsMonochrome)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(textToDraw);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(textToDraw);
                Console.ResetColor();
            }
        }
    }
}
