using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceSheet.Models
{
    /// <summary>
    /// Represents an annotation for a photo.
    /// </summary>
    public class Annotation
    {
        /// <summary>
        /// Gets or sets the date and time when the
        /// notification was created.
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        public string Text { get; set; }
    }
}
