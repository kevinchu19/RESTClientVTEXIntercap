using AutoMapper;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RESTClientIntercapVTEX.MapperHelp.MotosResolver

{
	public class AniosResolver : IValueResolver<Usr_Prmoto, MotosDocumentDTO, string>
	{
		public string Resolve(Usr_Prmoto source, MotosDocumentDTO destination, string member, ResolutionContext context)
		{
			
			int.TryParse(source.Usr_Prmoto_Adesde, out int anioDesde);

            if (anioDesde == 0)
            {
				return "";
			}

			int.TryParse(source.Usr_Prmoto_Ahasta, out int anioHasta);
		
			int cantidad = anioHasta == 0 ? DateTime.Now.Year - anioDesde : anioHasta - anioDesde;
			cantidad = cantidad + 1;

            if (cantidad < 0)
            {
				cantidad = 0;
            }
			IEnumerable<int> arrayAnios = Enumerable.Range(anioDesde, cantidad).ToList();

			return string.Join("-", arrayAnios);
		}
	}
}
