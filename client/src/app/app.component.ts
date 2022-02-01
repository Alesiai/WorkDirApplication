import { Component } from '@angular/core';

import { StructureService } from './services/structure.service';
import { Directory } from './_models/Directory';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public directory: Directory
  title = 'client';

  constructor(private structureService: StructureService) { }

  ngOnInit(): void {
    this.structureService.getStructure("").subscribe(response => {
      this.directory = response;
    });
  }
}
