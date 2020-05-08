// <copyright file="RotessaCustomer.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Details returned for a customer by the Rotessa API.
    /// </summary>
    public class RotessaCustomer
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the full name of the customer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the custom identifier.
        /// </summary>
        /// <remarks>
        /// Must be unique to the customer.
        /// </remarks>
        public string CustomIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        public bool Active { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the financial transactions.
        /// </summary>
        public List<RotessaFinancialTransaction> FinancialTransactions { get; set; }

        public string Identifier { get; set; }

        public string Phone { get; set; }

        public List<RotessaTransactionSchedule> TransactionSchedules { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the home phone.
        /// </summary>
        public string HomePhone { get; set; }

        /// <summary>
        /// Gets or sets the cell phone.
        /// </summary>
        public string CellPhone { get; set; }

        /// <summary>
        /// Gets or sets the bank name for the customer.
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Gets or sets the institution number.
        /// </summary>
        /// <remarks>
        /// Three digit institution number.
        /// </remarks>
        public string InstitutionNumber { get; set; }

        /// <summary>
        /// Gets or sets the transit number.
        /// </summary>
        /// <remarks>
        /// 5 digit transit number for Canadian banks.
        /// </remarks>
        public string TransitNumber { get; set; }

        /// <summary>
        /// Gets or sets the bank account type.
        /// </summary>
        /// <remarks>
        /// Required for American customers.
        /// </remarks>
        public AccountType? BankAccountType { get; set; }

        /// <summary>
        /// Gets or sets the authorization type.
        /// </summary>
        /// <remarks>
        /// Required for American customers.
        /// </remarks>
        public AuthorizationType? AuthorizationType { get; set; }

        /// <summary>
        /// Gets or sets the routing number.
        /// </summary>
        /// <remarks>
        /// Required for American customers.
        /// </remarks>
        public string RoutingNumber { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public RotessaAddress Address { get; set; }

        /// <summary>
        /// Gets or sets the customer type.
        /// </summary>
        public CustomerType? CustomerType { get; set; }
    }
}