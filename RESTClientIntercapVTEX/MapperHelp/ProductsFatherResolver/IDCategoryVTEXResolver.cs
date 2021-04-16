using AutoMapper;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.MapperHelp.ProductsFatherResolver
{
	public class IdCategoryVTEXResolver : IValueResolver<Usr_Stmpph, ProductDTO, int>
	{
		public int Resolve(Usr_Stmpph source, ProductDTO destination, int member, ResolutionContext context)
		{
			return Convert.ToInt32(source.Usr_Stmpph_Deptos +
								  (source.Usr_Stmpph_Catego == "Z" ? "" : source.Usr_Stmpph_Catego) +
								  (source.Usr_Stmpph_Subcat == "Z" ? "" : source.Usr_Stmpph_Subcat));
		}
	}
}