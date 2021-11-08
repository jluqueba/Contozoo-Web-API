using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contozoo.Resources.Animals
{
	public class AnimalProfile : Profile
	{
		public AnimalProfile()
		{
			CreateMap<AnimalDTO, AnimalItem>().ReverseMap();
		}
	}
}
