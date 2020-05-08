// <copyright file="UpdateRotessaTransactionSchedule.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    using ServiceStack;

    /// <summary>
    /// The update transaction schedule.
    /// </summary>
    [Route("/transaction_schedules/{Id}")]
    public class UpdateRotessaTransactionSchedule : RotessaTransactionScheduleBase, IPut, IReturn<RotessaTransactionSchedule>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public long Id { get; set; }
    }
}
