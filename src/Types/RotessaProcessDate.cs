// <copyright file="RotessaProcessDate.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    using System;

    /// <summary>
    /// Defines a custom date structure
    /// to be used for data output without having to
    /// resort to ugly strings.
    /// </summary>
    public class RotessaProcessDate
    {
        /// <summary>
        /// Gets or sets the month.
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// Gets or sets the day.
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Returns the serialized version of the process date to
        /// match the API.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return new DateTime(this.Year, this.Month, this.Day).ToString("MMMM d, yyyy");
        }
    }
}
