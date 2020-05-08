// <copyright file="UpdateRotessaCustomer.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    using ServiceStack;

    /// <summary>
    /// Defines the details for an update to a customer.
    /// </summary>
    [Route("/customers/{Id}")]
    public class UpdateRotessaCustomer : RotessaCustomerBase, IPut, IReturn<RotessaCustomer>
    {
        /// <summary>
        /// Gets or sets the id of the customer to be updated.
        /// </summary>
        public long Id { get; set; }
    }
}
