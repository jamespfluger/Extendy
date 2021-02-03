# ModificationExtensions.RemoveAllIgnoreCase Method (String, Char)
 

Returns a new string in which all occurrences of the *toRemove* char, case agnostic, in the current instance have been deleted.

**Namespace:**&nbsp;<a href="N_Extendy_Strings_Modification">Extendy.Strings.Modification</a><br />**Assembly:**&nbsp;Extendy (in Extendy.dll) Version: 0.2.0

## Syntax

**C#**<br />
``` C#
public static string RemoveAllIgnoreCase(
	this string source,
	char toRemove
)
```


#### Parameters
&nbsp;<dl><dt>source</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">System.String</a><br /></dd><dt>toRemove</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.char" target="_blank">System.Char</a><br />The character to delete from the current instance.</dd></dl>

#### Return Value
Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">String</a><br />A new string that is equivalent to his string except for the removed characters.

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">String</a>. When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods">Extension Methods (Visual Basic)</a> or <a href="https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods">Extension Methods (C# Programming Guide)</a>.

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="https://docs.microsoft.com/dotnet/api/system.argumentexception" target="_blank">ArgumentException</a></td><td /></tr><tr><td><a href="https://docs.microsoft.com/dotnet/api/system.argumentnullexception" target="_blank">ArgumentNullException</a></td><td /></tr></table>

## See Also


#### Reference
<a href="T_Extendy_Strings_Modification_ModificationExtensions">ModificationExtensions Class</a><br /><a href="Overload_Extendy_Strings_Modification_ModificationExtensions_RemoveAllIgnoreCase">RemoveAllIgnoreCase Overload</a><br /><a href="N_Extendy_Strings_Modification">Extendy.Strings.Modification Namespace</a><br />