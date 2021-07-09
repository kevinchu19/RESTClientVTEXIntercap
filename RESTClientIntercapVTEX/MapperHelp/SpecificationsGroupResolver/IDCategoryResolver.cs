using AutoMapper;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.MapperHelp.SpecificationsGroupResolver
{
	public class IdCategoryResolver : IValueResolver<Usr_Sttgsh, SpecificationGroupDTO, int?>
	{
		public int? Resolve(Usr_Sttgsh source, SpecificationGroupDTO destination, int? member, ResolutionContext context)
		{
            if (source.Usr_Sttgsh_Deptos.Trim() == "Z")
            {
				return null;
            }
			return Convert.ToInt32(source.Usr_Sttgsh_Deptos.Trim() +
								  (source.Usr_Sttgsh_Catego.Trim() == "Z" ? "" : source.Usr_Sttgsh_Catego.Trim()) +
								  (source.Usr_Sttgsh_Subcat.Trim() == "Z" ? "" : source.Usr_Sttgsh_Subcat.Trim()));
		}
	}
}

