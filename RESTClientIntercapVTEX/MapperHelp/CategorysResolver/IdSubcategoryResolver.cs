using AutoMapper;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.MapperHelp.CategorysResolver
{
	public class IdSubcategoryResolver : IValueResolver<Usr_Sttcas, CategoryDTO, int>
	{
		public int Resolve(Usr_Sttcas source, CategoryDTO destination, int member, ResolutionContext context)
		{
			return Convert.ToInt32(source.Usr_Sttcas_Deptos.Trim() + source.Usr_Sttcas_Catego.Trim() + source.Usr_Sttcas_Subcat.Trim());
		}
	}
}
