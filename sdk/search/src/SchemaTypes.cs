// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

namespace Microsoft.Bing.Commerce.Search
{
    using Microsoft.Bing.Commerce.Search.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    internal static class SchemaTypes
    {
        // Type in the schema assembly and root namespace
        private static readonly Type MarkerType = typeof(ConditionBase);

        static SchemaTypes()
        {
            var ns = MarkerType.Namespace;
            var nsPrefix = ns + ".";
            var types = typeof(SchemaTypes).Assembly.GetExportedTypes()
                .Where(t => StringComparer.Ordinal.Equals(ns, t.Namespace) || t.Namespace.StartsWith(nsPrefix, StringComparison.Ordinal))
                .ToList();

            SchemaNamesByType = new Dictionary<Type, string>();
            foreach (var type in types)
            {
                var objectAttr = type.GetCustomAttributes(inherit: false).OfType<JsonObjectAttribute>().SingleOrDefault();
                var schemaName = objectAttr?.Id;

                // Bing Commerce SchemaName attributes pass through the AutoRest x-ms-discriminator-value OAS extension into
                // generated JsonObject attributes, however AutoRest adds additional JsonObject attributes where
                // SchemaName is not present (particularly for abstract types), often with dots, so we try to filter
                // those out.
                if (schemaName != null && !schemaName.Contains('.'))
                {
                    SchemaNamesByType.Add(type, schemaName);
                }
            }

            DerivedTypes = new Dictionary<Type, IDictionary<string, Type>>(types.Count);
            Constructors = new Dictionary<Type, Func<object>>();
            foreach (var type in types)
            {
                var derivedTypes = types.Where(t => type.IsAssignableFrom(t)).ToList();
                if (derivedTypes.Count > 1)
                {
                    var derivedTypeMap = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
                    foreach (var derivedType in derivedTypes)
                    {
                        if (SchemaNamesByType.TryGetValue(derivedType, out var schemaName))
                        {
                            derivedTypeMap.Add(schemaName, derivedType);
                        }
                    }

                    if (derivedTypeMap.Count > 0)
                    {
                        DerivedTypes.Add(type, derivedTypeMap);

                        var ctor = Expression
                            .Lambda<Func<object>>(Expression.New(type))
                            .Compile();
                        Constructors.Add(type, ctor);
                    }
                }
            }
        }

        public static IDictionary<Type, string> SchemaNamesByType { get; }

        /// <summary>
        /// Gets a map from schema types to their derived types, where the derived types are themselves a schema name
        /// to type map
        /// </summary>
        /// <remarks>
        /// Derived types include the base type
        /// </remarks>
        public static IDictionary<Type, IDictionary<string, Type>> DerivedTypes { get; }

        public static IDictionary<Type, Func<object>> Constructors { get; }
    }
}
