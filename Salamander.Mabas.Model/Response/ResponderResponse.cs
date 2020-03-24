using System.Collections.Generic;

namespace Salamander.Mabas.Model.Response
{
    /// <summary>
    /// ErrorsModel Class.
    /// </summary>
    public class ErrorsModel
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name of the culture.
        /// </summary>
        /// <value>
        /// The name of the culture.
        /// </value>
        public string CultureName { get; set; }

        /// <summary>
        /// Gets or sets the description data.
        /// </summary>
        /// <value>
        /// The description data.
        /// </value>
        public string DescriptionData { get; set; }

        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>
        /// The field.
        /// </value>
        public List<FieldModel> Field { get; set; }

        /// <summary>
        /// Gets or sets the index position.
        /// </summary>
        /// <value>
        /// The index position.
        /// </value>
        public int IndexPosition { get; set; }
    }

    /// <summary>
    /// WarningsModel Class.
    /// </summary>
    public class WarningsModel
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name of the culture.
        /// </summary>
        /// <value>
        /// The name of the culture.
        /// </value>
        public string CultureName { get; set; }

        /// <summary>
        /// Gets or sets the description data.
        /// </summary>
        /// <value>
        /// The description data.
        /// </value>
        public string DescriptionData { get; set; }

        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>
        /// The field.
        /// </value>
        public List<FieldModel> Field { get; set; }

        /// <summary>
        /// Gets or sets the index position.
        /// </summary>
        /// <value>
        /// The index position.
        /// </value>
        public int IndexPosition { get; set; }
    }

    /// <summary>
    /// FieldModel Class.
    /// </summary>
    public class FieldModel
    {
        /// <summary>
        /// Gets or sets the name of the field.
        /// </summary>
        /// <value>
        /// The name of the field.
        /// </value>
        public string FieldName { get; set; }

        /// <summary>
        /// Gets or sets the index of the record.
        /// </summary>
        /// <value>
        /// The index of the record.
        /// </value>
        public string RecordIndex { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }
    }
}