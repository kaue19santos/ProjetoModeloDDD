using AutoMapper;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings(IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile<DomainToViewModelMappingProfile>();
            cfg.AddProfile<ViewModelToDomainMappingProfile>();
        }
    }
}