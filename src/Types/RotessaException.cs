// <copyright file="RotessaException.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    public class RotessaException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RotessaException"/> class.
        /// </summary>
        /// <param name="error">
        /// The error.
        /// </param>
        public RotessaException(RotessaErrors error)
        {
            this.Errors = error.Errors;
        }

        public List<RotessaError> Errors { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
