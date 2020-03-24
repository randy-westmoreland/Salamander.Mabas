using CsvHelper.Configuration.Attributes;

namespace Salamander.Mabas.Model.Domain
{
    /// <summary>
    /// CsvDomain Class.
    /// </summary>
    public class CsvModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the tier2 person identifier.
        /// </summary>
        /// <value>
        /// The tier2 person identifier.
        /// </value>
        public string Tier2PersonID { get; set; }

        /// <summary>
        /// Gets or sets the dateof birth.
        /// </summary>
        /// <value>
        /// The dateof birth.
        /// </value>
        public string DateofBirth { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        [Name("img1")]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [Name("UserID")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the rank.
        /// </summary>
        /// <value>
        /// The rank.
        /// </value>
        public string Rank { get; set; }

        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>
        /// The date modified.
        /// </value>
        public string DateModified { get; set; }

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        /// <value>
        /// The name of the department.
        /// </value>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the team description.
        /// </summary>
        /// <value>
        /// The team description.
        /// </value>
        public string TeamDescription { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>
        /// The rate.
        /// </value>
        public string Rate { get; set; }

        /// <summary>
        /// Gets or sets the division.
        /// </summary>
        /// <value>
        /// The division.
        /// </value>
        public string Division { get; set; }

        /// <summary>
        /// Gets or sets the illinois task force.
        /// </summary>
        /// <value>
        /// The illinois task force.
        /// </value>
        [Name("ILTF1")]
        public string IllinoisTaskForce { get; set; }

        /// <summary>
        /// Gets or sets the fire department identifier.
        /// </summary>
        /// <value>
        /// The fire department identifier.
        /// </value>
        [Name("fdid")]
        public string FireDepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public string State { get; set; }
    }
}