using System.ComponentModel;

namespace Shared.Enums;

public enum Gender
{
    [Description("Undefined")] Undefined = 1,
    [Description("Male")] Male,
    [Description("Female")] Female,
}
