// <copyright file="ConfigScope.cs" company="RubricEm">
// Copyright (c) RubricEm. All rights reserved.
// </copyright>

namespace RubricEm.Rotessa
{
    using System;

    using RubricEm.Rotessa.Types;

    using ServiceStack;
    using ServiceStack.Text;

    public class ConfigScope : IDisposable
    {
        private readonly WriteComplexTypeDelegate holdQsStrategy;

        private readonly JsConfigScope jsConfigScope;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigScope"/> class.
        /// </summary>
        public ConfigScope()
        {
            var config = Config.Defaults;
            config.DateHandler = DateHandler.UnixTime;
            config.PropertyConvention = PropertyConvention.Lenient;
            config.TextCase = TextCase.SnakeCase;
            config.TreatEnumAsInteger = false;
            config.ExcludeTypeInfo = true;


            JsConfig<RotessaProcessDate>.SerializeFn = date => date.ToString();

            this.jsConfigScope = JsConfig.With(config);

            this.holdQsStrategy = QueryStringSerializer.ComplexTypeStrategy;
            QueryStringSerializer.ComplexTypeStrategy = QueryStringStrategy.FormUrlEncoded;
        }

        public void Dispose()
        {
            QueryStringSerializer.ComplexTypeStrategy = this.holdQsStrategy;
            this.jsConfigScope.Dispose();
        }
    }
}
