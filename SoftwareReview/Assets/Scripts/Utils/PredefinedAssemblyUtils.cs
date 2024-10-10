using System;
using System.Collections.Generic;
using System.Reflection;

public static class PredefinedAssemblyUtils
{
    enum AssemblyType
    {
        AssemblyCSharp,
        AssemblyCSharpEditor,
        AssemblyCSharpEditorFirstPass,
        AssemblyCSharpFirstPass,
        MainAssembly,
    }

    // Maps the assembly name to the corresponding AssemblyType.
    static AssemblyType? GetAssemblyType(string assemblyeName)
    {
        return assemblyeName switch
        {
            "Assembly-CSharp-firstpass" => AssemblyType.AssemblyCSharpFirstPass,
            "Assembly-CSharp-Editor-firstpass" => AssemblyType.AssemblyCSharpEditorFirstPass,
            "Assembly-CSharp" => AssemblyType.AssemblyCSharp,
            "Assembly-CSharp-Editor" => AssemblyType.AssemblyCSharpEditor,
            "MainAssembly" => AssemblyType.MainAssembly,
            _ => null // Unity not compile any of above if nothing to compile
        };
    }
    
    // Method looks through a given assembly and adds types that fulfill a certain interface to the provided collection.
    private static void AddTypesFromAssembly(Type[] assemblyTypes, Type interfaceType, ICollection<Type> result)
    {
        if (assemblyTypes == null) return;
        for (int i = 0; i < assemblyTypes.Length; i++)
        {
            Type type = assemblyTypes[i];
            if (type != interfaceType && interfaceType.IsAssignableFrom(type))
            {
                result.Add(type);
            }
        }
    }
    
    // Gets all Types from all assemblies in the current AppDomain that implement the provided interface type.
    public static List<Type> GetTypes(Type interfaceType)
    {
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

        Dictionary<AssemblyType, Type[]> assemblyTypes = new Dictionary<AssemblyType, Type[]>();
        List<Type> types = new List<Type>();
        for (int i = 0; i < assemblies.Length; i++)
        {
            AssemblyType? assemblyType = GetAssemblyType(assemblies[i].GetName().Name);
            if (assemblyType != null)
            {
                assemblyTypes.Add((AssemblyType) assemblyType, assemblies[i].GetTypes());
            }
        }

        AddTypesFromAssembly(assemblyTypes[AssemblyType.AssemblyCSharp], interfaceType, types);
        AddTypesFromAssembly(assemblyTypes[AssemblyType.AssemblyCSharpFirstPass], interfaceType, types);
        AddTypesFromAssembly(assemblyTypes[AssemblyType.MainAssembly], interfaceType, types);

        return types;
    }
}