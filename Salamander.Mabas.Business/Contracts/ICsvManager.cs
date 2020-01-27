namespace Salamander.Mabas.Business.Contracts
{
    /// <summary>
    /// ICsvManager Class.
    /// </summary>
    public interface ICsvManager
    {
        /// <summary>
        /// Loads the CSV.
        /// </summary>
        /// <param name="path">The path.</param>
        void LoadCsv(string path);
    }
}