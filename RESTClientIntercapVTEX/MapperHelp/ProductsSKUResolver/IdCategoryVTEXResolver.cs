using AutoMapper;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.MapperHelp.ProductsSKUResolver
{
	public class IdCategoryVTEXResolver : IValueResolver<Stmpdh, ProductDTO, int>
	{
		public int Resolve(Stmpdh source, ProductDTO destination, int member, ResolutionContext context)
		{
			return Convert.ToInt32(source.Usr_Stmpdh_Deptos.Trim() + 
								  (source.Usr_Stmpdh_Catego.Trim() == "Z" ? "":source.Usr_Stmpdh_Catego.Trim()) +
								  (source.Usr_Stmpdh_Subcat.Trim() == "Z" ? "" : source.Usr_Stmpdh_Subcat.Trim()));
		}
	}
}