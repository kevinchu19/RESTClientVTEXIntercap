using AutoMapper;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.MapperHelp.SpecificationsResolver
{
	public class IdCategoryResolver : IValueResolver<Usr_Sttcax, SpecificationDTO, int?>
	{
		public int? Resolve(Usr_Sttcax source, SpecificationDTO destination, int? member, ResolutionContext context)
		{
			return Convert.ToInt32(source.Usr_Sttcax_Deptos.Trim() + source.Usr_Sttcax_Catego.Trim());
		}
	}
}
