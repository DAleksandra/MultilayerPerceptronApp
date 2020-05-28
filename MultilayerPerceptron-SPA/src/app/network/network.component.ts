import { Network } from '../_models/network';
import { Layer } from '../_models/layer';
import { Neuron } from '../_models/neuron';
import { Component, TemplateRef, OnInit, ElementRef, ViewChild } from '@angular/core';
import { BsModalService, BsModalRef, ModalDirective } from 'ngx-bootstrap/modal';
import { NetworkService } from '../_services/network.service';
import { AlertifyService } from '../_services/alertify.service';

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

  constructor(private modalService: BsModalService, private networkService: NetworkService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.networkService.getNetwork(1).subscribe(x => {
      this.network = x;
      console.log(this.network);
    }, error => {
      console.log("Cannot downolad network.");
    });
  }

  onNeuron(neuron: Neuron) {
    this.content = "Value = " + neuron.value + " ; Weight: " + neuron.weight;
  }

  openModal(template: TemplateRef<any>, neuron: Neuron) {
    this.neuron.id = neuron.id;
    this.neuron.layerId = neuron.layerId;
    this.neuron.value = neuron.value;
    this.neuron.weight = neuron.weight;

    this.modalRef = this.modalService.show(template);
  }

  openModalAddNeuron(template: TemplateRef<any>, layer: Layer) {
    this.neuron = new Neuron();
    this.neuron.layerId = layer.id;

    this.layer = layer;
    this.modalRef = this.modalService.show(template);
  }

  openModalAddLayer(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }


  addLayer() {
    this.layer = new Layer();
    if(this.network.layers.length === 0) {
      this.layer.layerNumber = 1
    } else {
      this.layer.layerNumber = this.network.layers[this.network.layers.length - 1].layerNumber + 1;
    }
    
    this.networkService.addLayer(this.network.id, this.layer).subscribe(x => {
      this.alertify.success("Layer added.");
      this.networkService.getNetwork(this.network.id).subscribe(x => {
        this.network = x;
      }, error => {
        this.alertify.error("Cannot reload network.");
      });
    }, error => {
      this.alertify.error("Cannot add layer.");
    });    
    this.modalRef.hide();
  }

  addNeuron() {
    this.networkService.addNeuron(this.network.id, this.layer.id, this.neuron).subscribe( x => {
      console.log("Neuron added");
      this.networkService.getNetwork(this.network.id).subscribe(x => {
        this.network = x;
      }, error => {
        this.alertify.error("Cannot reload network.");
      });
    }, error => {
      this.alertify.error("Cannot add neuron.");
    });
    this.modalRef.hide();
  }

  deleteLayer(layer: Layer) {
    this.networkService.deleteLayer(layer.id, this.network.id).subscribe(x => {
      console.log("Layer deleted");
      this.networkService.getNetwork(this.network.id).subscribe(x => {
        this.network = x;
      }, error => {
        this.alertify.error("Cannot reload network.");
      });
    }, error => {
      this.alertify.error("Cannot delete layer.");
    });
  }

  deleteNeuron(neuron: Neuron) {
    this.networkService.deleteNeuron(this.network.id, neuron.id).subscribe(x => {
      console.log("Neuron deleted");
      this.networkService.getNetwork(this.network.id).subscribe(x => {
        this.network = x;
      }, error => {
        this.alertify.error("Cannot reload network.");
      });
    }, error => {
      this.alertify.error("Cannot delete neuron.");
    });
    this.modalRef.hide();
  }

  editNeuron() {
    this.modalRef.hide();
    this.networkService.updateNeuron(this.neuron, this.network.id).subscribe(x => {
      console.log("Neuron edited.");
      this.networkService.getNetwork(this.network.id).subscribe(x => {
        this.network = x;
      }, error => {
        this.alertify.error("Cannot reload network.");
      });
    }, error => {
      this.alertify.error("Cannot edit neuron.");
    });
  }
}
