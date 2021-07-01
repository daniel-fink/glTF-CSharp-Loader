### Note:
This fork upgrades glTF-CSharp-Loader for use in the latest version of Unity (2020.3.11f1), since there are some dependency conflicts using the original project. (Specifically it updates the Newtonsoft.Json dependency to version 12)

Additionally it:
1. Updates the project to utilize net5.0 or netframework472, and enable building on macOS
2. Includes the glTF specification, and replaces hard-written code with semi-hard-written code pointing to that directory.

This has been tested on macOS. All Unit tests pass except for `AllPropertyNames`.

---

This is a C# reference loader for glTF.  It's as simple to use as `Interface.LoadModel("PathToModel.gltf")`.  You can use this loader in your project by importing the "glTF2Loader" NuGet package.  Additional examples can be found in the gltfLoaderUnitTests project.

## Build Instructions

### Prerequisites

This solution requires access to the glTF schema to compile and the sample models to test. It assumes that the glTF and glTF-Sample-Models repos have been cloned under the same root directory that the glTF-CSharp-Loader repo was cloned.

```
repos
+-- glTF
|   +-- README.md
+-- glTF-CSharp-Loader
|   +-- README.md
+-- glTF-Sample-Models
|   +-- README.md
```

### Building

To build the project, load the CSharp.sln solution.  Click "Start". This will build glTFLoader_Shared, GeneratorLib, and Generator. It will then run the Generator. The generator reads the .spec files defining the glTF standard and generates a set of classes that will be used as the schema for loading your models. The glTFLoader project can now be built.  You will need glTFLoader.dll and glTFLoader_shared.dll in order to use the loader in any subsequent project.
