// <copyright file="RotessaGatewayCanadianTransactionScheduleTests.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Tests
{
    using FluentAssertions;

    using NUnit.Framework;

    using RubricEm.Rotessa.Types;

    /// <summary>
    /// Defines tests for Transaction Schedule operations.
    /// </summary>
    public class RotessaGatewayCanadianTransactionScheduleTests : TestBase
    {
        /// <summary>
        /// Tests whether a transaction schedule can be created using valid Canadian bank information.
        /// </summary>
        [Test]
        public void Can_Create_Transaction_Schedule_Valid_Bank_Info()
        {
            var customerRequest = CreateCompleteRotessaCustomerRequest();
            var createdCustomer = this.gateway.Post(customerRequest);

            var transactionScheduleRequest = CreateRotessaTransactionScheduleRequest(createdCustomer.Id);
            var createdTransactionSchedule = this.gateway.Post(transactionScheduleRequest);
            createdTransactionSchedule.Should().BeEquivalentTo(transactionScheduleRequest, options => options.Excluding(x => x.Comment).Excluding(x => x.CustomerId));

            // The API modifies the comment and includes the string API creation notice.
            Assert.AreEqual($"{transactionScheduleRequest.Comment} (Created with API)", createdTransactionSchedule.Comment);
        }

        /// <summary>
        /// Tests whether a transaction scheduled can be updated using valid Canadian bank information.
        /// </summary>
        [Test]
        public void Can_Update_Transaction_Schedule_Valid_Bank_Info()
        {
            var customerRequest = CreateCompleteRotessaCustomerRequest();
            var createdCustomer = this.gateway.Post(customerRequest);

            var transactionScheduleRequest = CreateRotessaTransactionScheduleRequest(createdCustomer.Id);
            var createdTransactionSchedule = this.gateway.Post(transactionScheduleRequest);

            var updateScheduleRequest = new UpdateRotessaTransactionSchedule
                                            {
                                                Id = createdTransactionSchedule.Id,
                                                Amount = (decimal)25.0,
                                                Comment = "I've amended the contract, pray I do not amend it further."
                                            };

            var updatedTransactionSchedule = this.gateway.Put(updateScheduleRequest);

            updatedTransactionSchedule.Should().BeEquivalentTo(updateScheduleRequest);
        }

        /// <summary>
        /// Tests whether a transaction schedule can be deleted.
        /// </summary>
        [Test]
        public void Can_Delete_Transaction_Schedule_Valid_Bank_Info()
        {
            var customerRequest = CreateCompleteRotessaCustomerRequest();
            var createdCustomer = this.gateway.Post(customerRequest);

            var transactionScheduleRequest = CreateRotessaTransactionScheduleRequest(createdCustomer.Id);
            var createdTransactionSchedule = this.gateway.Post(transactionScheduleRequest);

            var deleteTransactionScheduleRequest = new DeleteTransactionScheduleRequest
                                                       {
                                                           Id = createdTransactionSchedule.Id
                                                       };

            Assert.DoesNotThrow(() => this.gateway.Delete(deleteTransactionScheduleRequest));
        }
    }
}
