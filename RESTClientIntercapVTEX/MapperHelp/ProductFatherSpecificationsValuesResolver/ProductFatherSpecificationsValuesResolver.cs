using AutoMapper;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RESTClientIntercapVTEX.MapperHelp.ProductFatherSpecificationsValuesResolver
{
	public class ProductFatherSpecificationsValuesResolver : IValueResolver<Usr_Stmppa, ProductSpecificationDTO, IEnumerable<string>>
	{
		public IEnumerable<string> Resolve(Usr_Stmppa source, ProductSpecificationDTO destination, IEnumerable<string> member, ResolutionContext context)
		{
            if (source.Usr_Stmppa_Valor.IndexOf(";") == -1)
            {
				return new List<string> { source.Usr_Stmppa_Valor };
            }

			return source.Usr_Stmppa_Valor.Split(';').Select(p => p.Trim()).ToList();
		}
	}
}