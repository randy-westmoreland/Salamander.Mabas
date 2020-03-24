using System.Collections.Generic;

namespace Salamander.Mabas.Model.Response
{
    public class UserResponse
    {
        public IList<ErrorsModel> Errors { get; set; }

        public bool Result { get; set; }

        public string TimeZoneId { get; set; }

        public IList<WarningsModel> Warnings { get; set; }
    }

    public class ErrorsModel
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public string CultureName { get; set; }

        public string DescriptionData { get; set; }

        public IList<FieldModel> Field { get; set; }

        public int IndexPosition { get; set; }
    }

    public class WarningsModel
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public string CultureName { get; set; }

        public string DescriptionData { get; set; }

        public IList<FieldModel> Field { get; set; }

        public int IndexPosition { get; set; }
    }

    public class FieldModel
    {
        public string FieldName { get; set; }

        public string RecordIndex { get; set; }

        public string Value { get; set; }
    }

    public class DataModel
    {
        public int PrimaryKey { get; set; }
    }
}