# CommonExtensions.EqualsIgnoreCase Method 
 

Determines whether this instance and another specified <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">String</a> object are the same value, agnostic of case.

**Namespace:**&nbsp;<a href="N_Extendy_Strings_Common">Extendy.Strings.Common</a><br />**Assembly:**&nbsp;Extendy (in Extendy.dll) Version: 0.2.0

## Syntax

**C#**<br />
``` C#
public static bool EqualsIgnoreCase(
	this string source,
	string value
)
```


#### Parameters
&nbsp;<dl><dt>source</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">System.String</a><br /></dd><dt>value</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">System.String</a><br />The string to compare to this instance.</dd></dl>

#### Return Value
Type: <a href="https://docs.microsoft.com/dotnet/api/system.boolean" target="_blank">Boolean</a><br />true if the value of the *value* parameter is the same as the value of this instance ignoring the case of the strings being compared; otherwise, false.

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">String</a>. When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods">Extension Methods (Visual Basic)</a> or <a href="https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods">Extension Methods (C# Programming Guide)</a>.

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="https://docs.microsoft.com/dotnet/api/system.argumentexception" target="_blank">ArgumentException</a></td><td /></tr></table>

## See Also


#### Reference
<a href="T_Extendy_Strings_Common_CommonExtensions">CommonExtensions Class</a><br /><a href="N_Extendy_Strings_Common">Extendy.Strings.Common Namespace</a><br />