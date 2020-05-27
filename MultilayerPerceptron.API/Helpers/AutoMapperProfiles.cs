using AutoMapper;
using MultilayerPerceptron.API.DTO;
using MultilayerPerceptron.API.Models;

namespace MultilayerPerceptron.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<NetworkToAddDto, Network>();
            CreateMap<LayerToAddDto, Layer>();
            CreateMap<NeuronToAddDto, Neuron>();
            CreateMap<Network, NetworkToReturnDto>();
            CreateMap<NeuronForUpdateDto, Neuron>();
        }
    }
}