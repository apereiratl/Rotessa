// <copyright file="CreateRotessaCustomer.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    using ServiceStack;

    /// <summary>
    /// Defines details required for customer creation.
    /// </summary>
    [Route("/customers")]
    public class CreateRotessaCustomer : RotessaCustomerBase, IPost, IReturn<RotessaCustomer>
    {
    }
}