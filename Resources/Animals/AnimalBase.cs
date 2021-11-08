using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contozoo.Resources.Animals
{
	public class AnimalBase
	{
		public long CAI { get; set; }

		public string Name { get; set; }

		public int Number { get; set; }

		public string Location { get; set; }

		public long ActiveHour { get; set; }

		public string Notes { get; set; }
	}
}
