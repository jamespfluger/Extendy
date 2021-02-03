# SearchingExtensions.IndexOfIgnoreCase Method (String, Char)
 

Reports the zero-based index of the first occurrence of the specified Unicode character in this instance, case agnostic.

**Namespace:**&nbsp;<a href="N_Extendy_Strings_Searching">Extendy.Strings.Searching</a><br />**Assembly:**&nbsp;Extendy (in Extendy.dll) Version: 0.2.0

## Syntax

**C#**<br />
``` C#
public static int IndexOfIgnoreCase(
	this string source,
	char value
)
```


#### Parameters
&nbsp;<dl><dt>source</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">System.String</a><br /></dd><dt>value</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.char" target="_blank">System.Char</a><br />The string to seek.</dd></dl>

#### Return Value
Type: <a href="https://docs.microsoft.com/dotnet/api/system.int32" target="_blank">Int32</a><br />The zero-based index position of *value* if that character is found, or -1 if it is not.

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">String</a>. When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods">Extension Methods (Visual Basic)</a> or <a href="https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods">Extension Methods (C# Programming Guide)</a>.

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="https://docs.microsoft.com/dotnet/api/system.argumentnullexception" target="_blank">ArgumentNullException</a></td><td /></tr><tr><td><a href="https://docs.microsoft.com/dotnet/api/system.argumentexception" target="_blank">ArgumentException</a></td><td /></tr></table>

## See Also


#### Reference
<a href="T_Extendy_Strings_Searching_SearchingExtensions">SearchingExtensions Class</a><br /><a href="Overload_Extendy_Strings_Searching_SearchingExtensions_IndexOfIgnoreCase">IndexOfIgnoreCase Overload</a><br /><a href="N_Extendy_Strings_Searching">Extendy.Strings.Searching Namespace</a><br />