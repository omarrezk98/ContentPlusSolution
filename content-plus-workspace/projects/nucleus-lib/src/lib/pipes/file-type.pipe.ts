import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'fileType' })
export class FileTypePipe implements PipeTransform {
  transform(path: any): string {
    let mainPath = 'assets/image/files-icon/';
    if (!path) {
      return mainPath + 'unknown.svg';
    } else {
      const type = path.split('.')[1].toUpperCase();
      const videoFiles = ['AVI', 'MPG', 'FLV', 'MOV', 'WMV', 'MP4'];
      const imageFiles = ['PNG', 'JPG', 'GIF', 'JPEG', 'SVG'];
      const docFiles = ['DOC', 'DOCX', 'XLSX', 'XLSM', 'XLS'];

      if (videoFiles.includes(type)) return mainPath + 'mp4.svg';
      else if (type == 'PDF') return mainPath + 'pdf.svg';
      else if (type == 'ZIP' || type == 'RAR4' || type == 'RAR') return mainPath + 'zip.svg';
      else if (imageFiles.includes(type)) return mainPath + 'jpg.svg';
      else if (docFiles.includes(type)) return mainPath + 'doc.svg';
      else return mainPath + 'unknown.svg';
    }
  }
}
