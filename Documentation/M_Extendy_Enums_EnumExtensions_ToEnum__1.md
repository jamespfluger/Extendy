# EnumExtensions.ToEnum(*T*) Method (String)
 

Converts a string to the provided enum type of *T*

**Namespace:**&nbsp;<a href="N_Extendy_Enums">Extendy.Enums</a><br />**Assembly:**&nbsp;Extendy (in Extendy.dll) Version: 0.2.0

## Syntax

**C#**<br />
``` C#
public static T ToEnum<T>(
	this string source
)
where T : Enum

```


#### Parameters
&nbsp;<dl><dt>source</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">System.String</a><br /></dd></dl>

#### Type Parameters
&nbsp;<dl><dt>T</dt><dd>The type of enum to convert the string to</dd></dl>

#### Return Value
Type: *T*<br />The parsed enum value

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">String</a>. When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods">Extension Methods (Visual Basic)</a> or <a href="https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods">Extension Methods (C# Programming Guide)</a>.

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="https://docs.microsoft.com/dotnet/api/system.argumentexception" target="_blank">ArgumentException</a></td><td /></tr><tr><td><a href="https://docs.microsoft.com/dotnet/api/system.argumentnullexception" target="_blank">ArgumentNullException</a></td><td /></tr><tr><td><a href="https://docs.microsoft.com/dotnet/api/system.overflowexception" target="_blank">OverflowException</a></td><td /></tr></table>

## See Also


#### Reference
<a href="T_Extendy_Enums_EnumExtensions">EnumExtensions Class</a><br /><a href="Overload_Extendy_Enums_EnumExtensions_ToEnum">ToEnum Overload</a><br /><a href="N_Extendy_Enums">Extendy.Enums Namespace</a><br />