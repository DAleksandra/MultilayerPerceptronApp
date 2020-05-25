using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultilayerPerceptron.API.Data;

namespace MultilayerPerceptron.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultilayerPerceptronController : ControllerBase
    {
        public INetworkRepository _repo { get; }
        public IMapper _mapper { get; }
        public MultilayerPerceptronController(INetworkRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        

    }
}