using AutoMapper;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.MapperHelp.SpecificationsGroupResolver
{
	public class IdCategoryResolver : IValueResolver<Usr_Sttgsh, SpecificationGroupDTO, int>
	{
		public int Resolve(Usr_Sttgsh source, SpecificationGroupDTO destination, int member, ResolutionContext context)
		{
			return Convert.ToInt32(source.Usr_Sttgsh_Deptos +
								  (source.Usr_Sttgsh_Catego == "Z" ? "" : source.Usr_Sttgsh_Catego) +
								  (source.Usr_Sttgsh_Subcat == "Z" ? "" : source.Usr_Sttgsh_Subcat));
		}
	}
}

