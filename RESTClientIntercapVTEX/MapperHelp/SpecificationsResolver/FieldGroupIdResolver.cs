using AutoMapper;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClientIntercapVTEX.MapperHelp.SpecificationsResolver

{
	public class FieldGroupIdResolver : IValueResolver<Usr_Sttcaa, SpecificationDTO, int>
	{
		public int Resolve(Usr_Sttcaa source, SpecificationDTO destination, int member, ResolutionContext context)
		{
			return 1;
		}
	}
}
