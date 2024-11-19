import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'recursiveSearch',
})
export class RecursiveSearchPipe implements PipeTransform {
  transform(items: any[], searchTerm: string): any[] {
    if (!items || !searchTerm) return items;

    searchTerm = searchTerm.toLowerCase();

    return this.filterItems(items, searchTerm);
  }

  private filterItems(items: any[], searchTerm: string): any[] {
    const filteredItems: any = [];

    items.forEach(item => {
      if (this.itemMatchesSearch(item, searchTerm)) {
        filteredItems.push(item);
      }

      if (item.children && item.children.length > 0) {
        const matchingChildren = this.filterItems(item.children, searchTerm);
        if (matchingChildren.length > 0) {
          filteredItems.push({ ...item, children: matchingChildren });
        }
      }
    });

    return filteredItems;
  }

  private itemMatchesSearch(item: any, searchTerm: string): boolean {
    return item.nameAr.toLowerCase().includes(searchTerm) || item.nameEn.toLowerCase().includes(searchTerm);
  }
}
