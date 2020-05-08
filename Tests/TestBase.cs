// <copyright file="TestBase.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Tests
{
    using System;
    using System.Threading.Tasks;

    using RubricEm.Rotessa.Types;

    /// <summary>
    /// Base class for all tests.
    /// </summary>
    public class TestBase
    {
        protected readonly RotessaGateway gateway = new RotessaGateway("", true);

        protected RotessaCustomer CreateCustomer(CreateRotessaCustomer request)
        {
            var customer = this.gateway.Post(request);
            return customer;
        }

        protected async Task<RotessaCustomer> CreateCustomerAsync(CreateRotessaCustomer request)
        {
            var customer = await this.gateway.PostAsync(request);
            return customer;
        }

        protected static CreateRotessaCustomer CreateBasicRotessaCustomerRequest()
        {
            return new CreateRotessaCustomer
            {
                Name = "Arun Test",
                Email = "test@email.com",
            };
        }

        protected static CreateRotessaCustomer CreateCanadianRotessaCustomerRequest()
        {
            return new CreateRotessaCustomer
                       {
                           Name = "Arun Test",
                           Email = "test@email.com",
                           Address = new RotessaAddress
                                         {
                                             Address1 = "Suite 800, 151 Front St. W.",
                                             City = "Toronto",
                                             ProvinceCode = "ON",
                                             PostalCode = "M5J2N1",
                                         }
                       };
        }

        protected static CreateRotessaCustomer CreateCompleteRotessaCustomerRequest()
        {
            return new CreateRotessaCustomer
                       {
                           Name = "Arun Test",
                           Email = "test@email.com",
                           Address = new RotessaAddress
                                         {
                                             Address1 = "Suite 800, 151 Front St. W.",
                                             City = "Toronto",
                                             ProvinceCode = "ON",
                                             PostalCode = "M5J2N1",
                                         },
                           BankName = "Royal Bank of Canada",
                           InstitutionNumber = "003",
                           TransitNumber = "00002",
                           AccountNumber = "1111111",
                       };
        }

        protected static CreateRotessaCustomer CreateAmericanRotessaCustomerRequest()
        {
            return new CreateRotessaCustomer
                       {
                           Name = "Arun Test",
                           Email = "test@email.com",
                           Address = new RotessaAddress
                                         {
                                             Address1 = "Suite 800, 151 Front St. W.",
                                             City = "Toronto",
                                             ProvinceCode = "ON",
                                             PostalCode = "M5J2N1",
                                         }
                       };
        }


        protected static CreateRotessaTransactionSchedule CreateRotessaTransactionScheduleRequest(long customerId)
        {
            var futureDate = DateTimeOffset.Now.AddDays(2);
            var transactionScheduleRequest = new CreateRotessaTransactionSchedule
                                                 {
                                                     CustomerId = customerId,
                                                     Amount = (decimal)10.0,
                                                     Comment = "One time Fee",
                                                     Frequency = FrequencyType.Once,
                                                     Installments = 1, // must be set to 1 for frequency once payments. Null throws a 422 error.
                                                     ProcessDate = new RotessaProcessDate { Day = futureDate.Day, Month = futureDate.Month, Year = futureDate.Year },
                                                 };

            return transactionScheduleRequest;
        }
    }
}
