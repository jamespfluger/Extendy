# ModificationExtensions.ReplaceIgnoreCase Method (String, String, String)
 

Returns a new string in which all occurrences of a specified string, case agnostic, in the current instance are replaced with another specified string.

**Namespace:**&nbsp;<a href="N_Extendy_Strings_Modification">Extendy.Strings.Modification</a><br />**Assembly:**&nbsp;Extendy (in Extendy.dll) Version: 0.2.0

## Syntax

**C#**<br />
``` C#
public static string ReplaceIgnoreCase(
	this string source,
	string oldValue,
	string newValue
)
```


#### Parameters
&nbsp;<dl><dt>source</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">System.String</a><br /></dd><dt>oldValue</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">System.String</a><br />The string to be replaced.</dd><dt>newValue</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">System.String</a><br />The string to replace all values of *oldValue*.</dd></dl>

#### Return Value
Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">String</a><br />A string that is equivalent to the current string except that all instances of *oldValue* are replaced with *newValue*, case agnostic. If *oldValue* is not found in the current instance, the method returns the current instance unchanged.

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">String</a>. When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods">Extension Methods (Visual Basic)</a> or <a href="https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods">Extension Methods (C# Programming Guide)</a>.

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="https://docs.microsoft.com/dotnet/api/system.argumentexception" target="_blank">ArgumentException</a></td><td /></tr><tr><td><a href="https://docs.microsoft.com/dotnet/api/system.argumentnullexception" target="_blank">ArgumentNullException</a></td><td /></tr></table>

## See Also


#### Reference
<a href="T_Extendy_Strings_Modification_ModificationExtensions">ModificationExtensions Class</a><br /><a href="Overload_Extendy_Strings_Modification_ModificationExtensions_ReplaceIgnoreCase">ReplaceIgnoreCase Overload</a><br /><a href="N_Extendy_Strings_Modification">Extendy.Strings.Modification Namespace</a><br />