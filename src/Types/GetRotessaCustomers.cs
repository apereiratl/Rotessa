// <copyright file="GetRotessaCustomers.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    using System.Collections.Generic;

    using ServiceStack;

    /// <summary>
    /// Request to retrieve all customers.
    /// </summary>
    [Route("/customers")]
    public class GetRotessaCustomers : IGet, IReturn<List<RotessaCustomer>>
    {
    }
}