using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contozoo.Resources.Animals
{
	public class AnimalItem : AnimalBase
	{
		[Key]
		public long Id { get; set; }
	}
}
