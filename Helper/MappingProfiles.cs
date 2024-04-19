using AutoMapper;
using ShopApplication.DTO;
using ShopApplication.Models;

namespace ShopApplication.Helper
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles() { 

			CreateMap<Product,ProductDTO>();
		}
	}
}
