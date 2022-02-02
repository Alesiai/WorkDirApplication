import { Component, Input, OnInit } from '@angular/core';
import { StructureService } from '../services/structure.service';
import { Directory } from '../_models/Directory';

@Component({
  selector: 'app-tree',
  templateUrl: './tree.component.html',
  styleUrls: ['./tree.component.css']
})
export class TreeComponent implements OnInit {
  @Input() directory: Directory;
  
  
  constructor(private structureService: StructureService) { }

  ngOnInit(): void {
  }

  public click(path: string): void {
    this.structureService.folder.next(path.replace('\\','\\'));
    
    this.structureService.getStructure(path).subscribe(response => {
      this.directory.followingFolders.find(el => el.path === path).followingFolders = response.followingFolders;
    });
  }
}
