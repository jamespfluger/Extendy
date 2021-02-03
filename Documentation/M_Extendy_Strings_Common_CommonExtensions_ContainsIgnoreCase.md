# CommonExtensions.ContainsIgnoreCase Method 
 

Returns a value indicating whether a specified substring occurs within this string, agnostic of case.

**Namespace:**&nbsp;<a href="N_Extendy_Strings_Common">Extendy.Strings.Common</a><br />**Assembly:**&nbsp;Extendy (in Extendy.dll) Version: 0.2.0

## Syntax

**C#**<br />
``` C#
public static bool ContainsIgnoreCase(
	this string source,
	string value
)
```


#### Parameters
&nbsp;<dl><dt>source</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">System.String</a><br /></dd><dt>value</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">System.String</a><br />The value to seek.</dd></dl>

#### Return Value
Type: <a href="https://docs.microsoft.com/dotnet/api/system.boolean" target="_blank">Boolean</a><br />true if the *value* parameter occurs within this string, regardless of case, or if the *value* is an empty string (""); otherwise, false.

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">String</a>. When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods">Extension Methods (Visual Basic)</a> or <a href="https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods">Extension Methods (C# Programming Guide)</a>.

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="https://docs.microsoft.com/dotnet/api/system.argumentnullexception" target="_blank">ArgumentNullException</a></td><td /></tr><tr><td><a href="https://docs.microsoft.com/dotnet/api/system.argumentexception" target="_blank">ArgumentException</a></td><td /></tr></table>

## See Also


#### Reference
<a href="T_Extendy_Strings_Common_CommonExtensions">CommonExtensions Class</a><br /><a href="N_Extendy_Strings_Common">Extendy.Strings.Common Namespace</a><br />