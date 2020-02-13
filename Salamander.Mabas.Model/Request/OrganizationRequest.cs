using System.Collections.Generic;

namespace Salamander.Mabas.Model.Domain
{
    /// <summary>
    /// OrganizationRequest
    /// </summary>
    public class OrganizationRequest
    {
        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        public RequestData Item { get; set; }
    }

    /// <summary>
    /// RequestData Class.
    /// </summary>
    public class RequestData
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Gets or sets the records per page.
        /// </summary>
        /// <value>
        /// The records per page.
        /// </value>
        public int RecordsPerPage { get; set; } = 10;

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public IList<FilterModel> Filter { get; set; }
    }

    /// <summary>
    /// FilterModel Class.
    /// </summary>
    public class FilterModel
    {
        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>
        /// The field.
        /// </value>
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets the operation.
        /// </summary>
        /// <value>
        /// The operation.
        /// </value>
        public string Operation { get; set; } = "EQ";

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public IList<string> Value { get; set; }
    }
}