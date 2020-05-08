// <copyright file="FrequencyType.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines the schedule frequency types.
    /// </summary>
    public enum FrequencyType
    {
        /// <summary>
        /// Indicates a one time payment.
        /// </summary>
        Once,

        /// <summary>
        /// Indicates that payments are retrieved every week.
        /// </summary>
        Weekly,

        /// <summary>
        /// Indicates that payments are retrieved every two weeks.
        /// </summary>
        [EnumMember(Value = "Every Other Week")]
        EveryOtherWeek,

        /// <summary>
        /// Indicates that payments are retrieved monthly.
        /// </summary>
        Monthly,

        /// <summary>
        /// Indicates that payments are retrieved every two months.
        /// </summary>
        [EnumMember(Value = "Every Other Month")]
        EveryOtherMonth,

        /// <summary>
        /// Indicates that payments are retrieved every three months.
        /// </summary>
        Quarterly,

        /// <summary>
        /// Indicates that payments are retrieved every six months.
        /// </summary>
        [EnumMember(Value = "Semi-Annually")]
        SemiAnnualy,

        /// <summary>
        /// Indicates that payments are retrieved yearly.
        /// </summary>
        Yearly,
    }
}
