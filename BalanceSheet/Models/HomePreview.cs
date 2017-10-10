using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BalanceSheet.Models
{
    public class HomePreview
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the photo thumbnails.
        /// </summary>
        /// <value>
        /// The photo thumbnails.
        /// </value>
        //[IgnoreDataMember]
        //public List<PhotoThumbnail> PhotoThumbnails { get; set; }

    }
}