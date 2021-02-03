# EnumerableExtensions.DistinctBy(*TSource*, *TKey*) Method 
 

Returns distinct elements from a sequence based on a function.

**Namespace:**&nbsp;<a href="N_Extendy_Collections">Extendy.Collections</a><br />**Assembly:**&nbsp;Extendy (in Extendy.dll) Version: 0.2.0

## Syntax

**C#**<br />
``` C#
public static IEnumerable<TSource> DistinctBy<TSource, TKey>(
	this IEnumerable<TSource> source,
	Func<TSource, TKey> keySelector
)

```


#### Parameters
&nbsp;<dl><dt>source</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1" target="_blank">System.Collections.Generic.IEnumerable</a>(*TSource*)<br /></dd><dt>keySelector</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.func-2" target="_blank">System.Func</a>(*TSource*, *TKey*)<br />A function that defines the conditions of how to select distinct elements</dd></dl>

#### Type Parameters
&nbsp;<dl><dt>TSource</dt><dd>The type of values in the collection.</dd><dt>TKey</dt><dd>The type of values to select the key from.</dd></dl>

#### Return Value
Type: <a href="https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1" target="_blank">IEnumerable</a>(*TSource*)<br />An <a href="https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1" target="_blank">IEnumerable(T)</a>that represents distinct elements from the source sequence.

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1" target="_blank">IEnumerable</a>(*TSource*). When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods">Extension Methods (Visual Basic)</a> or <a href="https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods">Extension Methods (C# Programming Guide)</a>.

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="https://docs.microsoft.com/dotnet/api/system.argumentnullexception" target="_blank">ArgumentNullException</a></td><td /></tr></table>

## See Also


#### Reference
<a href="T_Extendy_Collections_EnumerableExtensions">EnumerableExtensions Class</a><br /><a href="N_Extendy_Collections">Extendy.Collections Namespace</a><br />