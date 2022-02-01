import { Component, OnInit } from '@angular/core';
import { StructureService } from '../services/structure.service';

@Component({
  selector: 'app-panel',
  templateUrl: './uploadPanel.component.html',
  styleUrls: ['./uploadPanel.component.css'],
})
export class UploadPanelComponent implements OnInit {
  public file: string;
  public folder: string = null;

  constructor(private structureService: StructureService) {}

  ngOnInit(): void {
    this.structureService.folder.subscribe(
      (val) => (this.folder = val)
    );
  }

  onFileChange(event) {
      this.file = event.target.files[0];
  }

  public uploadJson(): void {
    if (this.structureService.folder) {
      let fd = new FormData();
      fd.append('file', this.file);
      this.structureService.uploadJsonStructure(fd).subscribe(() => {
        this.structureService.folder.next(null);
        window.location.reload();
      });
    }
  }
}
