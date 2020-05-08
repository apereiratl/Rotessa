// <copyright file="CreateRotessaTransactionSchedule.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    using ServiceStack;

    /// <summary>
    /// The transaction schedule type returned by the API.
    /// </summary>
    [Route("/transaction_schedules")]
    public class CreateRotessaTransactionSchedule : RotessaTransactionScheduleBase, IPost, IReturn<RotessaTransactionSchedule>
    {
        /// <summary>
        /// Gets or sets the id of the customer for whom
        /// the transaction schedule is being created.
        /// </summary>
        public long CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the frequency of execution.
        /// </summary>
        public FrequencyType Frequency { get; set; }

        /// <summary>
        /// Gets or sets the number of allowed installments.
        /// </summary>
        /// <remarks>
        /// Infinite if null.
        /// Must be exactly 1 for FrequencyType.Once.
        /// </remarks>
        public long? Installments { get; set; }

        /// <summary>
        /// Gets or sets the initial date on which to being withdrawing funds.
        /// </summary>
        /// <remarks>
        /// Must be at least two days into the future.
        /// </remarks>
        public RotessaProcessDate ProcessDate { get; set; }
    }
}
