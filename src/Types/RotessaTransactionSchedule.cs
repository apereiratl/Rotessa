// <copyright file="RotessaTransactionSchedule.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the details returned for a transaction
    /// schedule.
    /// </summary>
    public class RotessaTransactionSchedule
    {
        /// <summary>
        /// Gets or sets the id of the transaction schedule.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the amount to be charged at schedule execution.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the time at which the transaction schedule was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the financial transactions.
        /// </summary>
        public List<RotessaFinancialTransaction> FinancialTransactions { get; set; }

        /// <summary>
        /// Gets or sets the frequency at which the amount will be debited.
        /// </summary>
        public FrequencyType Frequency { get; set; }

        /// <summary>
        /// Gets or sets the number of allowed installments.
        /// </summary>
        /// <remarks>
        /// Infinite if null is specified.
        /// </remarks>
        public long? Installments { get; set; }

        /// <summary>
        /// Gets or sets the next process date.
        /// </summary>
        public DateTimeOffset? NextProcessDate { get; set; }

        /// <summary>
        /// Gets or sets the initial date on which to being withdrawing funds.
        /// </summary>
        public DateTimeOffset ProcessDate { get; set; }

        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
