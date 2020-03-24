using Newtonsoft.Json;

namespace Salamander.Mabas.Model.Request
{
    /// <summary>
    /// UserPersonalRequest Class.
    /// </summary>
    public class UserPersonalRequest
    {
        /// <summary>
        /// Gets or sets the time zone identifier.
        /// </summary>
        /// <value>
        /// The time zone identifier.
        /// </value>
        public string TimeZoneId { get; set; } = "Centeral Standard Time";

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        public UserPersonalRequestModel Item { get; set; }
    }

    /// <summary>
    /// UserPersonalModel Class.
    /// </summary>
    public class UserPersonalRequestModel
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [JsonProperty(PropertyName = "EMail")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the student identifier.
        /// </summary>
        /// <value>
        /// The student identifier.
        /// </value>
        [JsonProperty(PropertyName = "StudentID")]
        public string StudentId { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>
        /// The birth date.
        /// </value>
        public string BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the other identifier.
        /// </summary>
        /// <value>
        /// The other identifier.
        /// </value>
        [JsonProperty(PropertyName = "OtherID")]
        public string OtherId { get; set; }

        /// <summary>
        /// Gets or sets the phone numbers.
        /// </summary>
        /// <value>
        /// The phone numbers.
        /// </value>
        public PhoneNumbersModel PhoneNumbers { get; set; }

        /// <summary>
        /// Gets or sets the responder pk.
        /// </summary>
        /// <value>
        /// The responder pk.
        /// </value>
        [JsonProperty(PropertyName = "ResponderPK")]
        public int ResponderPk { get; set; }
    }

    /// <summary>
    /// PhoneNumbersModel Class.
    /// </summary>
    public class PhoneNumbersModel
    {
        /// <summary>
        /// Gets or sets the home.
        /// </summary>
        /// <value>
        /// The home.
        /// </value>
        public string Home { get; set; }

        /// <summary>
        /// Gets or sets the mobile.
        /// </summary>
        /// <value>
        /// The mobile.
        /// </value>
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets the work.
        /// </summary>
        /// <value>
        /// The work.
        /// </value>
        public string Work { get; set; }
    }
}