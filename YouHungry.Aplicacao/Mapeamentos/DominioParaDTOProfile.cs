using AutoMapper;
using YouHungry.Aplicacao.DTOs;
using YouHungry.Dominio.Entidades;

namespace CleanArchMvc.Application.Mappings
{
    public class DominioParaDTOProfile : Profile
    {
        public DominioParaDTOProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Restaurante, RestauranteDTO>().ReverseMap();
            CreateMap<Prato, PratoDTO>().ReverseMap();
            CreateMap<Acompanhamento, AcompanhamentoDTO>().ReverseMap();
        }
    }
}
