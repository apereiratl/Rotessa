// <copyright file="RotessaFinancialTransaction.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    using System;

    /// <summary>
    /// Defines the details of a financial transaction
    /// returned by the API.
    /// </summary>
    public class RotessaFinancialTransaction
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the process date.
        /// </summary>
        public DateTimeOffset ProcessDate { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public TransactionStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the status reason.
        /// </summary>
        public TransactionStatusReason StatusReason { get; set; }

        /// <summary>
        /// Gets or sets the transaction schedule id.
        /// </summary>
        public string TransactionScheduleId { get; set; }

        /// <summary>
        /// Gets or sets the bank name.
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Gets or sets the institution number.
        /// </summary>
        public string InstitutionNumber { get; set; }

        /// <summary>
        /// Gets or sets the transit number.
        /// </summary>
        public string TransitNumber { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        public string AccountNumber { get; set; }
    }
}