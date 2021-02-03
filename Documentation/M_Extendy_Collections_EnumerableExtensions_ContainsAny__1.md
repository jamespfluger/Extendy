# EnumerableExtensions.ContainsAny(*T*) Method (IEnumerable(*T*), *T*[])
 

Checks whether any of the *values* exist in the *source*

**Namespace:**&nbsp;<a href="N_Extendy_Collections">Extendy.Collections</a><br />**Assembly:**&nbsp;Extendy (in Extendy.dll) Version: 0.2.0

## Syntax

**C#**<br />
``` C#
public static bool ContainsAny<T>(
	this IEnumerable<T> source,
	params T[] values
)
where T : struct, new()

```


#### Parameters
&nbsp;<dl><dt>source</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1" target="_blank">System.Collections.Generic.IEnumerable</a>(*T*)<br /></dd><dt>values</dt><dd>Type: *T*[]<br />The elements to check for in the collection. The collection itself cannot be null, but the values can be null, if T is a reference type./></dd></dl>

#### Type Parameters
&nbsp;<dl><dt>T</dt><dd>The type of objects in the collection.</dd></dl>

#### Return Value
Type: <a href="https://docs.microsoft.com/dotnet/api/system.boolean" target="_blank">Boolean</a><br />true if any one of the *values* exists within the *source*; otherwise, false.

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1" target="_blank">IEnumerable</a>(*T*). When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods">Extension Methods (Visual Basic)</a> or <a href="https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods">Extension Methods (C# Programming Guide)</a>.

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="https://docs.microsoft.com/dotnet/api/system.argumentnullexception" target="_blank">ArgumentNullException</a></td><td /></tr></table>

## See Also


#### Reference
<a href="T_Extendy_Collections_EnumerableExtensions">EnumerableExtensions Class</a><br /><a href="Overload_Extendy_Collections_EnumerableExtensions_ContainsAny">ContainsAny Overload</a><br /><a href="N_Extendy_Collections">Extendy.Collections Namespace</a><br />