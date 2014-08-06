namespace Computers.Contracts
{
    /// <summary>
    /// Interface for loading values from the RAM, saving values to the RAM and drawing on the video card.
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// Loads the saved integer from the RAM
        /// </summary>
        /// <returns>Returns the loaded integer from the RAM</returns>
        int LoadRamValue();

        /// <summary>
        /// Saves an integer to the RAM
        /// </summary>
        /// <param name="value">The value to be saved to the RAM</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Draws a data string on the video card
        /// </summary>
        /// <param name="data">The data to be drawn by the video card</param>
        void DrawOnVideoCard(string data);
    }
}
