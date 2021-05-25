using AutoMapper;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.MapperHelp.CategorysResolver
{
	public class FatherSubcategoryIdResolver : IValueResolver<Usr_Sttcas, CategoryDTO, string>
	{
		public string Resolve(Usr_Sttcas source, CategoryDTO destination, string member, ResolutionContext context)
		{
			return Convert.ToInt32(source.Usr_Sttcas_Deptos.Trim() + source.Usr_Sttcas_Catego.Trim()).ToString();

		}
	}
}

