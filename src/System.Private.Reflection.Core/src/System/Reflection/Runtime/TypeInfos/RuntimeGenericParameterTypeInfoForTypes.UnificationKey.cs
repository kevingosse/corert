// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Reflection.Runtime.General;

using Internal.Reflection.Tracing;

using Internal.Metadata.NativeFormat;

namespace System.Reflection.Runtime.TypeInfos
{
    internal sealed partial class RuntimeGenericParameterTypeInfoForTypes : RuntimeGenericParameterTypeInfo
    {
        //
        // Key for unification.
        //
        internal struct UnificationKey : IEquatable<UnificationKey>
        {
            public UnificationKey(MetadataReader reader, TypeDefinitionHandle typeDefinitionHandle, GenericParameterHandle genericParameterHandle)
            {
                Reader = reader;
                TypeDefinitionHandle = typeDefinitionHandle;
                GenericParameterHandle = genericParameterHandle;
            }

            public MetadataReader Reader { get; }
            public TypeDefinitionHandle TypeDefinitionHandle { get; }
            public GenericParameterHandle GenericParameterHandle { get; }

            public override bool Equals(object obj)
            {
                if (!(obj is UnificationKey))
                    return false;
                return Equals((UnificationKey)obj);
            }

            public bool Equals(UnificationKey other)
            {
                if (!TypeDefinitionHandle.Equals(other.TypeDefinitionHandle))
                    return false;
                if (!(Reader == other.Reader))
                    return false;
                if (!(GenericParameterHandle.Equals(other.GenericParameterHandle)))
                    return false;
                return true;
            }

            public override int GetHashCode()
            {
                return TypeDefinitionHandle.GetHashCode();
            }
        }
    }
}

