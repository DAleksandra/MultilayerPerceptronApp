import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Network } from '../_models/network';
import { Neuron } from '../_models/neuron';
import { Layer } from '../_models/layer';

@Injectable({
  providedIn: 'root'
})
export class NetworkService {
baseUrl = 'http://localhost:5000/api/network/';

constructor(private http: HttpClient) { }

getNetwork(networkId: number) {
  return this.http.get<Network>(this.baseUrl + networkId);
}

addNetwork() {
  return this.http.post(this.baseUrl, '');
}

deleteNetwork(networkId: number) {
  return this.http.delete(this.baseUrl + networkId);
}

addLayer(networkId: number, layer: Layer) {
  return this.http.post(this.baseUrl + networkId + '/layer', layer);
}

deleteLayer(layerId: number, networkId: number) {
  return this.http.delete(this.baseUrl + networkId + '/layer/' + layerId);
}

addNeuron(networkId: number, layerId: number, neuron: Neuron) {
  return this.http.post(this.baseUrl + networkId + '/' + layerId + '/neuron', neuron);
}

deleteNeuron(networkId: number, neuronId: number) {
  return this.http.delete(this.baseUrl + networkId + '/neuron/' + neuronId);
}

updateNeuron(neuron: Neuron, networkId: number) {
  return this.http.put(this.baseUrl + networkId + '/neuron/' + neuron.id, neuron);
}

}
