# library-commons

.Net 7 package that provides some common:

- [Extensions](#Extensions)
- Services 
- Entities
- Constant
- Builders
- Abstractions
- [Helpers](#Helpers)
- Interfaces

# Extensions



## Deep Clone Extension

The deep clone extension uses Activator.CreateInstace to clone the entity. 

This approach considered some studies made by  [cinorid](https://stackoverflow.com/users/6338072/cinorid) in this [answer](https://stackoverflow.com/a/69211283/9114389).

#### Benchmark

``````
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.18363.1734 (1909/November2019Update/19H2)
Intel Core i5-6200U CPU 2.30GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
[Host]     : .NET Framework 4.8 (4.8.4400.0), X86 LegacyJIT
DefaultJob : .NET Framework 4.8 (4.8.4400.0), X86 LegacyJIT
``````

  


| Method                   |      Mean |    Error |   StdDev |   Gen 0 | Allocated |
| ------------------------ | --------: | -------: | -------: | ------: | --------: |
| BinarySerializer         | 220.69 us | 4.374 us | 9.963 us | 49.8047 |     77 KB |
| XmlSerializer            | 182.72 us | 3.619 us | 9.405 us | 21.9727 |     34 KB |
| Activator.CreateInstance |  49.99 us | 0.992 us | 2.861 us |  1.9531 |      3 KB |



## Base64

There's an extension that will handle base64 encode and decode from a raw string

### Usage

Import extensions

`using Codescovery.Library.Commons.Extensions;`



```c#
public void Encode()
{
    var encodedString = rawString.ToBase64Encoded();
}
public void Decode()
{
    var decodedString = rawString.ToBase64Decoded();
}
public void EncodeNull()
{
    string? nullRawString = null;
    var encodedString = nullRawString.ToBase64Encoded();
}
public void DecodeNull()
{
    string? nullEncodedString = null;
    var decodedString = nullEncodedString.ToBase64Decoded();
}
```

## Enum Extension 

The enum extensions provide two methods:

- ToNullableInt
- ToInt

### Usage

Import extensions

`using Codescovery.Library.Commons.Extensions;`

For this example, we are going to use the enum bellow

###  **ExampleEnum** example

```C#
public enum ExampleEnum
{
    Value1 = 1,
    Value2 = 5,
}
```



```c#
var exampleEnum = ExampleEnum.Value1;
var exampleEnumCastedInt = exampleEnum.ToInt();
var exampleEnumCastedNullableInt = exampleEnum.ToNullableInt();
```



## Fluent property Setter

We are providing a fluent property setter, thanks to [Adem Catamak](https://stackoverflow.com/users/6223950/adem-catamak)  [answer](https://stackoverflow.com/users/6223950/adem-catamak).

Which allow us to modify and clone an object using like fluent api.

### Usage

Firts you need to import the extensions:

` using Codescovery.Library.Commons.Extensions;`

For this example, we are going to use the class bellow

#### **ClonableExampleClass** example

```c#
    public class ClonableExampleClass
    {


        public string? ExampleString { get; set; } = default;
        public int ExampleInt { get; set; } = default;
        public ExampleEnum ExampleEnum { get; set; } = default;
        public ClonableExampleClass? ExampleNestedClass { get; set; }
        public List<ClonableExampleClass>? ExampleList { get; set; }
    }
```

### How to use:

#### Modify the values of the current class using fluent api

```c#

var exampleClass = new ClonableExampleClass
{
ExampleInt = 1
}
.With()
.Property(@class => @class.ExampleInt)
.Set(intValue;
```

#### Deep clone class and modify using fluent api

```c#
 var exampleClass = new ClonableExampleClass
        {
            ExampleInt = 1
        };
var cloned= exampleClass.DeepCloneWith()
.Property(@class => @class.ExampleInt)
.Set(1234)
.And()
.Property(@class => "Example string")
.Set(stringValue);
```



## ExceptionsExtensions

Create a full formated exception message.

### Usage

Firts you need to import the extensions:

` using Codescovery.Library.Commons.Extensions;`

Or you can inherint our **BaseException** class that will handle it for you.

`using Codescovery.Library.Commons.Abstractions;`

## ListExtensions

Converts any objects to a list of type

# Helpers

## ConfiguratioBuilder Helper

Provides two Methods: 

### GetCurrentDirectoryBasePath

```C#
FolderPath GetCurrentDirectoryBasePath(FolderPath basePath =null, params string[] paths)
```

Based on a nullable folder path it will return the application current directory base path concatenated  with aditional path parameters passed. 

## GetBasePath

```c#
 FolderPath GetBasePath(FolderPath basePath = null)
```

Will return the basePath if **<>** null, else will return the **DefaultBasePath**



## Constants

```c#
public const string DefaultConfigurationFileName = "appsettings.json";
public const string DefaultConfigurationFileExtension = ".json";
public const string DefaultConfigurationFileExtensionSeparator = ".";
public const string DefaultConfigurationsProjectSubFolderName = "Configurations";
public static readonly FolderPath DefaultBasePath = Directory.GetCurrentDirectory();
```



## ExceptionMessageHelper

Helper to override Exception default messages: 

Provides 3 Methods

### OverrideAditionalInfoHeaderText

```C#
void OverrideAditionalInfoHeaderText(this string aditionalInfoHeaderText)
```

Will Override the **AditionalInfoHeaderText** text

**Default Value** : `Aditional Info:`

### OverrideStackTraceHeaderText

```c#
void OverrideStackTraceHeaderText(this string stackTraceHeaderText)
```

Will Override the **StackTraceHeaderText**  text

**Default Value**: `Stack Trace:`

### OverrideMessageHeaderText

```c#
 void OverrideMessageHeaderText(this string messageHeaderText)
```

Will Override the **MessageHeaderText** text

**Default Value** : `Message:` 

## Constants

```c#
    public const string DefaultErrorMesage = "Error: Application reports that an error occurred:";
    public const string DefaultMessageHeaderText = "Message:";
    public const string DefaultAditionalInfoHeaderText = "Aditional Info:";
    public const string DefaultStackTraceHeaderText = "Stack Trace:";
```
