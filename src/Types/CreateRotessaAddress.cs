// <copyright file="CreateRotessaAddress.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CreateRotessaAddress
    {
        [DataMember(Name = "address_1")]
        public string Address1 { get; set; }

        [DataMember(Name = "address_2")]
        public string Address2 { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "province_code")]
        public string ProvinceCode { get; set; }

        [DataMember(Name = "postal_code")]
        public string PostalCode { get; set; }
    }
}