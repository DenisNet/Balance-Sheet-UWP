
namespace BalanceSheet.Models
{
    /// <summary>
    /// Specifies the configuration data model
    /// </summary>
    public class Config
    {
        public string BuildVers { get; set; }

        public int CatThumSmallFromFaktor { get; set; }
        public int CatThumLargeFromFaktor { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Config" /> class.
        /// </summary>
        public Config(string buildVers, int catThumSmallFromFaktor, int catThumLargeFromFaktor)
        {
            BuildVers = buildVers;
            CatThumLargeFromFaktor = catThumLargeFromFaktor;
            CatThumSmallFromFaktor = catThumSmallFromFaktor;
        }
    }
}