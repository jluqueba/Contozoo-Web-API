using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contozoo
{
	public record LinkedResource(string Href);

	public enum LinkedResourceType
	{
		None,
		Prev,
		Next
	}

	public static class LinkedResourceExtensions
	{	
		public static void AddResourceLink(this ILinkedResource resources,
				  LinkedResourceType resourceType,
				  string routeUrl)
		{
			resources.Links ??= new Dictionary<LinkedResourceType, LinkedResource>();
			resources.Links[resourceType] = new LinkedResource(routeUrl);
		}
	}
}
