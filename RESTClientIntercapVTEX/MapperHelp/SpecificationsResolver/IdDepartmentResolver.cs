using AutoMapper;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.MapperHelp.SpecificationsResolver
{
	public class IdDepartmentResolver : IValueResolver<Usr_Sttcaa, SpecificationDTO, int?>
	{
		public int? Resolve(Usr_Sttcaa source, SpecificationDTO destination, int? member, ResolutionContext context)
		{
            if (source.Usr_Sttcaa_Deptos == "Z")
            {
				return null;
            }
			return Convert.ToInt32(source.Usr_Sttcaa_Deptos.Trim());
		}
	}
}
