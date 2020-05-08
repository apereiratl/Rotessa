// <copyright file="RotessaCustomerBase.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    /// <summary>
    /// Defines base class for Rotessa customer.
    /// </summary>
    public class RotessaCustomerBase
    {
        /// <summary>
        /// Gets or sets the full name for the customer.
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
        public CreateRotessaAddress Address { get; set; }

        /// <summary>
        /// Gets or sets the customer type.
        /// </summary>
        public CustomerType? CustomerType { get; set; }
    }
}