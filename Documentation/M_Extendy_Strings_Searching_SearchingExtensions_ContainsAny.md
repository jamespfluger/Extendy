# SearchingExtensions.ContainsAny Method 
 

Determines whether this string occurs in *anyOf* or not.

**Namespace:**&nbsp;<a href="N_Extendy_Strings_Searching">Extendy.Strings.Searching</a><br />**Assembly:**&nbsp;Extendy (in Extendy.dll) Version: 0.2.0

## Syntax

**C#**<br />
``` C#
public static bool ContainsAny(
	this string source,
	params string[] anyOf
)
```


#### Parameters
&nbsp;<dl><dt>source</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">System.String</a><br /></dd><dt>anyOf</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">System.String</a>[]<br />The set of strings to check for the existence of the string.</dd></dl>

#### Return Value
Type: <a href="https://docs.microsoft.com/dotnet/api/system.boolean" target="_blank">Boolean</a><br />true if the <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">String</a> exists within *anyOf*; otherwise, false.

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">String</a>. When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods">Extension Methods (Visual Basic)</a> or <a href="https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods">Extension Methods (C# Programming Guide)</a>.

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="https://docs.microsoft.com/dotnet/api/system.argumentnullexception" target="_blank">ArgumentNullException</a></td><td /></tr><tr><td><a href="https://docs.microsoft.com/dotnet/api/system.argumentexception" target="_blank">ArgumentException</a></td><td /></tr></table>

## See Also


#### Reference
<a href="T_Extendy_Strings_Searching_SearchingExtensions">SearchingExtensions Class</a><br /><a href="N_Extendy_Strings_Searching">Extendy.Strings.Searching Namespace</a><br />