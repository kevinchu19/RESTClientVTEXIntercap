using AutoMapper;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.MapperHelp.SpecificationsResolver
{
	public class IdSubcategoryResolver : IValueResolver<Usr_Sttcay, SpecificationDTO, int>
	{
		public int Resolve(Usr_Sttcay source, SpecificationDTO destination, int member, ResolutionContext context)
		{
			return Convert.ToInt32(source.Usr_Sttcay_Deptos + source.Usr_Sttcay_Catego + source.Usr_Sttcay_Subcat);
		}
	}
}