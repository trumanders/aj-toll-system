using System.Runtime.CompilerServices;

namespace Common.Extensions;

public static class NavigationPropertyExtensions
{
	public static T EnsureNotNull<T>(this T? property, string propertyName)
		where T : class
	{
		if (property is null)
		{
			throw new InvalidOperationException("Uninitialized property: " + propertyName);
		}
		return property;
	}
}
