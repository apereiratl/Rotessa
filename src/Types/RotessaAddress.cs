// <copyright file="RotessaAddress.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    /// <summary>
    /// Defines the details for the address object returned by
    /// the API.
    /// </summary>
    public class RotessaAddress : CreateRotessaAddress
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public long Id { get; set; }
    }
}