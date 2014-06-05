using System.ComponentModel;

namespace PTO.Entity.Enums
{
    public enum RelationType
    {
        Parent = 1,

        Child = 2,

        Sibling = 3,

        Spouse = 4,

        Caretaker = 5,

        [Description("Emergency Contact")]
        EmergencyContact = 6,

        Unknown = 7
    }
}
