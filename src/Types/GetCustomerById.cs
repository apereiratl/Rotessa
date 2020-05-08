// <copyright file="GetCustomerById.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    using ServiceStack;

    /// <summary>
    /// The get customer by id.
    /// </summary>
    [Route("/customers/{Id}")]
    public class GetCustomerById : IReturn<RotessaCustomer>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public long Id { get; set; }
    }
}
