using AutoMapper;
using ReleaseNotes.Entities.Model.Calls;
using ReleaseNotes.Entities.Model.Email;
using ReleaseNotes.Entities.Model.Feedback;
using ReleaseNotes.Entities.Model.ReleasesPowerPDV;
using ReleaseNotes.Entities.Model.ReleasesPowerServer;
using ReleaseNotes.Repository.DTO;

namespace ReleaseNotes.API.MapperConfig
{
    public static class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ReleaseDto, ReleasePDV>();
                config.CreateMap<ReleasePDV, ReleaseDto>();

                config.CreateMap<ModuleDto, ModulePDV>();
                config.CreateMap<ModulePDV, ModuleDto>();

                config.CreateMap<ReleaseDto, ReleasePowerServer>();
                config.CreateMap<ReleasePowerServer, ReleaseDto>();

                config.CreateMap<ModuleDto, ModulePowerServer>();
                config.CreateMap<ModulePowerServer, ModuleDto>();

                config.CreateMap<FeedbackDto, ReleasesFeedback>();
                config.CreateMap<ReleasesFeedback, FeedbackDto>();

                config.CreateMap<CallDto, Call>();
                config.CreateMap<Call, CallDto>();

                config.CreateMap<EmailDto, SenderEmailConfig>();
                config.CreateMap<SenderEmailConfig, EmailDto>();

                config.CreateMap<SenderDto, Sender>();
                config.CreateMap<Sender, SenderDto>();

                config.CreateMap<ReceiverDto, Receiver>();
                config.CreateMap<Receiver, ReceiverDto>();
            });

            return mappingConfig;
        }
    }
}
