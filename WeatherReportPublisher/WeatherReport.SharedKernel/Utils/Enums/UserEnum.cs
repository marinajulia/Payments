using System.ComponentModel;

namespace WeatherReport.SharedKernel.Utils.Enums
{
    public enum UserEnum
    {
        [Description("Oops.. The name must be typed")]
        FieldNameEmpty,

        [Description("Oops.. The email must be typed")]
        FieldEmailEmpty,

        [Description("Oops.. The password must be typed")]
        FieldPasswordEmpty,

        [Description("Oops.. The city must be typed")]
        FieldCityEmpty,

        [Description("Oops.. Incorrect username or password")]
        IncorrectUsernameOrPassword,
    }
}
