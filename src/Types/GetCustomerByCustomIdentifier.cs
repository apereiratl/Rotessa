// <copyright file="GetCustomerByCustomIdentifier.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    using ServiceStack;

    /// <summary>
    /// The get customer by custom identifier.
    /// </summary>
    [Route("/customers/show_with_custom_identifier")]
    public class GetCustomerByCustomIdentifier : IReturn<RotessaCustomer>
    {
        /// <summary>
        /// Gets or sets the custom identifier of the customer
        /// to be retrieved.
        /// </summary>
        public string CustomIdentifier { get; set; }
    }
}
