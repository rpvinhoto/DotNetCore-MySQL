using AutoMapper;
using CadCliWeb.Models;
using Domain.Entidades;

namespace CadCliWeb.Mapper
{
    public static class MapperConfig
    {
        public static MapperConfiguration Configure()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClienteViewModel, Cliente>();
            });
        }
    }
}