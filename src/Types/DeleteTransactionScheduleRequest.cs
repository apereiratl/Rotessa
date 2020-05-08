// <copyright file="DeleteTransactionScheduleRequest.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    using ServiceStack;

    /// <summary>
    /// Defines the details for a transaction schedule request.
    /// </summary>
    [Route("/transaction_schedules/{Id}")]
    public class DeleteTransactionScheduleRequest : IDelete, IReturn<DeleteTransactionScheduleRequest>
    {
        /// <summary>
        /// Gets or sets the id of the transaction schedule to be deleted.
        /// </summary>
        public long Id { get; set; }
    }
}