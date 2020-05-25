import { Neuron } from './neuron';

export class Layer {
    id: number;
    neurons: Neuron[] = [];
    layerNumber: number;
    networkId: number;
}
