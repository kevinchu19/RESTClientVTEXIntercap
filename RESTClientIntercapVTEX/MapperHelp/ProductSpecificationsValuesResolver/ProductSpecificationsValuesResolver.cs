using AutoMapper;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RESTClientIntercapVTEX.MapperHelp.ProductSpecificationsValuesResolver
{
	public class ProductSpecificationsValuesResolver : IValueResolver<Usr_Pratri, ProductSpecificationDTO, IEnumerable<string>>
	{
		public IEnumerable<string> Resolve(Usr_Pratri source, ProductSpecificationDTO destination, IEnumerable<string> member, ResolutionContext context)
		{
            if (source.Usr_Pratri_Valor.IndexOf(";") == -1)
            {
				return new List<string> { source.Usr_Pratri_Valor };
            }

			return source.Usr_Pratri_Valor.Split(';').Select(p => p.Trim()).ToList();
		}
	}
}