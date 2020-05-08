// <copyright file="RotessaTransactionScheduleBase.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    /// <summary>
    /// The rotessa transaction schedule base.
    /// </summary>
    public class RotessaTransactionScheduleBase
    {
        /// <summary>
        /// Gets or sets the amount to be charged at schedule execution.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        public string Comment { get; set; }
    }
}
