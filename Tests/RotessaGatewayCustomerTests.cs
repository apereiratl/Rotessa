// <copyright file="RotessaGatewayCustomerTests.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Tests
{
    using System;
    using System.Linq;

    using FluentAssertions;

    using NUnit.Framework;

    using RubricEm.Rotessa.Types;

    /// <summary>
    /// Tests for customer operations.
    /// </summary>
    [TestFixture]
    public class RotessaGatewayCustomerTests : TestBase
    {
        /// <summary>
        /// Tests whether an incomplete customer can be created.
        /// </summary>
        [Test]
        public void Can_Create_Stub_Customer()
        {
            var request = CreateBasicRotessaCustomerRequest();
            var createdCustomer = this.CreateCustomer(request);

            // excluding address since the API returns an object with nulls
            // instead of a null member.
            createdCustomer
                .Should()
                .BeEquivalentTo(request, options => options.Excluding(x => x.Address).Excluding(x => x.CustomerType));

            // customer type always defaults to personal, even when null.
            Assert.AreEqual(createdCustomer.CustomerType, CustomerType.Personal);
        }

        /// <summary>
        /// Tests whether an incomplete customer can be retrieved.
        /// </summary>
        [Test]
        public void Can_Get_Stub_Customer_By_Id()
        {
            var request = CreateBasicRotessaCustomerRequest();
            var createdCustomer = this.CreateCustomer(request);

            var retrievedCustomer = this.gateway.Send(new GetCustomerById { Id = createdCustomer.Id });

            retrievedCustomer.Should().BeEquivalentTo(createdCustomer);
        }

        [Test]
        public void Can_Get_Stub_Customer_By_UniqueId()
        {
            var request = CreateBasicRotessaCustomerRequest();
            request.CustomIdentifier = Guid.NewGuid().ToString("N");
            var createdCustomer = this.CreateCustomer(request);

            var retrievedCustomer = this.gateway.Send(new GetCustomerByCustomIdentifier { CustomIdentifier = request.CustomIdentifier });

            retrievedCustomer.Should().BeEquivalentTo(createdCustomer);
        }

        /// <summary>
        /// Tests whether a complete customer can be created.
        /// </summary>
        [Test]
        public void Can_Create_InComplete_Canadian_Customer()
        {
            var request = CreateCanadianRotessaCustomerRequest();
            var createdCustomer = this.CreateCustomer(request);

            createdCustomer
                .Should()
                .BeEquivalentTo(request, options => options.Excluding(x => x.CustomerType));

            // customer type always defaults to personal, even when null.
            Assert.AreEqual(createdCustomer.CustomerType, CustomerType.Personal);
        }

        /// <summary>
        /// Tests whether a complete customer can be created.
        /// </summary>
        [Test]
        public void Can_Get_InComplete_Customer_By_Id()
        {
            var request = CreateCanadianRotessaCustomerRequest();
            var createdCustomer = this.CreateCustomer(request);

            var retrievedCustomer = this.gateway.Send(new GetCustomerById { Id = createdCustomer.Id });

            retrievedCustomer.Should().BeEquivalentTo(createdCustomer);
        }

        /// <summary>
        /// Tests whether a complete customer can be created.
        /// </summary>
        [Test]
        public void Can_Create_Complete_Canadian_Customer()
        {
            var request = CreateCompleteRotessaCustomerRequest();

            var createdCustomer = this.CreateCustomer(request);

            // excluding institution number, transit number, account number 
            // since they are not returned by the post.
            // however, get returns all the fields correctly.
            createdCustomer.Should().BeEquivalentTo(
                request,
                options => options
                    .Excluding(x => x.CustomerType)
                    .Excluding(x => x.InstitutionNumber)
                    .Excluding(x => x.TransitNumber)
                    .Excluding(x => x.AccountNumber));

            // customer type always defaults to personal, even when null.
            Assert.AreEqual(createdCustomer.CustomerType, CustomerType.Personal);
        }

        /// <summary>
        /// Tests whether a complete customer can be created.
        /// </summary>
        [Test]
        public void Can_Get_Complete_Customer_By_Id()
        {
            var request = CreateCompleteRotessaCustomerRequest();
            var createdCustomer = this.CreateCustomer(request);

            var retrievedCustomer = this.gateway.Send(new GetCustomerById { Id = createdCustomer.Id });

            retrievedCustomer.Should().BeEquivalentTo(createdCustomer);
        }

        /// <summary>
        /// Tests whether the details for a stub customer can be updated.
        /// </summary>
        [Test]
        public void Can_Update_Stub_Customers()
        {
            var request = CreateBasicRotessaCustomerRequest();
            var createdCustomer = this.CreateCustomer(request);

            var updateCustomerRequest = new UpdateRotessaCustomer
                                            {
                                                Id = createdCustomer.Id,
                                                Name = "Update test",
                                                Email = "update@email.com"
                                            };

            var updatedCustomer = this.gateway.Put(updateCustomerRequest);

            updatedCustomer.Should().BeEquivalentTo(updateCustomerRequest, options => options.Excluding(x => x.Address).Excluding(x => x.CustomerType));
        }

        /// <summary>
        /// Tests whether search contains created customer.
        /// </summary>
        [Test]
        public void Can_Get_All_Customers()
        {
            var request = CreateBasicRotessaCustomerRequest();
            var createdCustomer = this.CreateCustomer(request);

            var searchRequest = new GetRotessaCustomers();
            var customers = this.gateway.Get(searchRequest);

            var searchedCustomer = customers.SingleOrDefault(x => x.Id == createdCustomer.Id);
            Assert.IsNotNull(searchedCustomer);
        }
    }
}