// <copyright file="RotessaError.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    /// <summary>
    /// Defines the error structure returned by the API.
    /// </summary>
    public class RotessaError
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <remarks>
        /// On HTTP 422, this will contain the validation error.
        /// </remarks>
        public string ErrorMessage { get; set; }
    }
}