# Serialize structs reproduction

It cannot serialize the F# version of a struct with `Newtonsoft.Json`.
The weird thing is that I can do it using C#.

Steps to reproduce:
- restore and build the solution
- run the unit tests

The `serialize F# struct` test should fail:

```
Failed serialize F# struct [9 ms]
Error Message:
System.IO.FileNotFoundException : Could not load file or assembly '"The system type 'System.Runtime.CompilerServices.IsReadOnlyAttribute' was required but no referenced system DLL contained this type", Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'. The system cannot find the file specified.
Stack Trace:
at System.ModuleHandle.ResolveType(QCallModule module, Int32 typeToken, IntPtr* typeInstArgs, Int32 typeInstCount, IntPtr* methodInstArgs, Int32 methodInstCount, ObjectHandleOnStack type)
at System.ModuleHandle.ResolveTypeHandle(Int32 typeToken, RuntimeTypeHandle[] typeInstantiationContext, RuntimeTypeHandle[] methodInstantiationContext)
at System.Reflection.RuntimeModule.ResolveType(Int32 metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
at System.Reflection.CustomAttribute.FilterCustomAttributeRecord(MetadataToken caCtorToken, MetadataImport& scope, RuntimeModule decoratedModule, MetadataToken decoratedToken, RuntimeType attributeFilterType, Boolean mustBeInheritable, ListBuilder`1& derivedAttributes, RuntimeType& attributeType, IRuntim
eMethodInfo& ctorWithParameters, Boolean& isVarArg)
at System.Reflection.CustomAttribute.IsCustomAttributeDefined(RuntimeModule decoratedModule, Int32 decoratedMetadataToken, RuntimeType attributeFilterType, Int32 attributeCtorToken, Boolean mustBeInheritable)
at System.Reflection.CustomAttribute.IsDefined(RuntimeMethodInfo method, RuntimeType caType, Boolean inherit)
at System.Reflection.RuntimeMethodInfo.IsDefined(Type attributeType, Boolean inherit)
at Newtonsoft.Json.Serialization.DefaultContractResolver.IsValidCallback(MethodInfo method, ParameterInfo[] parameters, Type attributeType, MethodInfo currentCallback, Type& prevAttributeType)
at Newtonsoft.Json.Serialization.DefaultContractResolver.GetCallbackMethodsForType(Type type, List`1& onSerializing, List`1& onSerialized, List`1& onDeserializing, List`1& onDeserialized, List`1& onError)
at Newtonsoft.Json.Serialization.DefaultContractResolver.ResolveCallbackMethods(JsonContract contract, Type t)
at Newtonsoft.Json.Serialization.DefaultContractResolver.InitializeContract(JsonContract contract)
at Newtonsoft.Json.Serialization.DefaultContractResolver.CreateObjectContract(Type objectType)
at Newtonsoft.Json.Serialization.DefaultContractResolver.CreateContract(Type objectType)
at System.Collections.Concurrent.ConcurrentDictionary`2.GetOrAdd(TKey key, Func`2 valueFactory)
at Newtonsoft.Json.Utilities.ThreadSafeStore`2.Get(TKey key)
at Newtonsoft.Json.Serialization.DefaultContractResolver.ResolveContract(Type type)
at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.GetContract(Object value)
at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.GetContractSafe(Object value)
at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.Serialize(JsonWriter jsonWriter, Object value, Type objectType)
at Newtonsoft.Json.JsonSerializer.SerializeInternal(JsonWriter jsonWriter, Object value, Type objectType)
at Newtonsoft.Json.JsonSerializer.Serialize(JsonWriter jsonWriter, Object value, Type objectType)
at Newtonsoft.Json.JsonConvert.SerializeObjectInternal(Object value, Type type, JsonSerializer jsonSerializer)
at Newtonsoft.Json.JsonConvert.SerializeObject(Object value, Type type, JsonSerializerSettings settings)
at Newtonsoft.Json.JsonConvert.SerializeObject(Object value)
```

If you change the SDK version in the global.json to `6.0.400` both tests will pass.
