# EnumerableExtensions.AddRange(*TSource*, *TValues*) Method 
 

Adds the specified values to the <a href="https://docs.microsoft.com/dotnet/api/system.collections.generic.icollection-1" target="_blank">ICollection(T)</a>

**Namespace:**&nbsp;<a href="N_Extendy_Collections">Extendy.Collections</a><br />**Assembly:**&nbsp;Extendy (in Extendy.dll) Version: 0.2.0

## Syntax

**C#**<br />
``` C#
public static void AddRange<TSource, TValues>(
	this ICollection<TSource> source,
	params TValues[] values
)
where TValues : TSource

```


#### Parameters
&nbsp;<dl><dt>source</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.collections.generic.icollection-1" target="_blank">System.Collections.Generic.ICollection</a>(*TSource*)<br /></dd><dt>values</dt><dd>Type: *TValues*[]<br />The elements who should be added to the collection. The collection itself cannot be null, but the values can be null, if T is a reference type./></dd></dl>

#### Type Parameters
&nbsp;<dl><dt>TSource</dt><dd>The type of objects in the collection.</dd><dt>TValues</dt><dd>The type of values to add to the collection.</dd></dl>

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="https://docs.microsoft.com/dotnet/api/system.collections.generic.icollection-1" target="_blank">ICollection</a>(*TSource*). When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="https://docs.microsoft.com/dotnet/visual-basic/programming-guide/language-features/procedures/extension-methods">Extension Methods (Visual Basic)</a> or <a href="https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods">Extension Methods (C# Programming Guide)</a>.

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="https://docs.microsoft.com/dotnet/api/system.argumentnullexception" target="_blank">ArgumentNullException</a></td><td /></tr></table>

## See Also


#### Reference
<a href="T_Extendy_Collections_EnumerableExtensions">EnumerableExtensions Class</a><br /><a href="N_Extendy_Collections">Extendy.Collections Namespace</a><br />