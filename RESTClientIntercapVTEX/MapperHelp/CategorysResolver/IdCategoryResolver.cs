using AutoMapper;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.MapperHelp.CategorysResolver
{
	public class IdCategoryResolver : IValueResolver<Usr_Sttcai, CategoryDTO, int>
	{
		public int Resolve(Usr_Sttcai source, CategoryDTO destination, int member, ResolutionContext context)
		{
			return Convert.ToInt32(source.Usr_Sttcai_Deptos.Trim() + source.Usr_Sttcai_Catego.Trim());
		}
	}
}
