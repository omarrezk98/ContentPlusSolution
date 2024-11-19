import { Pipe, PipeTransform } from '@angular/core';
import KTUtil from 'shared-js/components/util';

@Pipe({ name: 'colorHex' })
export class ColorHexPipe implements PipeTransform {
  transform(text: string): string {
    if (!text) {
      return '';
    } else {
      return KTUtil.getCssVariableValue('--bs-' + text);
    }
  }
}
