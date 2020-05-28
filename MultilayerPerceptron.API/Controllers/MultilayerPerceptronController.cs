using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultilayerPerceptron.API.Data;
using MultilayerPerceptron.API.DTO;
using MultilayerPerceptron.API.Models;

namespace MultilayerPerceptron.API.Controllers
{
    [Route("api/network")]
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

        [HttpPost("{networkId}/{layerId}/neuron")]
        public async Task<IActionResult> AddNeuron(int networkId, int layerId, [FromBody]NeuronToAddDto neuronToAdd)
        {
            var layer = await _repo.GetLayer(layerId);

            var neuron = _mapper.Map<Neuron>(neuronToAdd);

            layer.Neurons.Add(neuron);


            if(await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Could not add the neuron.");
        }

        [HttpPost("{networkId}/layer")]
        public async Task<IActionResult> AddLayer(int networkId, LayerToAddDto layerToAdd)
        {
            var network = await _repo.GetNetwork(networkId);
            
            var layer = _mapper.Map<Layer>(layerToAdd);

            network.Layers.Add(layer);

            if(await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Could not add the layer.");
        }

        [HttpPost]
        public async Task<IActionResult> AddNetwork()
        {
            var networkToCreate = new Network();

            var network = _repo.Add(networkToCreate);

             if(await _repo.SaveAll()){
                 return CreatedAtRoute("GetNetwork", new {id = network.Id}, network);
            }

            return BadRequest("Could not add the network.");

        }

        [HttpDelete("{networkId}/neuron/{id}")]
        public async Task<IActionResult> DeleteNeuron(int id, int networkId)
        {
            var neuron = await _repo.GetNeuron(id);

            _repo.Delete(neuron);


            if(await _repo.SaveAll())
                return Ok();

            return BadRequest("Failed to delete neuron.");

        }

        [HttpDelete("{networkId}/layer/{id}")]
        public async Task<IActionResult> DeleteLayer(int id, int networkId)
        {
            var layer = await _repo.GetLayer(id);

            _repo.Delete(layer);

            if(await _repo.SaveAll())
            {
                var network = await _repo.GetNetwork(networkId);

                network.Layers.Where(x => x.LayerNumber > layer.LayerNumber).ToList().ForEach(x => x.LayerNumber -= 1);

                if(await _repo.SaveAll())
                {
                    return Ok();
                }
                else 
                {
                    return BadRequest("Failed to delete layer.");
                }
            }


            return BadRequest("Failed to delete layer.");
        }

        [HttpDelete("network/{id}")]
        public async Task<IActionResult> DeleteNetwork(int id)
        {
            var network = await _repo.GetNetwork(id);

            _repo.Delete(network);

            if(await _repo.SaveAll())
                return Ok();

            return BadRequest("Failed to delete network.");
        }

        [HttpPut("{networkId}/neuron/{id}")]
        public async Task<IActionResult> UpdateNeuron(int id, NeuronForUpdateDto neuronForUpdate, int networkId)
        {
            var neuronFromRepo = await _repo.GetNeuron(id);

            _mapper.Map(neuronForUpdate, neuronFromRepo);

            if(await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Could not update neuron.");
        }

        [HttpGet("{id}", Name="GetNetwork")]
        public async Task<IActionResult> GetNetwork(int id)
        {
            var network = await _repo.GetNetwork(id);

            
            return Ok(network);
         
        }
    }
}