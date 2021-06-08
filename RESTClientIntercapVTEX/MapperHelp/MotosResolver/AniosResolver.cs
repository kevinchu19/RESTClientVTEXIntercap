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
			int anioDesde = Convert.ToInt32(source.Usr_Prmoto_Adesde);
			int anioHasta = DateTime.Now.Year;

			int.TryParse(source.Usr_Prmoto_Ahasta, out anioHasta);

			return Enumerable.Range(anioDesde, anioHasta).ToList();
		}
	}
}
