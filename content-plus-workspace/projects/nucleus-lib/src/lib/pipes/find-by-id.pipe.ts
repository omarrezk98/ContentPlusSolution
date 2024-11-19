import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'findById' })
export class FindByIdPipe implements PipeTransform {
  transform(list: any[], Id: any, value: any): any {
    if (!list || !Id || !value) {
      return list;
    } else {
      return list.find(s => s[Id] == value);
    }
  }
}
