// <copyright file="AuthorizationType.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa.Types
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines authorization types usable
    /// for American customers.
    /// </summary>
    public enum AuthorizationType
    {
        [EnumMember(Value = "In Person")]
        InPerson,

        [EnumMember(Value = "Online")]
        Online,

        [EnumMember(Value = "Phone")]
        Phone,
    }
}