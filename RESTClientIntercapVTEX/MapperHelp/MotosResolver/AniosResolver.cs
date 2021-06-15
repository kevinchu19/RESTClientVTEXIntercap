using AutoMapper;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RESTClientIntercapVTEX.MapperHelp.MotosResolver

{
	public class AniosResolver : IValueResolver<Usr_Prmoto, MotosDocumentDTO, IEnumerable<int>>
	{
		public IEnumerable<int> Resolve(Usr_Prmoto source, MotosDocumentDTO destination, IEnumerable<int> member, ResolutionContext context)
		{
			
			int.TryParse(source.Usr_Prmoto_Adesde, out int anioDesde);

            if (anioDesde == 0)
            {
				return new List<int> { };
			}

			int.TryParse(source.Usr_Prmoto_Ahasta, out int anioHasta);
		
			int cantidad = anioHasta == 0 ? DateTime.Now.Year - anioDesde : anioHasta - anioDesde;
			cantidad = cantidad + 1;

            if (cantidad < 0)
            {
				cantidad = 0;
            }
			return Enumerable.Range(anioDesde, cantidad).ToList(); ;
		}
	}
}
