import { Network } from '../_models/network';
import { Layer } from '../_models/layer';
import { Neuron } from '../_models/neuron';
import { Component, TemplateRef, OnInit } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-network',
  templateUrl: './network.component.html',
  styleUrls: ['./network.component.css']
})
export class NetworkComponent implements OnInit {
  network: Network = new Network();
  neuron: Neuron = new Neuron();
  layer: Layer = new Layer();
  content: string = "Nothing";
  modalRef: any;
  constructor(private modalService: BsModalService) { }

  ngOnInit() {
    let layer = new Layer();
    let neuron = new Neuron();
    neuron.id = 1;
    neuron.value = 1;
    neuron.weight = 0.1;
    layer.neurons.push(neuron);
    neuron = new Neuron();
    neuron.id = 2;
    neuron.value = 0;
    neuron.weight = 0.2;
    layer.neurons.push(neuron);
    layer.id = 1;
    layer.layerNumber = 1;
    layer.networkId = 1;
    this.network.layers.push(layer);
    layer = new Layer();
    layer.neurons.push(neuron);
    layer.id = 2;
    layer.layerNumber = 2;
    layer.networkId = 1;
    this.network.layers.push(layer);
    console.log(this.network);
  }

  onNeuron(neuron: Neuron) {
    this.content = "Value = " + neuron.value + " ; Weight: " + neuron.weight;
  }

  openModal(template: TemplateRef<any>, neuron: Neuron) {
    this.neuron = neuron;
    this.modalRef = this.modalService.show(template);
  }

  openModalAddNeuron(template: TemplateRef<any>, layer: Layer) {
    this.layer = layer;
    this.modalRef = this.modalService.show(template);
  }

  addLayer() {

  }

  addNeuron() {

  }
}
