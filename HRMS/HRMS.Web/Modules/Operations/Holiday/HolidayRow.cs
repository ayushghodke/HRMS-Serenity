using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace HRMS.Operations;

[ConnectionKey("Default"), Module("Operations"), TableName("Holidays")]
[DisplayName("Holidays"), InstanceName("Holiday")]
[ReadPermission("Operations:Leave")]
[ModifyPermission("Operations:Leave")]
[LookupScript]
public sealed class HolidayRow : Row<HolidayRow.RowFields>, IIdRow, INameRow
{
    [DisplayName("Holiday Id"), Identity, IdProperty]
    public int? HolidayId { get => fields.HolidayId[this]; set => fields.HolidayId[this] = value; }

    [DisplayName("Holiday Name"), Size(150), NotNull, QuickSearch, NameProperty]
    public string HolidayName { get => fields.HolidayName[this]; set => fields.HolidayName[this] = value; }

    [DisplayName("Holiday Date"), NotNull]
    public DateTime? HolidayDate { get => fields.HolidayDate[this]; set => fields.HolidayDate[this] = value; }

    [DisplayName("Holiday Type"), NotNull, DefaultValue(Operations.HolidayType.CompanyHoliday)]
    public HolidayType? HolidayType { get => (HolidayType?)fields.HolidayType[this]; set => fields.HolidayType[this] = (int?)value; }

    [DisplayName("Branch"), Size(100)]
    public string Branch { get => fields.Branch[this]; set => fields.Branch[this] = value; }

    [DisplayName("Applicable Departments"), Size(2000)]
    public string ApplicableDepartments { get => fields.ApplicableDepartments[this]; set => fields.ApplicableDepartments[this] = value; }

    [DisplayName("Is Optional Holiday"), NotNull]
    public bool? IsOptionalHoliday { get => fields.IsOptionalHoliday[this]; set => fields.IsOptionalHoliday[this] = value; }

    [DisplayName("Year"), NotNull]
    public int? Year { get => fields.Year[this]; set => fields.Year[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field HolidayId;
        public StringField HolidayName;
        public DateTimeField HolidayDate;
        public Int32Field HolidayType;
        public StringField Branch;
        public StringField ApplicableDepartments;
        public BooleanField IsOptionalHoliday;
        public Int32Field Year;
    }
}

public enum HolidayType
{
    [Description("National")]
    National = 1,
    [Description("Festival")]
    Festival = 2,
    [Description("Company Holiday")]
    CompanyHoliday = 3
}
