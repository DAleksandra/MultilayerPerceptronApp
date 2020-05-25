import { Layer } from './layer';

export class Network {
    id: number;
    layers: Layer[] = [];
    inputs: number[] = [];
    outputsRight: number[] = [];
}
